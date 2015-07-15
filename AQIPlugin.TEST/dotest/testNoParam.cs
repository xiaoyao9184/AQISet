using System;
using System.Collections.Generic;
using System.Text;
using Helper.Util.HTTP;
using AQI;
using AQI.Abstract;

namespace TEST.dotest2
{
    public class testNoParam : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "testNoParam";
        private static string name = "没有参数";
        private static string url = "http://static.aqicn.org/mapi/";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.MINUTE;

        private static AQI.AqiConstant.ParamSendType ParamsType = AQI.AqiConstant.ParamSendType.GET;
        private static List<string> ParamsList = new List<string>(){
            "param1","param2","param3", "param4", "param5", "param6"
        };
        
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
        public override AQI.AqiConstant.ParamSendType ParamSendType
        {
            get
            {
                return ParamsType;
            }
        }
        public override List<string> ParamName
        {
            get
            {
                return ParamsList;
            }
        }
        
        #endregion

        #region 方法

        /// <summary>
        /// 加载参数
        ///     空参数
        /// </summary>
        /// <returns></returns>
        public override List<AqiParam> EnumParams()
        {
            List<AqiParam> apList = new List<AqiParam>();

            return apList;
        }

        #endregion

    }
}
