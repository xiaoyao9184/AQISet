using System;
using AQI.Abstract;
using QH.Abstract;

namespace QHHX.EnvCityPublishDomainService
{
    public class GetAQITips : QHXHSrcUrl
    {

        #region 静态变量

        private static string tag = "GetAQITips";
        private static string name = "西海州各AQI等级提示信息";
        private static string url = "http://61.133.239.78:82/ClientBin/Env-CityPublish-RiaService-EnvCityPublishDomainService.svc/binary/GetAQITips";
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
