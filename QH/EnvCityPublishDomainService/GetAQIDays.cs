using System;
using AQI.Abstract;
using QH.Abstract;

namespace QHHX.EnvCityPublishDomainService
{
    public class GetAQIDays : QHXHSrcUrl
    {

        #region 静态变量

        private static string Tag = "GetAQIDays";
        private static string Name = "西海州站点24小时AQI等级";
        private static string Url = "http://61.133.239.78:82/ClientBin/Env-CityPublish-RiaService-EnvCityPublishDomainService.svc/binary/GetAQIDays";
        private static AQI.AqiConstant.SourceUpdataInterval Sui = AQI.AqiConstant.SourceUpdataInterval.DAY;
        
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
        public override AQI.AqiConstant.SourceUpdataInterval SUI
        {
            get
            {
                return Sui;
            }
        }

        #endregion

    }
}
