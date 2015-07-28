using AQI;
using jsair.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jsair.JSAQPPSERVICES_DEBUG
{
    public class LSZDSB : jsairSrcUrl
    {

        #region 静态变量

        private static string tag = "LSZDSB";
        private static string name = "江苏站点污染物历史";
        private static string url = "http://218.94.78.75/JSAQPPSERVICES/REST/V100/STATION/{0}/{1}/{2}/{3}/{4}/Histroy?token={5}";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.NONE;
        private static List<string> pn = new List<string>(){
            "pollutant", "timestart", "timeend", "citycode", "stationcode"
        };
        private static AqiConstant.ParamSendType ps = AqiConstant.ParamSendType.GET;

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
        public override List<string> ParamName
        {
            get
            {
                return pn;
            }
        }
        public override AqiConstant.ParamSendType ParamSendType
        {
            get
            {
                return ps;
            }
        }

        #endregion

        #region 方法

        #region IMakeParam接口

        /// <summary>
        /// 拼接含参数Url
        ///     重写
        /// </summary>
        /// <param name="param">参数列表</param>
        /// <returns>完整URL</returns>
        public override string MakeUrl(AqiParam param)
        {
            return string.Format(Url, 
                param["pollutant"],
                param["timestart"], 
                param["timeend"], 
                param["citycode"],
                param["stationcode"],
                token);
        }

        #endregion

        #endregion

    }
}
