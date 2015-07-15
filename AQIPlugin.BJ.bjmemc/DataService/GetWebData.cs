using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using Helper.WCFbin;
using bjmemc.Abstract;

namespace bjmemc.DataService
{
    public class GetWebData : bjmemcSrcUrl
    {

        #region 静态变量

        private static string tag = "GetWebData";
        private static string name = "北京站点1小时AQI";
        private static string url = "http://zx.bjmemc.com.cn/DataService.svc";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.HOUR;

        #endregion

        #region 属性

        public override string Tag
        {
            get
            {
                return tag;
            }
        }
        public override string Name
        {
            get
            {
                return name;
            }
        }
        public override string Url
        {
            get
            {
                return url;
            }
        }
        public override AQI.AqiConstant.SourceUpdataInterval SUI
        {
            get
            {
                return sui;
            }
        }

        #endregion

        #region 方法

        #region IExtract接口

        /// <summary>
        /// 数据提取
        ///     重写
        /// </summary>
        /// <see cref="getData"/>
        /// <param name="requestbody"></param>
        /// <returns></returns>
        public override byte[] ExtractData(byte[] responsebody)
        {
            //获取WCF Message
            string strWCFMsg = mh.GetWcfBinaryMessageAsText(responsebody);
            
            //获取WCF Content Binary（=WCF Message Body）
            byte[] wcfbin = WCFMessageUtil.getWCFBinByWCFMsg(strWCFMsg, tag, CF);

            //解密
            string jsonString = DecryptAES(Encoding.UTF8.GetString(wcfbin), "qjkHuIy9D/9i=", "Mi9l/+7Zujhy12se6Yjy111A");

            return Encoding.UTF8.GetBytes(jsonString);
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// AES解密
        /// 移植自BEPB
        /// 2015-03-01
        /// </summary>
        /// <param name="decryptString"></param>
        /// <param name="decryptKey"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private static string DecryptAES(string decryptString, string decryptKey, string salt)
        {
            AesManaged managed = null;
            MemoryStream stream = null;
            CryptoStream stream2 = null;
            string str;
            try
            {
                Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(decryptKey, Encoding.UTF8.GetBytes(salt));

                managed = new AesManaged();
                managed.Key = bytes.GetBytes(managed.KeySize / 8);
                managed.IV = bytes.GetBytes(managed.BlockSize / 8);

                stream = new MemoryStream();
                stream2 = new CryptoStream(stream, managed.CreateDecryptor(), CryptoStreamMode.Write);
                byte[] buffer = Convert.FromBase64String(decryptString);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                str = Encoding.UTF8.GetString(stream.ToArray(), 0, stream.ToArray().Length);
            }
            catch
            {
                str = decryptString;
            }
            finally
            {
                if (stream2 != null)
                {
                    stream2.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                if (managed != null)
                {
                    managed.Clear();
                }
            }
            return str;
        }

        #endregion

        #endregion

    }
}
