using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YNAS.dailyDataAction
{
    public class queryStationDataList : ABaseSrcUrl
    {

        #region 静态变量

        private static string tag = "queryStationDataList";
        private static string name = "云南站点24小时AQI";
        private static string url = "http://61.166.240.109:6013/YNAS/dailyDataAction!queryStationDataList";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.DAY;
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
