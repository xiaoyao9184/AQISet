using System;
using AQI.Abstract;

namespace BJ.DataService
{
    public class GetWebAlert
    {

        #region 静态变量

        private static string Tag = "GetWebData";
        private static string Name = "站点1小时AQI";
        private static string Url = "http://zx.bjmemc.com.cn/DataService.svc";
        private static AQI.AqiSetting.SourceUpdataInterval Sui = AQI.AqiSetting.SourceUpdataInterval.HOUR;

        #endregion

        #region 属性

        public override string TAG
        {
            get
            {
                return Tag;
            }
        }
        public override string NAME
        {
            get
            {
                return Name;
            }
        }
        public override string URL
        {
            get
            {
                return Url;
            }
        }
        public override AQI.AqiSetting.SourceUpdataInterval SUI
        {
            get
            {
                return Sui;
            }
        }

        #endregion

    }
}
