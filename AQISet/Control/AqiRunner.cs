using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Text;
using System.Linq;
using AQI;
using AQI.Interface;
using AQI.Abstract;
using AQI.Exception;
using AQISet.Interface;
using AQISet.Collection;
using AQISet.Control.Saver;

namespace AQISet.Control
{
    /// <summary>
    /// 运行者
    /// </summary>
    public class AqiRunner : IThrowMessage, ISubObject, IStatus
    {

        #region 枚举

        /// <summary>
        /// 运行方式
        /// </summary>
        public enum RunMode
        {
            NONE, SELF, JOINT
        }

        #endregion

        #region 事件

        //定义delegate
        public delegate void RunEventHandler(RunMessage m);
        //用event 关键字声明事件对象
        public event RunEventHandler RunEvent;
        //抛出事件
        public bool ThrowEvent(RunMessage eRunMessage)
        {
            if (RunEvent != null)
            {
                RunEvent(eRunMessage);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ThrowEvent(RunMessage.RunType eType, string eMsg)
        {
            if (RunEvent != null)
                RunEvent(new RunMessage(eType, eMsg, this));
        }
        public bool ThrowWaitEvent(string eMsg, ISrcUrl eSrcUrl)
        {
            if (RunEvent != null)
            {
                RunMessage rm = new RunMessage(RunMessage.RunType.WAIT, eMsg, this);
                rm.AttachObject = (eSrcUrl as ISrcUrlParam).ParamName;
                RunEvent(rm);
                return true;
            }
            return false;
        }

        #endregion

        #region 常量

        public const string DEFAULT_NAME = "default";
        public const string SET_RUNMODE = "AqiRunner.RunMode";

        #endregion

        #region 字段

        private string name;        //名称
        private Dictionary<string, SrcUrlGroupTimer> dictTimer;  //"数据接口分组定时器"集合
        private IAqiSave ias;       //引用
        private AqiNoter an;        //
        private AqiRetryer ar;      //
        private ReaderWriterLockSlim thisLock;     //读写锁

        #endregion

        #region 构造

        /// <summary>
        /// 默认构造
        ///     合并运行模式使用
        /// </summary>
        /// <param name="manage"></param>
        /// <param name="listSrcUrl"></param>
        public AqiRunner(AqiManage manage, List<ISrcUrl> listSrcUrl)
        {
            this.name = "DefaultRunner";
            this.dictTimer = SrcUrlGroupTimer.CreateList(listSrcUrl, new Action<object, System.Timers.ElapsedEventArgs>(this.timer_RunEvent));
            this.ias = manage.AqiSave;
            this.an = manage.AqiNote;
            this.ar = manage.AqiRetry;
            this.thisLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }

        /// <summary>
        /// 一般构造
        ///     独立运行模式使用
        /// </summary>
        /// <param name="aqiManage"></param>
        /// <param name="listSrcUrl"></param>
        /// <param name="name">名称一般同 数据源tag</param>
        public AqiRunner(AqiManage aqiManage, List<ISrcUrl> listSrcUrl, string name)
        {
            this.name = name;
            this.dictTimer = SrcUrlGroupTimer.CreateList(listSrcUrl, new Action<object, ElapsedEventArgs>(this.timer_RunEvent));
            this.ias = aqiManage.AqiSave;
            this.an = aqiManage.AqiNote;
            this.ar = aqiManage.AqiRetry;
            this.thisLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }

        #endregion

        #region 基本控制

        /// <summary>
        /// 运行全部定时器
        /// </summary>
        public bool RunAll()
        {
            if ((this.dictTimer == null) || (this.dictTimer.Count <= 0))
            {
                return false;
            }
            AqiManage.Remind.Log_Debug("开始运行全部Timer", new string[] { this.name });
            foreach (SrcUrlGroupTimer timer in this.dictTimer.Values)
            {
                timer.Start();
            }
            AqiManage.Remind.Log_Info(this.dictTimer.Count + "个数据源分组定时器，全部启用", new string[] { this.name });
            return true;
        }

        /// <summary>
        /// 结束全部定时器
        /// </summary>
        public bool EndAll()
        {
            AqiManage.Remind.Log_Debug("开始结束全部Timer", new string[] { this.name });
            foreach (SrcUrlGroupTimer timer in this.dictTimer.Values)
            {
                timer.Stop();
            }
            AqiManage.Remind.Log_Info(this.dictTimer.Count + "个数据源分组定时器，全部结束", new string[] { this.name });
            return true;
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="timername">定时器 名称</param>
        public bool Run(string timername)
        {
            if (this.dictTimer.ContainsKey(timername))
            {
                AqiManage.Remind.Log_Debug("开始运行分组定时器:" + timername, new string[] { this.name });
                this.dictTimer[timername].Start();
                return true;
            }
            AqiManage.Remind.Log_Error("开始运行分组定时器:" + timername + "不存在!", new string[] { this.name });
            return false;
        }

        /// <summary>
        /// 结束
        /// </summary>
        /// <param name="timername">定时器 名称</param>
        public bool End(string timername)
        {
            if (this.dictTimer.ContainsKey(timername))
            {
                AqiManage.Remind.Log_Debug("结束运行分组定时器:" + timername, new string[] { this.name });
                this.dictTimer[timername].Stop();
                return true;
            }
            AqiManage.Remind.Log_Error("结束运行分组定时器:" + timername + "不存在!", new string[] { this.name });
            return false;
        }

        #endregion

        #region 动态控制

        /// <summary>
        /// 添加timer
        /// </summary>
        /// <param name="timer"></param>
        public bool Add(SrcUrlGroupTimer timer)
        {
            try
            {
                this.thisLock.EnterUpgradeableReadLock();

                if (this.dictTimer.ContainsKey(timer.Name))
                {
                    //合并
                    return this.dictTimer[timer.Name].Union(timer);
                }
                else
                {
                    this.thisLock.EnterWriteLock();
                    this.dictTimer.Add(timer.Name, timer);
                    timer.Elapsed += new ElapsedEventHandler(timer_RunEvent);
                    timer.Start();
                    this.thisLock.ExitWriteLock();
                }
            }
            finally
            {
                this.thisLock.ExitUpgradeableReadLock();
            }
            return true;
        }

        /// <summary>
        /// 删除timer
        /// </summary>
        /// <param name="timerName"></param>
        public bool Dele(string timerName)
        {
            try
            {
                this.thisLock.EnterUpgradeableReadLock();

                if (this.dictTimer.ContainsKey(timerName))
                {
                    this.dictTimer[timerName].Stop();
                    this.thisLock.EnterWriteLock();
                    this.dictTimer.Remove(timerName);
                    this.thisLock.ExitWriteLock();
                }
            }
            finally
            {
                this.thisLock.ExitUpgradeableReadLock();
            }
            return true;
        }

        /// <summary>
        /// 合并timer
        /// </summary>
        /// <param name="runner"></param>
        public bool Union(AqiRunner runner)
        {
            try
            {
                runner.thisLock.EnterWriteLock();
                this.thisLock.EnterWriteLock();

                foreach(string name in runner.dictTimer.Keys)
                {
                    if (this.dictTimer.ContainsKey(name))
                    {
                        this.dictTimer[name].Union(runner.dictTimer[name]);
                    }
                    else
                    {
                        this.dictTimer.Add(name, runner.dictTimer[name]);
                    }
                }
                runner.dictTimer.Clear();
                return true;
            }
            finally
            {
                this.thisLock.ExitWriteLock();
                runner.thisLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// 添加 数据源接口
        /// </summary>
        /// <param name="dictSrcUrl">接口集合</param>
        public bool AddSrcUrl(Dictionary<string, ISrcUrl> dictSrcUrl)
        {
            //转为Timer集合
            Dictionary<string, SrcUrlGroupTimer> list = SrcUrlGroupTimer.CreateList(dictSrcUrl);
            foreach(SrcUrlGroupTimer timer in list.Values)
            {
                Add(timer); 
            }

            return true;
        }

        /// <summary>
        /// 删除 数据源接口
        /// </summary>
        /// <param name="iawTag">数据源 标识或名称</param>
        public bool DeleSrcUrl(string iawTag)
        {
            try
            {
                this.thisLock.EnterUpgradeableReadLock();

                foreach (SrcUrlGroupTimer timer in this.dictTimer.Values)
                {
                    if(!timer.DeleAll(iawTag))
                    {
                        AqiManage.Remind.Log_Error("删除分组定时器中的ISrcUrl失败:" + iawTag, this.name, timer.Name);
                        return false;
                    }
                }
            }
            finally
            {
                this.thisLock.ExitUpgradeableReadLock();
            }
            return true;
        }

        #endregion

        #region 事件接收

        /// <summary>
        /// 运行处理
        /// </summary>
        /// <param name="source">定时器</param>
        /// <param name="e">定时器参数</param>
        private void timer_RunEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            SrcUrlGroupTimer timer = source as SrcUrlGroupTimer;
            if (e != null)
            {
                Thread.CurrentThread.Name = timer.Name + "_Timer(Timer)";
            }
            AqiManage.Remind.Log_Debug("定时任务开始执行", new string[] { this.name, timer.Name });
            if (timer.Handle(this))
            {
                AqiManage.Remind.Log_Debug("定时任务开始休眠", new string[] { this.name, timer.Name });
            }
            else
            {
                AqiManage.Remind.Log_Debug("定时器人为取消", new string[] { this.name, timer.Name });
            }
        }

        #endregion

        #region 处理

        /// <summary>
        /// 路由处理
        ///     再此方法中调用的方法应保证线程安全
        /// </summary>
        /// <param name="isu">数据接口</param>
        /// <param name="sugt">定时器，用于堵塞</param>
        public void RouteProcess(ISrcUrl isu, SrcUrlGroupTimer sugt)
        {
            //加载配置
            if(isu.IAW is ICacheConfig)
            {
                ICacheConfig icc = isu.IAW as ICacheConfig;
                if (!icc.IsSrcUrlEnabled(isu.Tag))
                {
                    return;
                }
            }

            //双向确认是否使用参数
            if (isu.UseParam && isu is ISrcUrlParam)
            {
                this.GetProcess(isu as ISrcUrlParam, sugt);
            }
            else
            {
                this.GetProcess(isu, sugt);
            }
        }

        /// <summary>
        /// 获取处理
        /// </summary>
        /// <param name="isu">数据接口</param>
        /// <param name="sugt">定时器</param>
        public void GetProcess(ISrcUrl isu, SrcUrlGroupTimer sugt)
        {
            byte[] data = null;
            try
            {
                data = isu.GetDate();
            }
            catch (Exception exception)
            {
                AqiManage.Remind.Log_Error("数据获取失败，进入重试队列", new string[] { this.name, sugt.Name, isu.Name });
                this.ar.PutNew(this.name, isu, null, exception);
                return;
            }
            this.SaveProcess(data, isu, null);
        }

        /// <summary>
        /// 获取处理
        /// </summary>
        /// <param name="isup"></param>
        /// <param name="sugt"></param>
        public void GetProcess(ISrcUrlParam isup, SrcUrlGroupTimer sugt)
        {
            //获取参数
            List<AqiParam> list = null;
            ISrcUrl isu = isup as ISrcUrl;
            if (isup is ICacheParam)
            {
                ICacheParam icp = isup as ICacheParam;
                if (icp.IsParamsExpired())
                {
                    icp.LoadParams();
                }
                list = icp.FilterParams();
            }
            else
            {
                list = isup.EnumParams();
            }
            //TODO 
            //应该在检验参数
            while ((list == null) || (list.Count == 0))
            {
                if (isup.ParamIgnoreEmpty)
                {
                    AqiManage.Remind.Log_Error("缺少参数，此数据接口在无参数是将被忽略", new string[] { this.name, sugt.Name, isu.Name });
                    return;
                }
                if (this.ThrowWaitEvent(isu.Name + ":缺少参数，请输入以下参数", isu))
                {
                    AqiManage.Remind.Log_Debug("缺少参数，进入等待", new string[] { this.name, sugt.Name, isu.Name });
                    sugt.Wait();
                }
                else
                {
                    AqiManage.Remind.Log_Error("缺少参数，而且无法获取忽略此数据接口", new string[] { this.name, sugt.Name, isu.Name });
                    return;
                }
            }
            foreach (AqiParam ap in list)
            {
                if (sugt.IsCancellationRequested)
                {
                    break;
                }

                byte[] data = null;
                try
                {
                    data = isup.GetDate(ap);
                }
                catch (Exception exception)
                {
                    AqiManage.Remind.Log_Error("数据获取失败，进入重试队列", new string[] { this.name, sugt.Name, isu.Name });
                    this.ar.PutNew(this.name, isu, ap, exception);
                }

                this.SaveProcess(data, isu, ap);
            }
        }

        /// <summary>
        /// 重试处理
        /// </summary>
        /// <param name="arn">重试节点</param>
        /// <returns></returns>
        public bool RetryProcess(RetryNode arn)
        {
            ISrcUrl isu = arn.SrcUrl;
            AqiParam ap = arn.Param;
            byte[] data = null;
            try
            {
                if (isu is ISrcUrlParam)
                {
                    ISrcUrlParam isup = isu as ISrcUrlParam;
                    data = isup.GetDate(ap);
                }
                else
                {
                    data = isu.GetDate();
                }
            }
            catch (Exception ex)
            {
                AqiManage.Remind.Log_Error("数据重试失败，再入重试队列", new string[] { this.name, arn.Name, isu.Name });
                this.ar.PutAgain(arn, ex);
                return false;
            }
            this.SaveProcess(data, isu, ap);
            arn.Reset();
            return true;
        }

        /// <summary>
        /// 保存处理
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="isu">数据接口</param>
        /// <param name="ap">参数</param>
        public void SaveProcess(byte[] data, ISrcUrl isu, AqiParam ap)
        {
            try
            {
                //统计信息
                NoteNode node = this.an.AddNew(isu, ap, data);
                //保存
                if (ap == null)
                {
                    node.Saved = this.ias.Save(isu, data);
                }
                else
                {
                    node.Saved = this.ias.Save(isu, ap, data);
                }
                if (node.Saved)
                {
                    AqiManage.Remind.Log_Info("数据保存成功", new string[] { this.name, isu.Name });
                }
                else
                {
                    node.Data = data;
                    AqiManage.Remind.Log_Error("数据保存失败", new string[] { this.name, isu.Name });
                }
            }
            catch (Exception exception)
            {
                AqiManage.Remind.Log_Error("数据保存失败", exception, new string[] { this.name, isu.Name });
            }
        }

        #endregion

        #region ISubObject接口

        public object GetSubObject(string name)
        {
            if (this.dictTimer.ContainsKey(name))
            {
                return this.dictTimer[name];
            }
            return null;
        }

        #endregion

        #region IStatus接口

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string GetInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("运行者信息：" + this.name);
            builder.Append("\n\t");
            builder.Append("分组定时器：" + this.dictTimer.Count + "个");
            foreach (SrcUrlGroupTimer timer in this.dictTimer.Values)
            {
                builder.Append("\n\t\t");
                builder.Append(timer.Name);
            }
            return builder.ToString();
        }

        #endregion

    }
}
