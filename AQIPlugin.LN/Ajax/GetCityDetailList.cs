using System;
using System.Collections.Generic;
using AQI;
using AQI.Abstract;
using AQI.Interface;

namespace LN.Ajax
{
    public class GetCityDetailList : ABaseSrcUrl
    {

        #region 静态变量

        private static string tag = "GetCityDetailList";
        private static string name = "城市1小时AQI&浓度";
        private static string url = "http://211.137.19.74:8089/Ajax/GetCityDetailList";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.HOUR;

        private static AqiConstant.HttpType ht = AqiConstant.HttpType.GET;

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
        public override AQI.AqiConstant.SourceUpdataInterval SUI
        {
            get
            {
                return sui;
            }
        }

        public override AqiConstant.HttpType HT
        {
            get { return ht; }
        }


        #endregion

    }
}
