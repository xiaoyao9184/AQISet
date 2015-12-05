using System;
using AQI.Abstract;
using FJ.Abstract;

namespace FJ.ProvincePublishDomainService
{
    public class GetAQICity : FJSrcUrl
    {

        #region 静态变量

        private static string tag = "GetAqiCity";
        private static string name = "福建城市列表";
        private static string url = "http://fbpt.fjemc.org.cn/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc/binary/GetAqiCity";
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
