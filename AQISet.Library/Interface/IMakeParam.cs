using System;
using System.Collections.Generic;

namespace AQI.Interface
{
    /// <summary>
    /// 参数制作 接口
    /// </summary>
    public interface IMakeParam
    {
        /// <summary>
        /// 参数名列表
        /// </summary>
        List<string> ParamName { get; }
        /// <summary>
        /// 参数发送方式
        /// </summary>
        AQI.AqiConstant.ParamSendType ParamSendType { get; }
        /// <summary>
        /// 枚举参数
        /// </summary>
        /// <returns>参数列表</returns>
        List<AQI.AqiParam> EnumParams();
        /// <summary>
        /// 拼接含参数Url
        /// </summary>
        /// <param name="dictParam">参数列表</param>
        /// <returns>完整的url</returns>
        string MakeUrl(Dictionary<string, string> dictParam);
        /// <summary>
        /// 拼接请求体
        /// </summary>
        /// <param name="dictParam">参数列表</param>
        /// <returns>字节数组</returns>
        byte[] MakeRequestBody(Dictionary<string, string> dictParam);
    }
}
