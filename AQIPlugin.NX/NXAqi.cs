using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS
{
    public class NXAqi : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "宁夏省环境空气质量实时发布系统";
        private static string tag = "nx";
        private static string url = "http://119.60.12.114:8080/";
        private static AQI.AqiConstant.SourceLevel src = AQI.AqiConstant.SourceLevel.PROVINCIAL;
        private static AQI.AqiConstant.DataType dat = AQI.AqiConstant.DataType.XML;
        private static string[] srcNameSpace = new string[]{
            "NX.ProvincePublishDomainService", "NX.ProvincePublishDomainService.Auto"
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
