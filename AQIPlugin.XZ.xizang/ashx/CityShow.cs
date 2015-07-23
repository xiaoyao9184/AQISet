using System;
using AQI;
using AQI.Abstract;

namespace xizang.ashx
{
    public class CityShow : ABaseSrcUrl
    {

        #region 静态变量

        private static string tag = "CityShow";
        private static string name = "西藏城市列表";
        private static string url = "http://111.11.241.103:9001/ashx/CityShow.ashx";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.NONE;
        private static AqiConstant.HttpType httpType = AqiConstant.HttpType.GET;

        #endregion

        #region 属性

        public override string Tag
        {
            get
            {
                return tag;
            }
        }
        public override string Name
        {
            get
            {
                return name;
            }
        }
        public override string Url
        {
            get
            {
                return url;
            }
        }
        public override AqiConstant.SourceUpdataInterval SUI
        {
            get
            {
                return sui;
            }
        }
        public override AqiConstant.HttpType HT
        {
            get
            {
                return httpType;
            }
        }

        #endregion

    }
}
