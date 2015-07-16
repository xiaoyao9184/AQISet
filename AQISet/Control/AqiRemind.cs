using AQISet.Collection;
using AQISet.Interface;
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
            appender.Layout = new PatternLayout("记录时间：%date 线程ID:[%thread] 日志级别：%-5level 出错类：%logger property:[%property{NDC}] - 描述：%message%newline");
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
        
        private void Email()
        {
        }

        #endregion

        #region 日志

        private string getLogFile()
        {
            string location = base.GetType().Assembly.Location;
            int length = location.LastIndexOf('\\');
            return (location.Substring(0, length) + @"\AqiSet.log");
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

