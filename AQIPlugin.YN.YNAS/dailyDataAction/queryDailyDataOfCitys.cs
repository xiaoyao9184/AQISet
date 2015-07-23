using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YNAS.dailyDataAction
{
    public class queryDailyDataOfCitys : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "queryDailyDataOfCitys";
        private static string name = "云南城市24小时AQI";
        private static string url = "http://61.166.240.109:6013/YNAS/dailyDataAction!queryDailyDataOfCitys";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.DAY;
        private static List<string> pn = new List<string>(){
            ""
        };
        private static AqiConstant.ParamSendType ps = AqiConstant.ParamSendType.GET;

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
        public override List<string> ParamName
        {
            get
            {
                return pn;
            }
        }
        public override AqiConstant.ParamSendType ParamSendType
        {
            get
            {
                return ps;
            }
        }
        public override AqiConstant.ParamUrlType ParamUrlType
        {
            get
            {
                return put;
            }
        }

        #endregion

    }
}
