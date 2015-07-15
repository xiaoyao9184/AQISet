using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQI.Interface
{
    /// <summary>
    /// SrcUrl参数解析 接口
    ///     仅对继承AParamSrcUrl类，并实现此接口的类有效
    /// </summary>
    public interface IParseSrcUrlParam
    {
        /// <summary>
        /// 参数SrcUrl来源
        /// </summary>
        ISrcUrl ParamSrcUrl { get; }
        /// <summary>
        /// 解析参数
        /// </summary>
        List<AqiParam> ParseParam(byte[] data);
    }
}
