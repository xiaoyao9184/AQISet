using System;
using System.Collections.Generic;
using AQISet.Interface;

namespace AQISet.Collection
{
    public class RunMessage
    {

        public enum RunType
        {
            OK,TIP,ERR,WAIT
        }

        #region 字段

        private RunType runType;
        private string runMsg;
        private DateTime runTime;
        private List<IThrowMessage> senderList;
        private object attachObject;

        #endregion 

        #region 属性

        public string SenderMessage
        {
            get
            {
                string str = runMsg;
                foreach (IThrowMessage itm in senderList)
                {
                    str = itm.Name + ":" + str;
                }
                return str;
            }
        }
        public string MessageString
        {
            get
            {
                return runMsg;
            }
        }
        public string TypeString
        {
            get
            {
                return runType.ToString();
            }
        }
        public string TimeString
        {
            get
            {
                return runTime.ToString();
            }
        }


        public RunType Type
        {
            get
            {
                return runType;
            }
        }

        public object AttachObject
        {
            get
            {
                return attachObject;
            }
            set
            {
                attachObject = value;
            }
        }

        #endregion

        public RunMessage(RunType runtype, string runmsg, IThrowMessage sender)
        {
            runType = runtype;
            runMsg = runmsg;
            runTime = DateTime.Now;
            senderList = new List<IThrowMessage>();
            senderList.Add(sender);
        }

        #region 方法

        /// <summary>
        /// 插入消息头
        /// </summary>
        /// <param name="header"></param>
        public void PutMessageHeader(string header){
            runMsg = header + runMsg;
        }

        /// <summary>
        /// 插入消息脚
        /// </summary>
        /// <param name="footer"></param>
        public void PutMessageFooter(string footer)
        {
            runMsg = runMsg + footer;
        }

        /// <summary>
        /// 添加消息发送者
        /// </summary>
        /// <param name="sender"></param>
        public void PutMessageSender(IThrowMessage sender)
        {
            senderList.Add(sender);
        }

        #endregion

    }
}
