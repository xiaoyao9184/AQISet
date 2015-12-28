using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace YNAS
{
    public class YNAS : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "云南省空气质量发布系统(试运行)";
        private static string tag = "YNAS";
        private static string url = "http://61.166.240.109:6013/YNAS/index.jsp";
        private static AqiConstant.SourceLevel src = AqiConstant.SourceLevel.PROVINCIAL;
        private static AqiConstant.DataType dat = AqiConstant.DataType.JSON;
        private static string[] srcNameSpace = new string[]{
            "YNAS.data", "YNAS.stationAction", "YNAS.noticeInfoAction", "YNAS.dailyDataAction", "YNAS.realDataAction"
        };

        #endregion

        #region 属性

        public override string Name
        {
            get
            {
                return name;
            }
        }
        public override string Tag
        {
            get
            {
                return tag;
            }
        }
        public override string Url
        {
            get
            {
                return url;
            }
        }
        public override string[] SrcUrlNameSpace
        {
            get
            {
                return srcNameSpace;
            }
        }
        public override AqiConstant.SourceLevel SRC
        {
            get
            {
                return src;
            }
        }
        public override AqiConstant.DataType DAT
        {
            get
            {
                return dat;
            }
        }

        #endregion

    }
}
