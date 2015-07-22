using System;
using AQI.Abstract;
using GS.Abstract;

namespace GS.ProvincePublishDomainService
{
    public class GetAQICity : GSSrcUrl
    {

        #region 静态变量

        private static string tag = "GetAqiCity";
        private static string name = "甘肃城市列表";
        private static string url = "http://61.178.102.124:82/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc/binary/GetAqiCity";
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
