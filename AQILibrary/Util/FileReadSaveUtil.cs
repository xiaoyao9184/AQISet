using System;
using System.IO;

namespace Helper.Util.IO
{
    /// <summary>
    /// 文件读取/保存
    /// 1.2 2015-01-22 * IOException to Exception
    /// 1.1 2014-12-30 * Add to "Helper" Class Library
    /// 1.0 2014-06-16
    /// </summary>
    public static class FileReadSaveUtil
    {
        /// <summary>
        /// 读取为字节数组
        /// </summary>
        /// <param name="strFile"></param>
        /// <returns></returns>
        public static byte[] Read(string strFile)
        {
            try
            {
                FileStream fs = new FileStream(strFile, FileMode.Open, FileAccess.Read);
                byte[] bFile = new byte[fs.Length];
                BinaryReader r = new BinaryReader(fs);
                bFile = r.ReadBytes((int)fs.Length);
                r.Close();
                r = null;
                fs.Close();
                return bFile;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
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
                //FileStream fs = new FileStream(strFile, FileMode.Open, FileAccess.Write);
                //BinaryWriter w = new BinaryWriter(fs);
                //w.r
                //byte[] bFile = new byte[fs.Length];
                //BinaryReader r = new BinaryReader(fs);
                //bFile = r.ReadBytes((int)fs.Length);
                //r.Close();
                //r = null;
                //fs.Close();
                //return bFile;
                File.WriteAllBytes(strFile, bData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return true;
        }


        /// <summary>
        /// 写入字符串
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="strFile"></param>
        /// <returns></returns>
        public static bool Save(string strText, string strFile) {
            try
            {
                File.WriteAllText(strFile, strText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return true;
        }

    }
}
