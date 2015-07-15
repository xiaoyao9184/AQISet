using System;
using System.Collections.Generic;
using System.Reflection;
using AQI;
using AQI.Abstract;
using AQI.Interface;

namespace sxAQIWeb
{
    public class sxAQIWeb: ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "陕西省空气质量实时发布系统";
        private static string tag = "sxAQIWeb";
        private static string url = "http://113.140.66.226:8024/sxAQIWeb";
        private static AQI.AqiConstant.SourceLevel src = AQI.AqiConstant.SourceLevel.PROVINCIAL;
        private static AQI.AqiConstant.DataType dat = AQI.AqiConstant.DataType.XML;
        private static string[] srcNameSpace = new string[]{
            "sxAQIWeb.City","sxAQIWeb.Station"
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
