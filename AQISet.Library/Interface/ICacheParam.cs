using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQI.Interface
{
    /// <summary>
    /// 缓存参数 接口
    /// </summary>
    public interface ICacheParam
    {
        /// <summary>
        /// 参数来源类型
        /// </summary>
        AQI.AqiConstant.ParamSourceType ParamSourceType { get; }
        /// <summary>
        /// 参数缓存 列表
        /// </summary>
        List<AQI.AqiParam> ParamCache { get; }
        /// <summary>
        /// 参数过滤方式
        /// </summary>
        AQI.AqiConstant.ParamFilterType ParamFilterType { get; }
        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns>true过期；false未过期</returns>
        bool IsParamsExpired();
        /// <summary>
        /// 加载参数
        /// </summary>
        /// <returns>是否成功</returns>
        bool LoadParams();
        /// <summary>
        /// 过滤参数
        /// </summary>
        /// <returns>过滤后的缓存参数</returns>
        List<AQI.AqiParam> FilterParams();

    }
}
