using System;
using System.Collections.Generic;
using AQI.Interface;

namespace AQI.Interface
{
    /// <summary>
    /// 数据源 接口
    ///     每个AQI数据源
    /// </summary>
    public interface IAqiWeb
    {
        string NAME { get; }
        string TAG { get; }
        string URL { get; }
        AQI.AqiConstant.SourceLevel SRC { get; }
        AQI.AqiConstant.DataType DAT { get; }
        

        /// <summary>
        /// 得到所有数据URL
        /// </summary>
        /// <returns></returns>
        Dictionary<string, ISrcUrl> getAllSrcUrl();

        ///// <summary>
        ///// 天
        ///// </summary>
        ///// <returns></returns>
        //Dictionary<string, ISrcUrl> getDaySrcUrl();

        ///// <summary>
        ///// 小时
        ///// </summary>
        ///// <returns></returns>
        //Dictionary<string, ISrcUrl> getHourSrcUrl();

        /// <summary>
        /// JSON配置文件路径
        /// </summary>
        /// <returns></returns>
        string getJsonFile();
    }
}
