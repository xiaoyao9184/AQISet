using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.datas
{
    public class hour : ABaseSrcUrl
    {
        
        #region 静态变量

        private static string tag = "hour";
        private static string name = "河北AQI时报";
        private static string url = "http://121.28.49.85:8080/datas/hour/130000.xml";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.HOUR;
        private static AqiConstant.HttpType httpType = AqiConstant.HttpType.GET;

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
        public override AqiConstant.SourceUpdataInterval SUI
        {
            get
            {
                return sui;
            }
        }
        public override AqiConstant.HttpType HT
        {
            get
            {
                return httpType;
            }
        }

        #endregion

    }
}
