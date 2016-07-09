using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace sichuan
{
    public class sichuan : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "四川省空气质量发布系统";
        private static string tag = "sichuan";
        private static string url = "http://www.scnewair.cn:3389/";
        private static AqiConstant.SourceLevel src = AqiConstant.SourceLevel.PROVINCIAL;
        private static AqiConstant.DataType dat = AqiConstant.DataType.JSON;
        private static string[] srcNameSpace = new string[]{
            "sichuan.publish", "sichuan.smartadmin.forecast"
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
