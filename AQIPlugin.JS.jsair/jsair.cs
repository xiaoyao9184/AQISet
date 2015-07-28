using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jsair
{
    public class jsair : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "江苏省城市空气质量新标准试运行监测数据发布平台";
        private static string tag = "jsair";
        private static string url = "http://218.94.78.75/jsair/";
        private static AqiConstant.SourceLevel src = AqiConstant.SourceLevel.PROVINCIAL;
        private static AqiConstant.DataType dat = AqiConstant.DataType.JSON;
        private static string[] srcNameSpace = new string[]{
            "jsair.JSAQPPSERVICES", "jsair.JSAQPPSERVICES_DEBUG"
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
