using AQI;
using AQI.Abstract;
using Helper.Util.HTTP;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace YNAS.Abstract
{
    public abstract class queryCityAQIInfo_POST : AParamSrcUrl
    {

        #region 重写方法

        #region IMakeParam接口

        /// <summary>
        /// 拼接请求头
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// 读取参数，若不存在‘Content-Type’则添加默认‘application/x-www-form-urlencoded; charset=UTF-8’
        /// </remarks>
        /// <param name="param"></param>
        /// <returns></returns>
        public override Dictionary<string, string> MakeRequestHeader(AqiParam param)
        {
            Dictionary<string, string> header = base.MakeRequestHeader(param);
            if (!header.ContainsKey("Content-Type"))
            {
                header.Add("Content-Type", @"application/x-www-form-urlencoded; charset=UTF-8");
            }
            return header;
        }

        #endregion

        #endregion

    }
}
