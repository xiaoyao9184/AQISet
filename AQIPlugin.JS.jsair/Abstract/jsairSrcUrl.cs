using AQI;
using AQI.Abstract;
using AQI.Interface;
using Helper.Util.HTTP;
using jsair.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace jsair.Abstract
{
    /// <summary>
    /// 江苏数据接口
    ///     通用抽象类
    /// </summary>
    public abstract class jsairSrcUrl : AParamSrcUrl, IExtractData
    {

        protected string token = "e7e25f17613a024693c36c40455e43a0";

        #region 属性

        /// <summary>
        /// 无参数
        /// </summary>
        public override List<string> ParamName
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 使用POST方式
        /// </summary>
        public override AQI.AqiConstant.ParamSendType ParamSendType
        {
            get
            {
                return AQI.AqiConstant.ParamSendType.GET;
            }
        }

        #endregion

        #region 方法

        #region IMakeParam接口

        /// <summary>
        /// 拼接含参数Url
        ///     .重写
        /// </summary>
        /// <remarks>
        /// 将token装入URL中
        /// </remarks>
        /// <param name="param">参数列表</param>
        /// <returns>完整URL</returns>
        public override string MakeUrl(AqiParam param)
        {
            return string.Format(Url, param["area"], token);
        }

        #endregion

        #region IExtractData接口

        /// <summary>
        /// 数据提取
        ///     可以重写
        /// </summary>
        /// <see cref="getData"/>
        /// <param name="requestbody"></param>
        /// <returns></returns>
        public virtual byte[] ExtractData(byte[] responsebody)
        {
            //获取WCF Message
            char c = token[0];
            string t = token.Replace(c, 't');

            string base64 = Encoding.UTF8.GetString(responsebody);

            AESCryptoService aes = new AESCryptoService(t);
            string str = aes.DecryptString(base64);
            
            byte[] bytes = Encoding.UTF8.GetBytes(str);

            return bytes;
        }

        #endregion

        #endregion

    }
}
