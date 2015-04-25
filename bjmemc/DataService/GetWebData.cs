using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bjmemc.Abstract;
using Helper.WCFbin;
using System.Security.Cryptography;
using System.IO;

namespace bjmemc.DataService
{
    public class GetWebData : bjmemcSrcUrl
    {

        #region 静态变量

        private static string Tag = "GetWebData";
        private static string Name = "北京站点1小时AQI";
        private static string Url = "http://zx.bjmemc.com.cn/DataService.svc";
        private static AQI.AqiConstant.SourceUpdataInterval Sui = AQI.AqiConstant.SourceUpdataInterval.HOUR;

        #endregion

        #region 属性

        public override string TAG
        {
            get
            {
                return Tag;
            }
        }
        public override string NAME
        {
            get
            {
                return Name;
            }
        }
        public override string URL
        {
            get
            {
                return Url;
            }
        }
        public override AQI.AqiConstant.SourceUpdataInterval SUI
        {
            get
            {
                return Sui;
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
        public override byte[] extractData(byte[] responsebody)
        {
            //获取WCF Message
            string strWCFMsg = mh.GetWcfBinaryMessageAsText(responsebody);
            
            //获取WCF Content Binary（=WCF Message Body）
            byte[] wcfbin = WCFMessageUtil.getWCFBinByWCFMsg(strWCFMsg, TAG, CF);

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
//                 managed = new AesManaged
//                 {
//                     Key = bytes.GetBytes(managed.KeySize / 8),
//                     IV = bytes.GetBytes(managed.BlockSize / 8)
//                 };
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
