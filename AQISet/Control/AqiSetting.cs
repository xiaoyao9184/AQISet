using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helper.Setting;

namespace AQISet.Control
{
    public class AqiSetting : JsonSettingHelper
    {

        private const string DEFAULT_FILE = @"\JSON\cfg.json";
        private const string DEFAULT_PROPERTY = "Setting";

        #region 单例

        private static readonly AqiSetting _instance;

        /// <summary>
        /// 单例属性
        /// </summary>
        public static AqiSetting Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 线程安全单例
        /// </summary>
        static AqiSetting()
        {
            _instance = new AqiSetting();
        }

        private AqiSetting()
            : base(AqiSetting.GetDefaultSettingJsonFile(), DEFAULT_PROPERTY)
        {

        }

        #endregion

        /// <summary>
        /// 获取默认 JSON 文件
        /// </summary>
        /// <returns></returns>
        private static string GetDefaultSettingJsonFile()
        {
            string exeFile = typeof(AqiSetting).Assembly.Location;
            int p = exeFile.LastIndexOf('\\');
            string dllPath = exeFile.Substring(0, p);
            string jsonFile = dllPath + DEFAULT_FILE;

            return jsonFile;
        }
    }
}
