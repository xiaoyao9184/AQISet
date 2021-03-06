﻿using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Reflection;

namespace Helper.Util.HTTP
{
    /// <summary>
    /// HTTP工具
    /// xiaoyao9184
    /// 1.5 2016-01-02 add HttpData
    /// 1.4 2015-07-24 add custom request header
    /// 1.3 2015-07-16 fix stream cant write
    /// 1.2 2015-07-11 fix thread bug
    /// 1.1 2015-07-07 Fix createGetRequest lost set Method to GET
    /// 1.0 2015-01-27
    /// </summary>
    public class HttpUtilV2
    {

        #region 常用字符

        /// <summary>
        /// 常用GET方法RequestHeader
        /// </summary>
        private static readonly Dictionary<string, string> oftenRequestHeader = new Dictionary<string, string>()
        {
            { "Method", "GET" },
            { "Accept", "*/*" },
            { "Accept-Language", "zh-CN" },
            { "Accept-Encoding", "identity" },
            { "Pragma", "no-cache" },
            { "UserAgent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.114 Safari/537.36" },
        };

        /// <summary>
        /// 常用压缩字符
        /// </summary>
        private static readonly Dictionary<string, string> oftenEncoding = new Dictionary<string, string>()
        {
            { "All", "*" },
            { "Normal", "identity" },
            { "Gzip", "gzip" },
            { "Compress", "compress" },
            { "Sdch", "sdch" },
            { "Deflate", "deflate" }
        };

        private static readonly Dictionary<string, string> oftenContentType = new Dictionary<string, string>()
        {
            { "All", "*" },
            { "WCF", "application/msbin1" }
        };

        #endregion

        #region Request

        /// <summary>
        /// 创建 HTTP请求 对象
        /// </summary>
        /// <param name="strUrl">URI/URL</param>
        /// <param name="dictHeader">头参数</param>
        /// <returns></returns>
        public static HttpWebRequest createRequest(string strUrl, Dictionary<string, string> dictHeader)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(strUrl);

            foreach (KeyValuePair<string, string> kv in dictHeader)
            {
                Type Ts = req.GetType();
                PropertyInfo Pt = Ts.GetProperty(kv.Key);
                if (Pt != null)
                {
                    object v = Convert.ChangeType(kv.Value, Pt.PropertyType);
                    Pt.SetValue(req, v, null);
                }
                else
                {
                    req.Headers[kv.Key] = kv.Value;
                }
            }

            return req;
        }

        /// <summary>
        /// 创建 GET方法 HTTP请求 对象
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public static HttpWebRequest createGetRequest(string strUrl)
        {
            Dictionary<string, string> dictHeader = new Dictionary<string, string>(oftenRequestHeader);
            dictHeader["Method"] = "GET";
            return createRequest(strUrl, dictHeader);
        }

        /// <summary>
        /// 创建 POST方法 HTTP请求 对象
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public static HttpWebRequest createPostRequest(string strUrl)
        {
            Dictionary<string, string> dictHeader = new Dictionary<string, string>(oftenRequestHeader);
            dictHeader["Method"] = "POST";
            return createRequest(strUrl, dictHeader);
        }

        /// <summary>
        /// 修改RequestHeader中对字符合法适配HttpWebRequest
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        private static Dictionary<string, string> changeHeader(Dictionary<string, string> header)
        {
            if(header.ContainsKey("Content-Type"))
            {
                header.Add("ContentType", header["Content-Type"]);
                header.Remove("Content-Type");
            }

            return header;
        }

        #endregion

        #region Response

        public static HttpWebResponse createResponse(string strUrl, Dictionary<string, string> requestHeader, int iTimeOut, byte[] bContentBody)
        {
            HttpWebRequest req = null;
            if (requestHeader == null || requestHeader.Count == 0)
            {
                req = createGetRequest(strUrl);
            }
            else
            {
                Dictionary<string, string> dictHeader = new Dictionary<string, string>(oftenRequestHeader);
                foreach (KeyValuePair<string, string> kv in requestHeader)
                {
                    if (dictHeader.ContainsKey(kv.Key))
                    {
                        dictHeader[kv.Key] = kv.Value;
                    }
                    else
                    {
                        dictHeader.Add(kv.Key, kv.Value);
                    }
                }

                req = createRequest(strUrl, changeHeader(dictHeader));
            }
            
            if (iTimeOut > 0)
            {
                req.Timeout = iTimeOut;
            }
            if (bContentBody != null)
            {
                req.Method = "POST";
                //设置POST数据格式长度
                req.ContentLength = bContentBody.Length;
                //写入POST数据
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(bContentBody, 0, bContentBody.Length);
            }


            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            return response;
        }

