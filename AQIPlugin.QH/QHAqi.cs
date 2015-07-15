using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI.Abstract;
using AQI.Interface;

namespace QH
{
    public class QHAqi: ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "(青海省)海西州空气质量实时发布系统";
        private static string tag = "qhHaixi";
        private static string url = "http://61.133.239.78:82/";
        private static AQI.AqiConstant.SourceLevel src = AQI.AqiConstant.SourceLevel.CITY;
        private static AQI.AqiConstant.DataType dat = AQI.AqiConstant.DataType.XML;
        private static string[] srcNameSpace = new string[]{
            "QHHX.EnvCityPublishDomainService"
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
