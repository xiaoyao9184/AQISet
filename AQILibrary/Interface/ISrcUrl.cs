using System;
using System.Collections.Generic;

namespace AQI.Interface
{
    /// <summary>
    /// 数据接口 接口
    ///     每个URL接口
    /// </summary>
    public interface ISrcUrl
    {

        #region 属性

        /// <summary>
        /// 名称
        /// </summary>
        string NAME { get; }
        
        /// <summary>
        /// 内部标签
        /// </summary>
        string TAG { get; }
        
        /// <summary>
        /// 数据接口地址
        /// </summary>
        string URL { get; }
        
        /// <summary>
        /// IAqiWeb接口
        /// </summary>
        IAqiWeb IAW { get;set; }

        /// <summary>
        /// 更新间隔
        /// Update interval
        /// </summary>
        double UDI { get; }

        /// <summary>
        /// 是否使用参数
        /// </summary>
        bool USEPARAM { get; }

        #endregion

        #region 方法

        byte[] getDate();

        byte[] getDate(Dictionary<string, string> dictParam);
    
        #endregion

    }
}
