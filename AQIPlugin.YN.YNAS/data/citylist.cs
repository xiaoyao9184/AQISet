using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YNAS.data
{
    public class citylist : ABaseSrcUrl
    {

        #region 静态变量

        private static string tag = "citylist";
        private static string name = "云南城市列表";
        private static string url = "http://61.166.240.109:6013/YNAS/data/citylist.json";
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
