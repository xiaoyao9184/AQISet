using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace AQI
{
    /// <summary>
    /// 常用常量
    /// </summary>
    public class AqiConstant
    {

        #region 常用时间（单位/秒）

        public const double DAY7 = 7 * 24 * 60 * 60;
        public const double DAY = 24 * 60 * 60;
        public const double HOUR12 = 12 * 60 * 60;
        public const double HOUR = 60 * 60;
        public const double MINUTE30 = 30 * 60;
        public const double MINUTE = 60;

        #endregion

        #region 数据配置

        /// <summary>
        /// HTTP获取类型
        /// </summary>
        public enum HttpType
        {
            GET, POST
        }

        /// <summary>
        /// 参数类型
        /// </summary>
        public enum ParamType
        {
            NONE, GET, POST
        }

        /// <summary>
        /// 更新间隔
        /// </summary>
        public enum SourceUpdataInterval
        {
            NONE, DAY7, DAY, HOUR12, HOUR, MINUTE30, MINUTE
        }

        /// <summary>
        /// 数据源级别
        /// </summary>
        public enum SourceLevel
        {
            NONE, OTHER, NATIONAL, PROVINCIAL, CITY, AREA
        }

        /// <summary>
        /// 数据类型
        /// </summary>
        public enum DataType
        {
            NONE, OTHER, BIN, TEXT, XML, JSON, WCF
        }

        #endregion

    }
}