        /// <summary>
        /// 获取 GET方法 HTTP响应 对象
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="iTimeOut">仅仅大于0时有效</param>
        /// <param name="requestHeader"></param>
        /// <returns></returns>
        public static HttpWebResponse createGetResponse(string strUrl, int iTimeOut = -1, Dictionary<string, string> requestHeader = null)
        {
            HttpWebRequest req = null;
            if (requestHeader == null || requestHeader.Count == 0)
            {
                req = createGetRequest(strUrl);
            }
            else
            {
                Dictionary<string, string> dictHeader = new Dictionary<string, string>(oftenRequestHeader);
                foreach (KeyValuePair<string, string> kv in requestHeader)
                {
                    if (dictHeader.ContainsKey(kv.Key))
                    {
                        dictHeader[kv.Key] = kv.Value;
                    }
                    else
                    {
                        dictHeader.Add(kv.Key, kv.Value);
                    }
                }
                dictHeader["Method"] = "GET";

                req = createRequest(strUrl, changeHeader(dictHeader));
            }
            if (iTimeOut > 0)
            {
                req.Timeout = iTimeOut;
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            return response;
        }

        /// <summary>
        /// 获取 POST方法 HTTP响应 对象
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="iTimeOut"></param>
        /// <param name="strContentType">ContentBody空时无效</param>
        /// <param name="bContentBody"></param>
        /// <returns></returns>
        public static HttpWebResponse createPostResponse(string strUrl, int iTimeOut = -1, string strContentType = null, byte[] bContentBody = null)
        {
            HttpWebRequest req = createPostRequest(strUrl);
            if (iTimeOut > 0)
            {
                req.Timeout = iTimeOut;
            }
            if (bContentBody != null)
            {
                if (!String.IsNullOrEmpty(strContentType))
                {
                    req.ContentType = strContentType;
                }
                //设置POST数据格式长度
                req.ContentLength = bContentBody.Length;
                //写入POST数据
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(bContentBody, 0, bContentBody.Length);
                reqStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            return response;
        }

        /// <summary>
        /// 获取 POST方法 HTTP响应 对象
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="iTimeOut"></param>
        /// <param name="requestHeader"></param>
        /// <param name="bContentBody"></param>
        /// <returns></returns>
        public static HttpWebResponse createPostResponse(string strUrl, int iTimeOut = -1, Dictionary<string, string> requestHeader = null, byte[] bContentBody = null)
        {
            HttpWebRequest req = null;
            if (requestHeader == null || requestHeader.Count == 0)
            {
                req = createPostRequest(strUrl);
            }
            else
            {
                Dictionary<string, string> dictHeader = new Dictionary<string, string>(oftenRequestHeader);
                foreach (KeyValuePair<string, string> kv in requestHeader)
                {
                    if (dictHeader.ContainsKey(kv.Key))
                    {
                        dictHeader[kv.Key] = kv.Value;
                    }
                    else
                    {
                        dictHeader.Add(kv.Key, kv.Value);
                    }
                }
                dictHeader["Method"] = "POST";

                req = createRequest(strUrl, changeHeader(dictHeader));
            }
            if (iTimeOut > 0)
            {
                req.Timeout = iTimeOut;
            }
            if (bContentBody != null)
            {
                //设置POST数据格式长度
                req.ContentLength = bContentBody.Length;
                //写入POST数据
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(bContentBody, 0, bContentBody.Length);
                reqStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            return response;
        }

        /// <summary>
        /// 提取Response中的Body
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static byte[] getResponseBody(HttpWebResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
                return null;
            Stream responseStream = response.GetResponseStream();

            byte[] bResponseBody = null;

            //chunked编码
            if (response.ContentLength == -1)
            {
                int bufferLength = 1024;
                byte[] buffer = new byte[bufferLength];
                BufferedStream bufferStream = new BufferedStream(new MemoryStream());

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

        /// <summary>
        /// 提取Response中的Header
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static Dictionary<string, string> getResponseHeader(HttpWebResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            Dictionary<string, string> mapResponseHeader = new Dictionary<string, string>();

            foreach (var key in response.Headers.AllKeys)
            {
                mapResponseHeader.Add(key,response.Headers[key]);
            }
            return mapResponseHeader;
        }

        /// <summary>
        /// 提取Response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static HttpData GetHttpData(HttpWebResponse response)
        {
            return new HttpData(getResponseHeader(response),getResponseBody(response));
        }

        #endregion

        #region 常用请求

        /// <summary>
        /// post方法得到响应体
        ///     内容类型空，默认超时时间
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="bBody"></param>
        /// <returns></returns>
        public static byte[] doPostRequest(string strUrl, byte[] bBody)
        {
            HttpWebResponse res = createPostResponse(strUrl, -1, "", bBody);

            byte[] bResponseBody = getResponseBody(res);
            return bResponseBody;
        }

        /// <summary>
        /// get方法得到响应体
        ///     默认超时时间
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public static byte[] doGetRequest(string strUrl)
        {
            HttpWebResponse res = createGetResponse(strUrl, -1);

            byte[] bResponseBody = getResponseBody(res);
            return bResponseBody;
        }

        #endregion

    }

    /// <summary>
    /// HTTP 数据，包含Header和Body
    /// </summary>
    public struct HttpData
    {
        /// <summary>
        /// Header
        /// </summary>
        public Dictionary<string, string> Header { get; private set; }
        /// <summary>
        /// Body
        /// </summary>
        public byte[] Body { get; private set; }

        public HttpData(Dictionary<string, string> header, byte[] body) : this()
        {
            Header = header;
            Body = body;
        }
    }
}
