using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQI.Interface
{
    /// <summary>
    /// 参数数据接口 接口
    ///     扩展ISrcUrl
    /// </summary>
    public interface ISrcUrlParam
    {
        /// <summary>
        /// 是否忽略空参数
        /// </summary>
        bool ParamIgnoreEmpty { get; }
        /// <summary>
        /// 参数名列表
        /// </summary>
        List<string> ParamName { get; }
        /// <summary>
        /// 枚举参数
        /// </summary>
        /// <returns>参数列表</returns>
        List<AQI.AqiParam> EnumParams();
        /// <summary>
        /// 根据参数获取数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        byte[] GetDate(AQI.AqiParam param);
    }
}
