using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace earth
{
    public class earth : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "earth";
        private static string tag = "earth";
        private static string url = "http://earth.nullschool.net/";
        private static AqiConstant.SourceLevel src = AqiConstant.SourceLevel.OTHER;
        private static AqiConstant.DataType dat = AqiConstant.DataType.JSON;
        private static string[] srcNameSpace = new string[]{
            "earth.data"
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
