using System;
using System.Collections.Generic;

namespace AQI.Interface
{
    /// <summary>
    /// 参数制作 接口
    ///     自行扩展ISrcUrl.GetData
    /// </summary>
    public interface IMakeParam
    {
        /// <summary>
        /// 参数发送方式
        /// </summary>
        AQI.AqiConstant.ParamSendType ParamSendType { get; }
        /// <summary>
        /// 拼接含参数Url
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>完整的url</returns>
        string MakeUrl(AqiParam param);
        /// <summary>
        /// 拼接请求体
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns>字节数组</returns>
        byte[] MakeRequestBody(AqiParam param);
    }
}
