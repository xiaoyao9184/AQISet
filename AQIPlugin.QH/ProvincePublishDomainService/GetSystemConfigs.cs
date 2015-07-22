using System;
using AQI.Abstract;
using QH.Abstract;

namespace QH.ProvincePublishDomainService
{
    public class GetSystemConfigs : QHSrcUrl
    {

        #region 静态变量

        private static string tag = "GetSystemConfigs";
        private static string name = "青海系统配置";
        private static string url = "http://221.207.21.89:8080/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc/binary/GetSystemConfigs";
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
