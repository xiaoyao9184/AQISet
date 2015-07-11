using System;
using System.Timers;
using System.Collections.Generic;
using AQI.Interface;
using AQI.Abstract;
using AQISet.Interface;
using AQISet.Collection;
using AQI;
using AQISet.Control.Saver;
using System.Threading;
using System.Text;

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
                rm.AttachObject = (eSrcUrl as IMakeParam).PL;
                RunEvent(rm);
                return true;
            }
            return false;
        }

        #endregion

        #region 字段

        private string name;        //名称
        private Dictionary<string, SrcUrlGroupTimer> sugtlist;  //"数据接口分组定时器"集合
        private IAqiSave ias;       //引用
        private AqiNoter an;        //
        private AqiRetryer ar;      //
        
        #endregion

        #region 构造

        /// <summary>
        /// 默认构造
        ///     合并运行模式使用
        /// </summary>
        /// <param name="aqiManage"></param>
        /// <param name="srcUrls"></param>
        public AqiRunner(AqiManage aqiManage, List<ISrcUrl> srcUrls)
        {
            name = "DefaultRunner";
            sugtlist = SrcUrlGroupTimer.BuildList(srcUrls, new Action<object, System.Timers.ElapsedEventArgs>(this.timer_RunEvent));
            ias = aqiManage.AqiSave;
            an = aqiManage.AqiNote;
            ar = aqiManage.AqiRetry;
        }

        /// <summary>
        /// 一般构造
        ///     独立运行模式使用
        /// </summary>
        /// <param name="aqiManage"></param>
        /// <param name="srcUrls"></param>
        /// <param name="strName">名称一般同 数据源TAG</param>
        public AqiRunner(AqiManage aqiManage, List<ISrcUrl> srcUrls, string strName)
        {
            name = strName;
            sugtlist = SrcUrlGroupTimer.BuildList(srcUrls, new Action<object, ElapsedEventArgs>(this.timer_RunEvent));
            ias = aqiManage.AqiSave;
            an = aqiManage.AqiNote;
            ar = aqiManage.AqiRetry;
        }

        #endregion

        #region 基本控制

        /// <summary>
        /// 运行全部定时器
        /// </summary>
        public bool RunAll()
        {
            if ((this.sugtlist == null) || (this.sugtlist.Count <= 0))
            {
                return false;
            }
            AqiManage.Remind.Log_Debug("开始运行全部Timer", new string[] { this.name });
            foreach (SrcUrlGroupTimer timer in this.sugtlist.Values)
            {
                timer.Start();
            }
            AqiManage.Remind.Log_Info(this.sugtlist.Count + "个数据源分组定时器，全部启用", new string[] { this.name });
            return true;
        }

        /// <summary>
        /// 结束全部定时器
        /// </summary>
        public bool EndAll()
        {
            AqiManage.Remind.Log_Debug("开始结束全部Timer", new string[] { this.name });
            foreach (SrcUrlGroupTimer timer in this.sugtlist.Values)
            {
                timer.Stop();
            }
            AqiManage.Remind.Log_Info(this.sugtlist.Count + "个数据源分组定时器，全部结束", new string[] { this.name });
            return true;
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="timername">定时器 名称</param>
        public bool Run(string timername)
        {
            if (this.sugtlist.ContainsKey(timername))
            {
                AqiManage.Remind.Log_Debug("开始运行分组定时器:" + timername, new string[] { this.name });
                this.sugtlist[timername].Start();
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
            if (this.sugtlist.ContainsKey(timername))
            {
                AqiManage.Remind.Log_Debug("结束运行分组定时器:" + timername, new string[] { this.name });
                this.sugtlist[timername].Stop();
                return true;
            }
            AqiManage.Remind.Log_Error("结束运行分组定时器:" + timername + "不存在!", new string[] { this.name });
            return false;
        }

        #endregion

        #region 动态控制

        /// <summary>
        /// 合并timer
        /// </summary>
        /// <param name="runner"></param>
        public void Union(AqiRunner runner)
        {
            foreach (SrcUrlGroupTimer timer in runner.sugtlist.Values)
            {
                Add(timer);
            }
        }

        /// <summary>
        /// 添加timer
        /// </summary>
        /// <param name="timer"></param>
        public void Add(SrcUrlGroupTimer timer)
        {
            if (sugtlist.ContainsKey(timer.Name))
            {
                sugtlist[timer.Name].Union(timer);
            }
            else
            {
                sugtlist.Add(timer.Name, timer);
                timer.Elapsed += new ElapsedEventHandler(timer_RunEvent);
                timer.Start();
            }
        }

        /// <summary>
        /// 删除timer
        /// </summary>
        /// <param name="timername"></param>
        public void Dele(string timername)
        {
            if (sugtlist.ContainsKey(timername))
            {
                sugtlist[timername].Stop();
                sugtlist.Remove(timername);
            }
        }

        /// <summary>
        /// 添加 数据源接口
        /// </summary>
        /// <param name="srcUrls">接口集合</param>
        public void AddSrcUrl(Dictionary<string, ISrcUrl> srcUrls)
        {
            //转为Timer集合
            Dictionary<string, SrcUrlGroupTimer> list = SrcUrlGroupTimer.BuildList(srcUrls);
            foreach(SrcUrlGroupTimer timer in list.Values)
            {
                Add(timer); 
            }
        }

        /// <summary>
        /// 删除 数据源接口
        /// </summary>
        /// <param name="awtagname">数据源 标识或名称</param>
        public void DeleSrcUrl(string awtagname)
        {
            foreach (SrcUrlGroupTimer timer in sugtlist.Values)
            {
                timer.DeleSrcUrl(awtagname);
            }
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
        /// </summary>
        /// <param name="isu">数据接口</param>
        /// <param name="sug">定时器，用于堵塞</param>
        public void routeProcess(ISrcUrl isu, SrcUrlGroupTimer sug)
        {
            if (isu.USEPARAM)
            {
                List<AqiParam> list = (isu as IMakeParam).enumParams();
                while ((list == null) || (list.Count == 0))
                {
                    if (this.ThrowWaitEvent(isu.NAME + ":缺少参数，请输入以下参数", isu))
                    {
                        AqiManage.Remind.Log_Debug("缺少参数，进入等待", new string[] { this.name, sug.Name, isu.NAME });
                        sug.Wait();
                    }
                    else
                    {
                        AqiManage.Remind.Log_Error("缺少参数，而且无法获取忽略此数据接口", new string[] { this.name, sug.Name, isu.NAME });
                        return;
                    }
                }
                foreach (AqiParam param2 in list)
                {
                    if (sug.IsCancellationRequested)
                    {
                        break;
                    }
                    this.getProcess(isu, param2, sug);
                }
            }
            else
            {
                this.getProcess(isu, null, sug);
            }
        }

        /// <summary>
        /// 获取处理
        /// </summary>
        /// <param name="isu">数据接口</param>
        /// <param name="ap">参数，无null</param>
        /// <param name="sug">定时器</param>
        public void getProcess(ISrcUrl isu, AqiParam ap, SrcUrlGroupTimer sug)
        {
            byte[] data = null;
            try
            {
                if (ap != null)
                {
                    data = isu.getDate(ap);
                }
                else
                {
                    data = isu.getDate();
                }
            }
            catch (Exception exception)
            {
                AqiManage.Remind.Log_Error("数据获取失败，进入重试队列", new string[] { this.name, sug.Name, isu.NAME });
                this.ar.PutNew(this.Name, isu, ap, exception);
                return;
            }
            this.saveProcess(isu, ap, data);
        }

        /// <summary>
        /// 重试处理
        /// </summary>
        /// <param name="arn">重试节点</param>
        /// <returns></returns>
        public bool retryProcess(RetryNode arn)
        {
            ISrcUrl sRCURL = arn.SRCURL;
            AqiParam pARAM = arn.PARAM;
            byte[] data = null;
            try
            {
                if (pARAM != null)
                {
                    data = sRCURL.getDate(pARAM);
                }
                else
                {
                    data = sRCURL.getDate();
                }
            }
            catch (Exception exception)
            {
                AqiManage.Remind.Log_Error("数据重试失败，再入重试队列", new string[] { this.name, arn.NAME, sRCURL.NAME });
                this.ar.PutAgain(arn, exception);
                return false;
            }
            this.saveProcess(sRCURL, pARAM, data);
            arn.Reset();
            return true;
        }

        /// <summary>
        /// 保存处理
        /// </summary>
        /// <param name="isu">数据接口</param>
        /// <param name="ap">参数</param>
        /// <param name="data">数据</param>
        public void saveProcess(ISrcUrl isu, AqiParam ap, byte[] data)
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
                    node.Saved = this.ias.Save(isu, ap.Name, data);
                }
                if (node.Saved)
                {
                    AqiManage.Remind.Log_Info("数据保存成功", new string[] { this.name, isu.NAME });
                }
                else
                {
                    node.Data = data;
                    AqiManage.Remind.Log_Error("数据保存失败", new string[] { this.name, isu.NAME });
                }
            }
            catch (Exception exception)
            {
                AqiManage.Remind.Log_Error("数据保存失败", exception, new string[] { this.name, isu.NAME });
            }
        }

        #endregion

        #region ISubObject接口

        public object GetSubObject(string name)
        {
            if (this.sugtlist.ContainsKey(name))
            {
                return this.sugtlist[name];
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
            builder.Append("分组定时器：" + this.sugtlist.Count + "个");
            foreach (SrcUrlGroupTimer timer in this.sugtlist.Values)
            {
                builder.Append("\n\t\t");
                builder.Append(timer.Name);
            }
            return builder.ToString();
        }

        #endregion

    }
}
