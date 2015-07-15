using System;
using System.Collections.Generic;
using System.Reflection;
using AQI;
using AQI.Abstract;
using AQI.Interface;

namespace TEST
{
    public class TESTAqi : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "测试";
        private static string tag = "test";
        private static string url = "http://127.0.0.1/";
        private static AQI.AqiConstant.SourceLevel src = AQI.AqiConstant.SourceLevel.OTHER;
        private static AQI.AqiConstant.DataType dat = AQI.AqiConstant.DataType.TEXT;
        private static string[] srcNameSpace = new string[]{
            "TEST.dotest"
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
