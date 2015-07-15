using System;
using System.IO;

namespace Helper.Util.IO
{
    /// <summary>
    /// 文件读取/保存
    /// 1.4 2015-07-11 * can set throw Exception
    /// 1.3 2015-07-07 * catch no return false
    /// 1.2 2015-01-22 * IOException to Exception
    /// 1.1 2014-12-30 * Add to "Helper" Class Library
    /// 1.0 2014-06-16
    /// </summary>
    public static class FileReadSaveUtil
    {

        private static bool throwException = true;

        /// <summary>
        /// 是否向外抛出异常
        /// </summary>
        public static bool ThrowException
        {
            get
            {
                return throwException;
            }
            set
            {
                throwException = value;
            }
        }

        /// <summary>
        /// 读取为字节数组
        /// </summary>
        /// <param name="strFile"></param>
        /// <returns></returns>
        public static byte[] Read(string strFile)
        {
            try
            {
                return File.ReadAllBytes(strFile);
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw;
                }
                else{
                    Console.WriteLine(exception.Message);
                }
            }
            return null;
        }

        public static string ReadText(string strFile)
        {
            try
            {
                return File.ReadAllText(strFile);
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw;
                }
                else
                {
                    Console.WriteLine(exception.Message);
                }
            }
            return null;
        }

        /// <summary>
        /// 写入字节数组
        /// </summary>
        /// <param name="bData"></param>
        /// <param name="strFile"></param>
        /// <returns></returns>
        public static bool Save(byte[] bData, string strFile) 
        {
            try
            {
                File.WriteAllBytes(strFile, bData);
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw;
                }
                else
                {
                    Console.WriteLine(exception.Message);
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// 写入字符串
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="strFile"></param>
        /// <returns></returns>
        public static bool SaveText(string strText, string strFile) 
        {
            try
            {
                File.WriteAllText(strFile, strText);
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw;
                }
                else
                {
                    Console.WriteLine(exception.Message);
                }
                return false;
            }
            return true;
        }

    }
}
