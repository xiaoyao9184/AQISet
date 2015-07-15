using System;
using AQI.Abstract;
using QH.Abstract;

namespace QHHX.EnvCityPublishDomainService
{
    public class GetAQICityStations : QHXHSrcUrl
    {

        #region 静态变量

        private static string tag = "GetAQICityStations";
        private static string name = "海西州站点";
        private static string url = "http://61.133.239.78:82/ClientBin/Env-CityPublish-RiaService-EnvCityPublishDomainService.svc/binary/GetAQICityStations";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.NONE;

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

        #endregion

    }
}
