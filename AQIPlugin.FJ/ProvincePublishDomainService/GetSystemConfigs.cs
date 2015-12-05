using System;
using AQI.Abstract;
using FJ.Abstract;

namespace FJ.ProvincePublishDomainService
{
    public class GetSystemConfigs : FJSrcUrl
    {

        #region 静态变量

        private static string tag = "GetSystemConfigs";
        private static string name = "福建系统配置";
        private static string url = "http://fbpt.fjemc.org.cn/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc/binary/GetSystemConfigs";
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
