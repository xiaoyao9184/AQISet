using AQISet.Collection;
using AQISet.Interface;
using Helper.Email;
using Helper.Util.IO;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using System;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace AQISet.Control
{

    /// <summary>
    /// 提醒者
    /// </summary>
    public sealed class AqiRemind : IStatus
    {

        #region COM

        [DllImport("Kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);

        #endregion

        #region 单例

        private static readonly AqiRemind _instance;

        /// <summary>
        /// 单例属性
        /// </summary>
        public static AqiRemind Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 线程安全单例
        /// </summary>
        static AqiRemind()
        {
            _instance = new AqiRemind();
        }

        private AqiRemind()
        {
            RollingFileAppender appender = new RollingFileAppender();
            appender.File = this.getLogFile();
            appender.AppendToFile = true;
            appender.RollingStyle = RollingFileAppender.RollingMode.Date;
            appender.StaticLogFileName = true;
            appender.Layout = new PatternLayout(AqiManage.Setting["AqiRemind.LogLayout"]);
            LevelRangeFilter filter = new LevelRangeFilter();
            filter.LevelMax = Level.Fatal;
            filter.LevelMin = Level.Debug;
            appender.AddFilter(filter);
            appender.ActivateOptions();
            BasicConfigurator.Configure(appender);
            this.log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        #endregion

        #region 字段

        private static string tag = "AqiRemind";
        private ILog log = null;

        #endregion

        #region 提醒

        private void Beep()
        {
            SystemSounds.Question.Play();
        }

        public void Ring()
        {
            bool flag = true;
            if (flag)
            {
                this.Beep();
            }
        }
        
        private void Email(object obj)
        {
            try
            {
                string mailSubject = "";
                string mailBody = "";

                if (obj == null)
                {
                    mailSubject = "AQISet日志";
                    mailBody = FileReadSaveUtil.ReadText(this.getLogFile());
                }
                else if (obj is IStatus)
                {
                    IStatus s = (obj as IStatus);
                    mailSubject = "AQISet状态_" + s.Name;
                    mailBody = s.GetInfo();
                }

                EmailHelper emh = new EmailHelper();
                emh.mailFrom = AqiManage.Setting["AqiRemind.EmailFrom"];    //发送人的邮箱地址
                emh.mailPwd = AqiManage.Setting["AqiRemind.EmailPwd"];      //发送人邮箱的密码
                emh.mailSubject = mailSubject;                              //邮件主题;
                emh.mailBody = mailBody;                                    //邮件内容;
                emh.isbodyHtml = true;                                      //是否是HTML
                emh.host = AqiManage.Setting["AqiRemind.EmailHost"];        //服务器
                emh.mailToArray = new string[] { AqiManage.Setting["AqiRemind.EmailTo"] };//接收者邮件集合
                if (emh.Send())
                {
                    AqiManage.Remind.Log_Error("Email发送成功", tag);
                }
                else
                {
                    AqiManage.Remind.Log_Error("Email发送失败", tag);
                }
            }
            catch(System.Exception ex)
            {
                Beep();
                AqiManage.Remind.Log_Error("Email生成失败", ex, tag);
            }
        }

        #endregion

        #region 日志

        private string getLogFile()
        {
            string loc = AqiManage.Setting["AqiRemind.LogLocation"];
            if(String.IsNullOrEmpty(loc))
            {
                string location = base.GetType().Assembly.Location;
                int length = location.LastIndexOf('\\');
                return (location.Substring(0, length) + @"\AqiSet.log");
            }
            else if (loc.StartsWith(@"\") || loc.StartsWith(@"/"))
            {
                string location = base.GetType().Assembly.Location;
                int length = location.LastIndexOf('\\');
                return (location.Substring(0, length) + loc);
            }
            else
            {
                return loc;
            }
        }

        private string messageLevel(string message, params string[] names)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(String.Join(":", names));
            builder.Append(message);
            return builder.ToString();
        }

        public void Log_RunMessage(RunMessage msg)
        {
            switch (msg.Type)
            {
                case RunMessage.RunType.OK:
                    this.log.Debug(msg.MessageString);
                    break;

                case RunMessage.RunType.TIP:
                    this.log.Debug(msg.MessageString);
                    break;

                case RunMessage.RunType.ERR:
                    this.log.Error(msg.MessageString);
                    break;

                case RunMessage.RunType.WAIT:
                    this.log.Error(msg.MessageString);
                    break;
            }
        }

        public void Log_Error(string message, Exception ex, params string[] names)
        {
            this.log.Error(this.messageLevel(message, names), ex);
        }

        public void Log_Error(string message, params string[] names)
        {
            this.log.Error(this.messageLevel(message, names));
        }

        public void Log_Debug(string message, params string[] names)
        {
            this.log.Debug(this.messageLevel(message, names));
        }

        public void Log_Info(string message, params string[] names)
        {
            this.log.Info(this.messageLevel(message, names));
        }

        #endregion

        #region IStatus接口

        public string Name
        {
            get
            {
                return tag;
            }
        }

        public string GetInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("提醒信息：");
            builder.Append("\n\t");
            builder.Append(this.log.Logger.Repository.GetAppenders().Length + "个日志适配器；");

            return builder.ToString();
        }

        #endregion

    }
}

