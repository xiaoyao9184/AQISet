using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI.Interface;
using AQISet.Cfg;
using AQISet.Control;
using AQISet.Interface;

namespace AQISet.Collection
{
    /// <summary>
    /// 数据接口分组计时器
    ///     同UDI的数据接口为一组
    /// </summary>
    public class SrcUrlGroupTimer : System.Timers.Timer, IStatus
    {

        #region 字段

        private string name;                         //名称
        private double intervalseconds;              //时间间隔
        private Dictionary<string, ISrcUrl> listISU; //"数据接口"集合
        private Action<object, System.Timers.ElapsedEventArgs> method;
        private Thread thr;
        private CancellationTokenSource cts;
        private AutoResetEvent autoEvent;          //
        private ReaderWriterLockSlim thisLock;     //读写锁
        
        #endregion

        #region 属性

        public bool IsCancellationRequested
        {
            get
            {
                return this.cts.IsCancellationRequested;
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
                return listISU;
            }
        }

        public ISrcUrl this[string name]
        {
            get
            {
                if (listISU.ContainsKey(name))
                {
                    return listISU[name];
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
            this.listISU = new Dictionary<string, ISrcUrl>();
            this.thisLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }
        public SrcUrlGroupTimer(string name, Action<object, System.Timers.ElapsedEventArgs> method)
            : base(Int32.MaxValue)
        {
            this.name = name;
            this.intervalseconds = -1.0;
            this.listISU = new Dictionary<string, ISrcUrl>();
            this.thisLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
            this.method = method;
            base.Enabled = false;
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
            this.listISU = new Dictionary<string, ISrcUrl>();
            this.thisLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }
        public SrcUrlGroupTimer(string name, double interval, Action<object, System.Timers.ElapsedEventArgs> method)
            : base(interval * 1000.0)
        {
            this.name = name;
            this.intervalseconds = interval;
            base.AutoReset = true;
            this.listISU = new Dictionary<string, ISrcUrl>();
            this.thisLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
            this.method = method;
            base.Elapsed += new System.Timers.ElapsedEventHandler(method.Invoke);
        }

        #endregion

        #region 基本控制

        /// <summary>
        /// 开始
        /// </summary>
        public new void Start()
        {
            if (this.thr != null)
            {
                if (this.thr.ThreadState == ThreadState.Running)
                {
                    this.cts.Cancel();
                }
                this.thr.Join();
            }
            if (base.Enabled)
            {
                base.Stop();
            }
            this.cts = new CancellationTokenSource();
            base.Start();
            this.thr = new Thread(() => this.method(this, null));
            this.thr.Name = this.name + "_Timer(First)";
            this.thr.Start();
        }

        /// <summary>
        /// 结束
        /// </summary>
        public new void Stop()
        {
            if ((this.thr != null) && (this.thr.ThreadState == ThreadState.Running))
            {
                this.cts.Cancel();
            }
            base.Stop();
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
        /// 添加ISU
        ///     Main控制线程调用
        /// </summary>
        public bool Add(ISrcUrl isu)
        {
            if (intervalseconds == isu.UDI)
            {
                if (this.thisLock.TryEnterWriteLock(1000))
                {
                    if (listISU.ContainsKey(isu.Tag))
                    {
                        listISU[isu.Tag] = isu;
                    }
                    else
                    {
                        listISU.Add(isu.Tag, isu);
                    }
                    this.thisLock.ExitWriteLock();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 删除ISU
        ///      Main控制线程调用
        /// </summary>
        /// <param name="isuName"></param>
        public bool Dele(string isuName)
        {
            if (this.thisLock.TryEnterWriteLock(1000))
            {
                if (listISU.ContainsKey(isuName))
                {
                    listISU.Remove(isuName);
                }
                this.thisLock.ExitWriteLock();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 批量删除ISU
        ///      Main控制线程调用
        /// </summary>
        /// <param name="iawTag">数据源 标识或名称</param>
        public bool DeleAll(string iawTag)
        {
            List<string> listTemp = new List<string>();
            foreach (ISrcUrl isu in this.listISU.Values)
            {
                if (isu.IAW.Tag == iawTag)
                {
                    listTemp.Add(isu.Tag);
                }
            }

            if(this.thisLock.TryEnterWriteLock(1000))
            {
                foreach (string isutag in listTemp)
                {
                    this.listISU.Remove(isutag);
                }
                this.thisLock.ExitWriteLock();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 合并ISU
        ///      Main控制线程调用
        /// </summary>
        /// <param name="timer"></param>
        public bool Union(SrcUrlGroupTimer timer)
        {
            if (timer.thisLock.TryEnterWriteLock(1000))
            {
                try
                {
                    if (this.thisLock.TryEnterWriteLock(1000))
                    {
                        this.listISU = this.listISU.Concat<KeyValuePair<string, ISrcUrl>>(timer.listISU).ToDictionary<KeyValuePair<string, ISrcUrl>, string, ISrcUrl>(x => x.Key, x => x.Value);
                        timer.listISU.Clear();
                        return true;
                    }
                }
                finally
                {
                    this.thisLock.ExitWriteLock();
                    timer.thisLock.ExitWriteLock();
                }
            }
            return false;
        }

        #endregion

        #region 处理

        /// <summary>
        /// 处理
        ///     Timer处理线程调用
        /// </summary>
        /// <param name="runner"></param>
        public bool Handle(AqiRunner runner)
        {
            this.thisLock.EnterReadLock();
            foreach (ISrcUrl url in this.listISU.Values)
            {
                if (this.IsCancellationRequested)
                {
                    return false;
                }
                runner.RouteProcess(url, this);
            }
            this.thisLock.ExitReadLock();
            return true;
        }

        #endregion

        #region Factory

        /// <summary>
        /// 生成“数据源分组计时器”集合
        ///     根据“数据源”UDI分组
        /// </summary>
        /// <param name="dictSrcUrl"></param>
        /// <returns></returns>
        public static Dictionary<string, SrcUrlGroupTimer> CreateList(Dictionary<string, ISrcUrl> dictSrcUrl)
        {
            List<SrcUrlGroupTimer> sugTimerList = new List<SrcUrlGroupTimer>();

            foreach (ISrcUrl isu in dictSrcUrl.Values)
            {
                SrcUrlGroupTimer sugTimer = sugTimerList.Find(
                    delegate(SrcUrlGroupTimer sugt)
                    {
                        return sugt.IntervalSeconds == isu.UDI;
                    }
                );

                if (sugTimer != null)
                {
                    sugTimer.listISU.Add(isu.Tag, isu);
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
                    sugTimer.listISU.Add(isu.Tag, isu);
                    sugTimerList.Add(sugTimer);
                }
            }

            return sugTimerList.ToDictionary(sugt => sugt.name, sugt => sugt);
        }

        public static Dictionary<string, SrcUrlGroupTimer> CreateList(List<ISrcUrl> listSrcUrl, Action<object, System.Timers.ElapsedEventArgs> firstMethod)
        {
            List<SrcUrlGroupTimer> source = new List<SrcUrlGroupTimer>();
            using (List<ISrcUrl>.Enumerator enumerator = listSrcUrl.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Predicate<SrcUrlGroupTimer> match = null;
                    ISrcUrl isu = enumerator.Current;
                    if (match == null)
                    {
                        match = sugt => sugt.IntervalSeconds == isu.UDI;
                    }
                    SrcUrlGroupTimer item = source.Find(match);
                    if (item != null)
                    {
                        item.listISU.Add(isu.Tag, isu);
                    }
                    else
                    {
                        string someTime = Language.GetSomeTime(isu.UDI);
                        if (isu.UDI <= 0.0)
                        {
                            item = new SrcUrlGroupTimer(someTime, firstMethod);
                        }
                        else
                        {
                            item = new SrcUrlGroupTimer(someTime, isu.UDI, firstMethod);
                        }
                        item.listISU.Add(isu.Tag, isu);
                        source.Add(item);
                    }
                }
            }
            return source.ToDictionary<SrcUrlGroupTimer, string, SrcUrlGroupTimer>(sugt => sugt.name, sugt => sugt);
        }

        #endregion

        #region IStatus接口

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string GetInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("分组定时器信息：" + this.name);
            builder.Append("\n\t");
            builder.Append("数据接口：" + this.SrcUrl.Count + "个");
            foreach (ISrcUrl url in this.SrcUrl.Values)
            {
                builder.Append("\n\t\t");
                builder.Append(url.Tag);
                builder.Append("\t");
                builder.Append(url.Name);
            }
            return builder.ToString();
        }

        #endregion

    }
}
