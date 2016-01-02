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

        #region IAqiWeb枚举

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

        #region ASrcUrl通用枚举

        /// <summary>
        /// HTTP获取类型
        /// </summary>
        public enum HttpType
        {
            GET, POST
        }

        /// <summary>
        /// 更新间隔
        /// </summary>
        public enum SourceUpdataInterval
        {
            NONE, DAY7, DAY, HOUR12, HOUR, MINUTE30, MINUTE
        }

        #endregion

        #region IMakeParam枚举

        /// <summary>
        /// 参数类型
        /// </summary>
        public enum ParamSendType
        {
            NONE, GET, POST
        }

        #endregion

        #region AParamSrcUrl枚举

        /// <summary>
        /// 参数来源
        /// </summary>
        public enum ParamSourceType
        {
            NONE,       //无
            JSON,       //JSON文件
            ISrcUrl     //ISrcUrl接口
        }

        /// <summary>
        /// 参数过滤方式
        /// </summary>
        public enum ParamFilterType
        {
            NONE,       //不过滤
            OnceAgain,  //循环过滤：ONCE标识的只执行一次；AGAIN标识的循环执行
            InTurn      //循环过滤：按分组循环执行
        }

        /// <summary>
        /// URL参数形式
        /// </summary>
        public enum ParamUrlType
        {
            KEY_VALUE,  //键值对
            PATH        //路径
        }

        /// <summary>
        /// HttpBody参数形式
        /// </summary>
        public enum ParamBodyType
        {
            HTTP_FORM,
            TEXT,
            BIN_BASE64
        }

        #endregion

        #region AParamSrcUrl常量

        public const string PARAM_HEADER = "header";

        public const string PARAM_BODY = "body";

        #endregion

    }
}
