using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQI.Interface
{
    /// <summary>
    /// 缓存参数 接口
    ///     扩展ISrcUrlParam.EnumParams
    /// </summary>
    public interface ICacheParam
    {
        /// <summary>
        /// 参数缓存列表
        /// </summary>
        List<AQI.AqiParam> ParamCache { get; }
        /// <summary>
        /// 参数来源类型
        /// </summary>
        AQI.AqiConstant.ParamSourceType ParamSourceType { get; }
        /// <summary>
        /// 参数过滤方式
        /// </summary>
        AQI.AqiConstant.ParamFilterType ParamFilterType { get; }
        /// <summary>
        /// 参数路径
        ///     JSON参数文件路径
        /// </summary>
        /// <returns>Json路径</returns>
        string GetJsonFile();
        /// <summary>
        /// 检查过期
        ///     缓存参数是否过期
        /// </summary>
        /// <returns>true过期；false未过期</returns>
        bool IsParamsExpired();
        /// <summary>
        /// 加载参数
        ///     加载参数到缓存
        /// </summary>
        /// <returns>true成功；false不成功</returns>
        bool LoadParams();
        /// <summary>
        /// 过滤参数
        ///     筛选缓存中的参数
        /// </summary>
        /// <returns>参数列表</returns>
        List<AQI.AqiParam> FilterParams();
    }
}
