using System;
using System.Collections.Generic;

namespace AQI.Interface
{
    /// <summary>
    /// 参数制作 接口
    /// </summary>
    public interface IMakeParam
    {

        #region 属性

        /// <summary>
        /// 参数承载方式
        /// </summary>
        AQI.AqiConstant.ParamType PT { get; }
        
        /// <summary>
        /// 参数名列表
        /// </summary>
        List<string> PL { get; }

        #endregion

        #region 方法

        /// <summary>
        /// 枚举参数
        /// </summary>
        /// <returns></returns>
        List<AqiParam> enumParams();

        /// <summary>
        /// 拼接含参数URL
        /// </summary>
        /// <param name="dictParam">参数列表</param>
        string makeUrl(Dictionary<string, string> dictParam);

        /// <summary>
        /// 拼接请求体
        /// </summary>
        /// <param name="dictParam">参数列表</param>
        /// <returns></returns>
        byte[] makeRequestBody(Dictionary<string, string> dictParam);

        #endregion

    }
}
