using System;
using AQI.Abstract;
using NX.Abstract;

namespace NX.ProvincePublishDomainService
{
    public class GetServerTime : NXSrcUrl
    {

        #region 静态变量

        private static string tag = "GetServerTime";
        private static string name = "宁夏系统时间";
        private static string url = "http://119.60.12.114:8080/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc/binary/GetServerTime";
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
