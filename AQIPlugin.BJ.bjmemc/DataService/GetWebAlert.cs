using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bjmemc.Abstract;

namespace bjmemc.DataService
{
    public class GetWebAlert : bjmemcSrcUrl
    {

        #region 静态变量

        private static string tag = "GetWebAlert";
        private static string name = "不明数据";
        private static string url = "http://zx.bjmemc.com.cn/DataService.svc";
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
