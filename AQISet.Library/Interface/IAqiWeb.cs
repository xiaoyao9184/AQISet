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
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 标签
        /// </summary>
        string Tag { get; }
        /// <summary>
        /// URL
        /// </summary>
        string Url { get; }
        /// <summary>
        /// SrcUrl命名空间
        /// </summary>
        string[] SrcUrlNameSpace { get; }
        /// <summary>
        /// 数据级别
        /// </summary>
        AQI.AqiConstant.SourceLevel SRC { get; }
        /// <summary>
        /// 数据类型
        /// </summary>
        AQI.AqiConstant.DataType DAT { get; }
        /// <summary>
        /// 得到所有数据Url
        /// </summary>
        /// <returns></returns>
        Dictionary<string, ISrcUrl> GetAllSrcUrl();
        /// <summary>
        /// JSON配置文件路径
        /// </summary>
        /// <returns></returns>
        string GetJsonFile();
    }
}
