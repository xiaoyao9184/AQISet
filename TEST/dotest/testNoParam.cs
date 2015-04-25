using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using AQI;
using AQI.Abstract;
using Helper.Util.HTTP;

namespace TEST.dotest2
{
    public class testNoParam : AParamSrcUrl
    {

        #region 静态变量

        private static string Tag = "testNoParam";
        private static string Name = "没有参数";
        private static string Url = "http://static.aqicn.org/mapi/";
        private static AQI.AqiConstant.SourceUpdataInterval Sui = AQI.AqiConstant.SourceUpdataInterval.MINUTE;

        private static AQI.AqiConstant.ParamType ParamsType = AQI.AqiConstant.ParamType.GET;
        private static List<string> ParamsList = new List<string>(){
            "param1","param2","param3", "param4", "param5", "param6"
        };
        
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
        public override AQI.AqiConstant.ParamType PT
        {
            get
            {
                return ParamsType;
            }
        }
        public override List<string> PL
        {
            get
            {
                return ParamsList;
            }
        }
        
        #endregion

        #region 方法

        /// <summary>
        /// 枚举参数
        ///     空参数
        /// </summary>
        /// <returns></returns>
        public override List<AqiParam> enumParams()
        {
            List<AqiParam> apList = new List<AqiParam>();

            return apList;
        }

        #endregion

    }
}
