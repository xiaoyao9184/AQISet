using System;
using System.Collections.Generic;

namespace AQI.Interface
{
    /// <summary>
    /// 数据接口 接口
    ///     每个Url接口
    /// </summary>
    public interface ISrcUrl
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 内部标签
        /// </summary>
        string Tag { get; }
        /// <summary>
        /// 数据接口地址
        /// </summary>
        string Url { get; }
        /// <summary>
        /// IAqiWeb接口
        /// </summary>
        IAqiWeb IAW { get;set; }
        /// <summary>
        /// 更新间隔
        /// Update Interval
        /// </summary>
        double UDI { get; }
        /// <summary>
        /// 是否使用参数
        ///     强制关闭参数
        /// </summary>
        bool UseParam { get; }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        byte[] GetDate();
    }
}
