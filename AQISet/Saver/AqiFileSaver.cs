using System;
using System.IO;
using AQI;
using AQI.Interface;
using AQISet.Interface;
using Helper.Util.IO;

namespace AQISet.Saver
{
    /// <summary>
    /// AQI文件存储管理
    /// </summary>
    public class AqiFileSaver : IAqiSave
    {

        #region 常量

        private const string st = "FS";

        #endregion

        #region 内部属性

        private string basePath;
        
        #endregion

        #region 属性

        public string SaverType
        {
            get
            {
                return st;
            }
        }

        #endregion

        public AqiFileSaver(AqiManage aqimanage)
        {
            string path = aqimanage.AqiSetting["AqiFileSaver.Path"];

            if (!String.IsNullOrEmpty(path))
            {
                basePath = path;
            }
            else
            {
                basePath = "D:\\AQI\\";
            }

            if(!Directory.Exists(basePath)) {
                Directory.CreateDirectory(basePath); 
            }
            Console.WriteLine("基本路径为：" + basePath);
        }

        #region 内部方法

        private string getTime()
        {
            return DateTime.Now.ToString("hh-mm-ss");
        }
        private string getDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        #endregion

        #region 接口方法

        public bool Save(ISrcUrl isu, byte[] data)
        {
            return Save(isu, null, data);
        }

        public bool Save(ISrcUrl isu, string grouptag, byte[] data)
        {
            string fileName = fileName = getDate() + "_" + getTime() + "." + isu.IAW.DAT.ToString().ToLower();
            string filePath = basePath + isu.IAW.TAG + "\\" + isu.TAG + "\\";
            if (!String.IsNullOrEmpty(grouptag))
            {
                filePath = filePath + grouptag + "\\";
            }

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            return FileReadSaveUtil.Save(data, filePath + fileName);
        }

        #endregion

    }
}
