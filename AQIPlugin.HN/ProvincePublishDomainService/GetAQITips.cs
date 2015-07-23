using System;
using AQI.Abstract;
using HN.Abstract;

namespace HN.ProvincePublishDomainService
{
    public class GetAQITips : HNSrcUrl
    {

        #region 静态变量

        private static string tag = "GetAQITips";
        private static string name = "湖南各AQI等级提示信息";
        private static string url = "http://222.247.51.155:8025/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc/binary/GetAQITips";
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
