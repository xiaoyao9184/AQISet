using System;
using System.Collections.Generic;
using AQI.Interface;
using AQI.Abstract;

namespace aqicn
{
    public class aqicn : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "aqicn";
        private static string tag = "aqicn";
        private static string url = "http://aqicn.org/";
        private static AQI.AqiConstant.SourceLevel src = AQI.AqiConstant.SourceLevel.OTHER;
        private static AQI.AqiConstant.DataType dat = AQI.AqiConstant.DataType.JSON;
        private static string[] srcNameSpace = new string[]{
            "aqicn.Station"
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
        public override AQI.AqiConstant.SourceLevel SRC
        {
            get
            {
                return src;
            }
        }
        public override AQI.AqiConstant.DataType DAT
        {
            get
            {
                return dat;
            }
        }
        
        #endregion

    }
}
