using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB
{
    public class HB : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "河北省环境空气质量自动监测及发布系统";
        private static string tag = "HB";
        private static string url = "http://121.28.49.85:8080/";
        private static AqiConstant.SourceLevel src = AqiConstant.SourceLevel.PROVINCIAL;
        private static AqiConstant.DataType dat = AqiConstant.DataType.XML;
        private static string[] srcNameSpace = new string[]{
            "HB.datas"
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
