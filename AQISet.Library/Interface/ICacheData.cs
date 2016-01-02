using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helper.Util.HTTP;

namespace AQI.Interface
{
    /// <summary>
    /// 缓存数据 接口
    /// </summary>
    public interface ICacheData
    {
        /// <summary>
        /// 参数数据
        /// </summary>
        HttpData Data { get; set; }

    }
}
