using System;
using AQI.Abstract;
using JL.Abstract;

namespace JL.ProvincePublishDomainService
{
    public class GetServerTime : JLSrcUrl
    {

        #region 静态变量

        private static string tag = "GetServerTime";
        private static string name = "吉林系统时间";
        private static string url = "http://58.245.27.140:82/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc/binary/GetServerTime";
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
