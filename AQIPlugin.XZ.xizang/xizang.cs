using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace xizang
{
    public class xizang : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "西藏自治区环境空气质量实时发布系统";
        private static string tag = "xizang";
        private static string url = "http://111.11.241.103:9001/";
        private static AqiConstant.SourceLevel src = AqiConstant.SourceLevel.PROVINCIAL;
        private static AqiConstant.DataType dat = AqiConstant.DataType.JSON;
        private static string[] srcNameSpace = new string[]{
            "xizang.ashx"
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
