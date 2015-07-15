using System;
using AQI.Abstract;
using QH.Abstract;

namespace QHHX.EnvCityPublishDomainService
{
    public class GetAQIDataPublishLives : QHXHSrcUrl
    {

        #region 静态变量

        private static string tag = "GetAQIDataPublishLives";
        private static string name = "西海州站点1小时溶度";
        private static string url = "http://61.133.239.78:82/ClientBin/Env-CityPublish-RiaService-EnvCityPublishDomainService.svc/binary/GetAQIDataPublishLives";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.HOUR;
        
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
