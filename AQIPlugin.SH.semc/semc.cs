using AQI.Abstract;

namespace semc
{
    public class semc : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "上海市空气质量实时发布系统";
        private static string tag = "semc";
        private static string url = "http://www.semc.gov.cn/";
        private static AQI.AqiConstant.SourceLevel src = AQI.AqiConstant.SourceLevel.CITY;
        private static AQI.AqiConstant.DataType dat = AQI.AqiConstant.DataType.JSON;
        private static string[] srcNameSpace = new string[]{
            "semc.messagebroker"
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
