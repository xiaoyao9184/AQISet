using System;
using System.IO;
using System.Net;

namespace Helper.Util.HTTP
{
    /// <summary>
    /// 发送请求
    /// xiaoyao9184
    /// 1.3 2015-01-22 * get chunked encode
    /// 1.2 2014-12-30 * Add to "Helper" Class Library
    /// 1.1 2014-06-20 + try catch;StatusCode;timeout
    /// 1.0 2014-06-16
    /// </summary>
    public class HttpUtil
    {
        private const int TimeOut = 5000;
        /// <summary>
        /// post方法得到响应体
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="bBody"></param>
        /// <returns></returns>
        public static byte[] postRequest(string strUrl, byte[] bBody)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                req.Timeout = TimeOut;
                req.Method = "POST";
                req.Accept = "*/*";
                //req.Headers["Accept"] = "*/*";
                req.Headers["Accept-Language"] = "zh-CN";
                req.Headers["Accept-Encoding"] = "identity";
                req.Headers["Pragma"] = "no-cache";
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.114 Safari/537.36";
                req.ContentType = "application/msbin1";
                req.ContentLength = bBody.Length;

                Stream reqStream = req.GetRequestStream();
                reqStream.Write(bBody, 0, bBody.Length);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                if (response.StatusCode!= HttpStatusCode.OK)
                    return null;
                Stream responseStream = response.GetResponseStream();

                byte[] bResponseBody = new byte[response.ContentLength];
                BinaryReader r = new BinaryReader(responseStream);
                bResponseBody = r.ReadBytes((int)response.ContentLength);
                return bResponseBody;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// get方法得到响应体
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public static byte[] getRequest(string strUrl)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                req.Timeout = TimeOut;
                req.Method = "GET";
                req.Accept = "*/*";
                //req.Headers["Accept"] = "*/*";
                req.Headers["Accept-Language"] = "zh-CN";
                req.Headers["Accept-Encoding"] = "identity";
                req.Headers["Pragma"] = "no-cache";
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.114 Safari/537.36";

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                    return null;
                Stream responseStream = response.GetResponseStream();
                byte[] bResponseBody = null;

                string chunked = response.Headers[HttpResponseHeader.TransferEncoding];

                //chunked编码
                if (response.ContentLength == -1)
                {
                    int bufferLength = 1024;
                    byte[] buffer = new byte[bufferLength];
                    Stream bufferStream = new MemoryStream();

                    int len = responseStream.Read(buffer, 0, bufferLength);
                    while (len > 0)
                    {
                        bufferStream.Write(buffer, 0, len);
                        len = responseStream.Read(buffer, 0, bufferLength);
                    }
                    bResponseBody = new byte[bufferStream.Length];
                    bufferStream.Seek(0, SeekOrigin.Begin);
                    bufferStream.Read(bResponseBody, 0, bResponseBody.Length);
                    bufferStream.Close();
                }
                else
                {
                    bResponseBody = new byte[response.ContentLength];
                    BinaryReader r = new BinaryReader(responseStream);
                    bResponseBody = r.ReadBytes((int)response.ContentLength);
                }
                return bResponseBody;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
