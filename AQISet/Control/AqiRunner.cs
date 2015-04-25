using System;
using System.Timers;
using System.Collections.Generic;
using AQI.Interface;
using AQI.Abstract;
using AQISet.Interface;
using AQISet.Collection;
using AQI;
using AQISet.Control.Saver;

namespace AQISet.Control
{
    /// <summary>
    /// 运行者
    /// </summary>
    public class AqiRunner : IThrowMessage
    {

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

        #region 属性

        public string Name
        {
            get
            {
                return name;
            }
        }

        #endregion

        #region 构造

        /// <summary>
        /// 默认构造
        ///     合并运行模式使用
        /// </summary>
        /// <param name="aqiManage"></param>
        /// <param name="srcUrls"></param>
        public AqiRunner(AqiManage aqiManage, Dictionary<string, ISrcUrl> srcUrls)
        {
            name = "DefaultRunner";
            sugtlist = SrcUrlGroupTimer.BuildList(srcUrls);
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
        public AqiRunner(AqiManage aqiManage, Dictionary<string, ISrcUrl> srcUrls, string strName)
        {
            name = strName;
            sugtlist = SrcUrlGroupTimer.BuildList(srcUrls);
            ias = aqiManage.AqiSave;
            an = aqiManage.AqiNote;
            ar = aqiManage.AqiRetry;
        }

        #endregion

        #region 方法

        #region 基本控制

        /// <summary>
        /// 运行全部定时器
        /// </summary>
        public void RunAll()
        {
            foreach(SrcUrlGroupTimer sug in sugtlist.Values)
            {
                sug.StartFirst(timerRun);
            }
            ThrowEvent(RunMessage.RunType.TIP, sugtlist.Values.Count + "个数据源分组定时器，全部启用");
        }

        /// <summary>
        /// 结束全部定时器
        /// </summary>
        public void EndAll()
        {
            foreach (SrcUrlGroupTimer sug in sugtlist.Values)
            {
                sug.Enabled = false;
            }
            ThrowEvent(RunMessage.RunType.TIP, sugtlist.Values.Count + "个数据源分组定时器，全部结束");
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="timername">定时器 名称</param>
        public void Run(string timername)
        {
            if (sugtlist.ContainsKey(timername))
            {
                ThrowEvent(RunMessage.RunType.TIP, "开始运行定时器:" + timername);
                sugtlist[timername].Start();
            }
        }

        /// <summary>
        /// 结束
        /// </summary>
        /// <param name="timername">定时器 名称</param>
        public void End(string timername)
        {
            if (sugtlist.ContainsKey(timername))
            {
                ThrowEvent(RunMessage.RunType.TIP, "结束运行定时器:" + timername);
                sugtlist[timername].Stop();
            }
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
                timer.StartFirst(timerRun);
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

        #region timer回调

        /// <summary>
        /// 运行处理
        /// </summary>
        /// <param name="source">定时器</param>
        /// <param name="e">定时器参数</param>
        private void timerRun(object source, System.Timers.ElapsedEventArgs e)
        {
            SrcUrlGroupTimer sug = source as SrcUrlGroupTimer;
            ThrowEvent(RunMessage.RunType.TIP, sug.Name + ":定时任务开始执行");

            sug.Handle(this);
            //foreach (ISrcUrl isu in sug.SrcUrl.Values)
            //{
            //    routeProcess(isu, sug);
            //}

            ThrowEvent(RunMessage.RunType.TIP, sug.Name + ":定时任务开始休眠");
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
                IMakeParam ip = isu as IMakeParam;
                List<AqiParam> paramList = ip.enumParams();

                while (paramList == null || paramList.Count == 0)
                {
                    bool bEvent = ThrowWaitEvent(isu.NAME + ":缺少参数，请输入以下参数", isu);
                    if (bEvent)
                    {
                        //若接受事件
                        //由用户生成参数
                        //TEST等待用户输入参数
                        sug.Wait();
                    }
                    else
                    {
                        //不接受事件则无法输入参数，忽略
                        ThrowEvent(RunMessage.RunType.TIP, isu.NAME + ":缺少参数，而且无法获取忽略此数据接口");
                        return;
                    }
                }
                foreach (AqiParam ap in paramList)
                {
                    getProcess(isu, ap);
                }
            }
            else
            {
                getProcess(isu, null);
            }
        }

        /// <summary>
        /// 获取处理
        /// </summary>
        /// <param name="isu">数据接口</param>
        /// <param name="ap">参数，无null</param>
        public void getProcess(ISrcUrl isu, AqiParam ap)
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
            catch (Exception ex)
            {
                ThrowEvent(RunMessage.RunType.ERR, isu.NAME + ":数据获取失败，进入重试队列");
                //入重试队列
                ar.PutNew(isu, ap, ex);
                return;
            }
            saveProcess(isu, ap, data);
        }

        /// <summary>
        /// 保存处理
        /// </summary>
        /// <param name="isu">数据接口</param>
        /// <param name="ap">参数</param>
        /// <param name="data">数据</param>
        public void saveProcess(ISrcUrl isu, AqiParam ap, byte[] data)
        {
            //统计信息
            NoteNode n = an.AddNew(isu, ap, data);
            //保存
            if(ap == null)
            {
                n.Saved = ias.Save(isu, data);              
            }
            else
            {
                n.Saved = ias.Save(isu, ap.Name, data);
            }
            
            if (n.Saved)
            {
                ThrowEvent(RunMessage.RunType.OK, isu.IAW.NAME + ":" + isu.NAME + ":数据获取成功");
            }
            else
            {
                ThrowEvent(RunMessage.RunType.ERR, isu.NAME + ":数据获取失败");
            }
        }

        #endregion

        #endregion

    }
}
