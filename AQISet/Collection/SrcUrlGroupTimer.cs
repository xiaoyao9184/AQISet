using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using AQI.Interface;
using AQISet.Cfg;
using AQISet.Control;

namespace AQISet.Collection
{
    /// <summary>
    /// 数据接口分组计时器
    ///     同UDI的数据接口为一组
    /// </summary>
    public class SrcUrlGroupTimer : Timer
    {

        #region 字段

        private string name;                         //名称
        private double intervalseconds;              //时间间隔
        private Dictionary<string, ISrcUrl> isulist; //"数据接口"集合
        private System.Threading.AutoResetEvent autoEvent;          //
        private System.Threading.ReaderWriterLockSlim thisLock;     //读写锁

        #endregion

        #region 属性

        public string Name
        {
            get
            {
                return name;
            }
        }

        public double IntervalSeconds
        {
            get
            {
                return intervalseconds;
            }
        }

        public Dictionary<string, ISrcUrl> SrcUrl
        {
            get
            {
                return isulist;
            }
        }

        public ISrcUrl this[string name]
        {
            get
            {
                if (isulist.ContainsKey(name))
                {
                    return isulist[name];
                }
                return null;
            }
        }

        #endregion

        #region 构造

        /// <summary>
        /// 默认构造
        ///     没有更新间隔
        /// </summary>
        /// <param name="name"></param>
        public SrcUrlGroupTimer(string name)
        {
            this.name = name;
            this.intervalseconds = -1;
            this.isulist = new Dictionary<string, ISrcUrl>();
            this.thisLock = new System.Threading.ReaderWriterLockSlim(System.Threading.LockRecursionPolicy.SupportsRecursion);
        }

        /// <summary>
        /// 一般构造
        ///     有更新间隔
        /// </summary>
        /// <param name="name"></param>
        /// <param name="interval"></param>
        public SrcUrlGroupTimer(string name, double interval)
            : base(interval*1000)
        {
            this.name = name;
            this.intervalseconds = interval;
            this.AutoReset = true;
            this.isulist = new Dictionary<string, ISrcUrl>();
            this.thisLock = new System.Threading.ReaderWriterLockSlim(System.Threading.LockRecursionPolicy.SupportsRecursion);
        }

        #endregion

        #region 方法

        #region 基本控制

        /// <summary>
        /// 开始执行第一次，并定时执行
        ///      Main控制线程调用
        /// </summary>
        /// <param name="firstMethod"></param>
        /// <returns></returns>
        public void StartFirst(Action<object, ElapsedEventArgs> firstMethod)
        {
            if (intervalseconds > 0)
            {
                this.Elapsed += new ElapsedEventHandler(firstMethod);
                this.Enabled = true;
            }
            //新线程
            new System.Threading.Thread(
                    delegate() { 
                        firstMethod(this, null);
                    }
                ).Start();
        }

        /// <summary>
        /// 线程等待
        /// </summary>
        public void Wait()
        {
            if(autoEvent==null)
            {
                autoEvent = new System.Threading.AutoResetEvent(false);
            }
            autoEvent.WaitOne();
        }

        /// <summary>
        /// 线程恢复
        /// </summary>
        public void Set()
        {
            autoEvent.Set();
        }

        #endregion

        #region 动态控制

        /// <summary>
        /// 合并ISU
        ///      Main控制线程调用
        /// </summary>
        /// <param name="timer"></param>
        public void Union(SrcUrlGroupTimer timer)
        {
            foreach (ISrcUrl isu in timer.isulist.Values)
            {
                Add(isu);
            }
        }

        /// <summary>
        /// 添加ISU
        ///     Main控制线程调用
        /// </summary>
        public void Add(ISrcUrl isu)
        {
            if (intervalseconds == isu.UDI)
            {
                thisLock.EnterWriteLock();
                {
                    if (isulist.ContainsKey(isu.TAG))
                    {
                        isulist[isu.TAG] = isu;
                    }
                    else
                    {
                        isulist.Add(isu.TAG, isu);
                    } 
                }
                thisLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// 删除ISU
        ///      Main控制线程调用
        /// </summary>
        /// <param name="isuname"></param>
        public void Dele(string isuname)
        {
            thisLock.EnterWriteLock();
            {
                if (isulist.ContainsKey(isuname))
                {
                   isulist.Remove(isuname);
                }
            }
            thisLock.ExitWriteLock();
        }

        /// <summary>
        /// 删除
        ///      Main控制线程调用
        /// </summary>
        /// <param name="awtagname">数据源 标识或名称</param>
        public void DeleSrcUrl(string awtagname)
        {
            thisLock.EnterUpgradeableReadLock();
            {
                List<string> tlist = new List<string>();
                foreach (ISrcUrl isu in isulist.Values)
                {
                    if (isu.IAW.TAG == awtagname)
                    {
                        tlist.Add(isu.TAG);
                    }
                    else if (isu.IAW.NAME == awtagname)
                    {
                        tlist.Add(isu.TAG);
                    }
                }

                thisLock.EnterWriteLock();
                {
                    foreach (string isutag in tlist)
                    {
                        isulist.Remove(isutag);
                    }
                }
                thisLock.ExitWriteLock();
            }
            thisLock.ExitUpgradeableReadLock();
        }

        #endregion

        /// <summary>
        /// 处理
        ///     Timer处理线程调用
        /// </summary>
        /// <param name="runner"></param>
        public void Handle(AqiRunner runner)
        {
            thisLock.EnterReadLock();
            {
                foreach (ISrcUrl isu in isulist.Values)
                {
                    runner.routeProcess(isu, this);
                }
            }
            thisLock.ExitReadLock();
        }


        #endregion

        #region Factory

        /// <summary>
        /// 生成“数据源分组计时器”集合
        ///     根据“数据源”UDI分组
        /// </summary>
        /// <param name="srcUrls"></param>
        /// <returns></returns>
        public static Dictionary<string, SrcUrlGroupTimer> BuildList(Dictionary<string, ISrcUrl> srcUrls)
        {
            List<SrcUrlGroupTimer> sugTimerList = new List<SrcUrlGroupTimer>();

            foreach (ISrcUrl isu in srcUrls.Values)
            {
                SrcUrlGroupTimer sugTimer = sugTimerList.Find(
                    delegate(SrcUrlGroupTimer sugt)
                    {
                        return sugt.IntervalSeconds == isu.UDI;
                    }
                );

                if (sugTimer != null)
                {
                    sugTimer.isulist.Add(isu.TAG, isu);
                }
                else
                {
                    string name = Language.GetSomeTime(isu.UDI);
                    if (isu.UDI <= 0)
                    {
                        sugTimer = new SrcUrlGroupTimer(name);
                    }
                    else
                    {
                        sugTimer = new SrcUrlGroupTimer(name, isu.UDI);
                    }
                    sugTimer.isulist.Add(isu.TAG, isu);
                    sugTimerList.Add(sugTimer);
                }
            }

            return sugTimerList.ToDictionary(sugt => sugt.Name, sugt => sugt);
        }

        #endregion

    }
}
