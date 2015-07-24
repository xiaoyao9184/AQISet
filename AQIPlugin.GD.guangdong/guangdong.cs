using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace guangdong
{
    public class guangdong : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "广东省空气质量实况发布平台";
        private static string tag = "guangdong";
        private static string url = "http://113.108.142.147:20011/";
        private static AqiConstant.SourceLevel src = AqiConstant.SourceLevel.PROVINCIAL;
        private static AqiConstant.DataType dat = AqiConstant.DataType.XML;
        private static string[] srcNameSpace = new string[]{
            "guangdong.EnvGDService"
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
