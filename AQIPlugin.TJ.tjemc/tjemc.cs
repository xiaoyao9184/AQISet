using System;
using System.Collections.Generic;
using System.Reflection;
using AQI;
using AQI.Abstract;
using AQI.Interface;

namespace tjemc
{
    public class tjemc: ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "天津市环境空气质量GIS发布平台";
        private static string tag = "tjemc";
        private static string url = "http://air.tjemc.org.cn/";
        private static AQI.AqiConstant.SourceLevel src = AQI.AqiConstant.SourceLevel.PROVINCIAL;
        private static AQI.AqiConstant.DataType dat = AQI.AqiConstant.DataType.JSON;
        private static string[] srcNameSpace = new string[]{
            "tjemc.handler"
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
