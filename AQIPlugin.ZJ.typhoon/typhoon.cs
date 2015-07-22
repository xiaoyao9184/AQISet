using System;
using AQI;
using AQI.Interface;
using AQI.Abstract;

namespace Plugin_ZJTF
{
    public class typhoon : ABaseAqiWeb
    {
        
        #region 静态字段

        private static string name = "typhoon";
        private static string tag = "typhoon";
        private static string url = "http://typhoon.zjwater.gov.cn/";
        private static AqiConstant.SourceLevel src = AqiConstant.SourceLevel.OTHER;
        private static AqiConstant.DataType dat = AqiConstant.DataType.JSON;
        private static string[] srcNameSpace = new string[]{
            "typhoon.Api", "typhoon.Api.Auto"
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
