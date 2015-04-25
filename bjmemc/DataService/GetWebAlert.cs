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

        private static string Tag = "GetWebAlert";
        private static string Name = "不明数据";
        private static string Url = "http://zx.bjmemc.com.cn/DataService.svc";
        private static AQI.AqiConstant.SourceUpdataInterval Sui = AQI.AqiConstant.SourceUpdataInterval.NONE;

        #endregion

        #region 属性

        public override string TAG
        {
            get
            {
                return Tag;
            }
        }
        public override string NAME
        {
            get
            {
                return Name;
            }
        }
        public override string URL
        {
            get
            {
                return Url;
            }
        }
        public override AQI.AqiConstant.SourceUpdataInterval SUI
        {
            get
            {
                return Sui;
            }
        }

        #endregion

    }
}
