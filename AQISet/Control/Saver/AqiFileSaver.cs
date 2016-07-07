using System;
using System.IO;
using AQI;
using AQI.Interface;
using Helper.Util.IO;

namespace AQISet.Control.Saver
{
    /// <summary>
    /// AQI文件存储管理
    /// </summary>
    public class AqiFileSaver : IAqiSave
    {

        #region 常量

        public const string NAME = "AqiFileSaver";
        private const string SAVER_TYPE = "FS";
        private const string DEFAULT_PATH = @"C:\AQISet-Data\";

        #endregion

        #region 内部属性

        private string basePath;
        private bool saveEmpty;

        #endregion

        public AqiFileSaver()
        {
            string path = AqiManage.Setting["AqiFileSaver.Path"];
            this.saveEmpty = AqiManage.Setting.Get<bool>("AqiFileSaver.SaveEmptyData");
            if (!String.IsNullOrEmpty(path))
            {
                basePath = path;
            }
            else
            {
                basePath = DEFAULT_PATH;
            }

            if(!Directory.Exists(basePath)) {
                Directory.CreateDirectory(basePath); 
            }
            AqiManage.Remind.Log_Info("基本路径为：" + this.basePath, new string[] { this.Name });
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

        #region IAqiSave

        public string Name
        {
            get
            {
                return NAME;
            }
        }

        public string SaverType
        {
            get
            {
                return SAVER_TYPE;
            }
        }

        public long GetSpace()
        {
            DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(basePath));
            
            return driveInfo.TotalFreeSpace;
        }

        public bool Save(ISrcUrl isu, byte[] data)
        {
            return Save(isu, null, data);
        }

        public bool Save(ISrcUrl isu, AqiParam param, byte[] data)
        {
            try
            {
                string str;
                if (data == null)
                {
                    data = new byte[0];
                    if (!this.saveEmpty)
                    {
                        return false;
                    }
                }
                //目录
                string path = this.basePath + isu.IAW.Tag + @"\" + isu.Tag + @"\";
                //分组
                string grouptag = "";
                //文件名
                string nameFile = this.getDate() + "_" + this.getTime();

                if (param != null)
                {
                    grouptag = param.Name;
                    if (param.Unique)
                    {
                        nameFile = grouptag;
                    }
                    else
                    {
                        path = path + grouptag + @"\";
                    }
                }
                
                //扩展名
                string nameExtension = "." + isu.IAW.DAT.ToString().ToLower();
                if (isu is IDataType)
                {
                    IDataType idt = (isu as IDataType);
                    if (idt.DAT == AqiConstant.DataType.NONE)
                    {
                        nameExtension = "";
                    }else{
                        nameExtension = "." + idt.DAT.ToString().ToLower();
                    }
                }
                str = nameFile + nameExtension;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                AqiManage.Remind.Log_Debug("保存路径为" + path + str, new string[] { this.Name });
                return FileReadSaveUtil.Save(data, path + str);
            }
            catch (Exception exception)
            {
                AqiManage.Remind.Log_Error("保存失败", exception, new string[] { this.Name });
                return false;
            }
        }

        #endregion

    }
}
