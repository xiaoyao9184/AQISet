using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN
{
    public class LNAqi : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "辽宁省空气质量实时发布系统(beta)";
        private static string tag = "ln";
        private static string url = "http://211.137.19.74:8089/";
        private static AQI.AqiConstant.SourceLevel src = AQI.AqiConstant.SourceLevel.PROVINCIAL;
        private static AQI.AqiConstant.DataType dat = AQI.AqiConstant.DataType.JSON;
        private static string[] srcNameSpace = new string[]{
            "LN.Ajax.Permutation", "LN.Ajax", "LN.Home",// "LN.AirQualityService"
            //TODO 检查AirQualityService中是否重复
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
