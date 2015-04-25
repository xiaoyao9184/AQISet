using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using AQI;
using AQI.Abstract;
using Helper.Util.HTTP;

namespace aqicn.Station
{
    public class MapStation : AParamSrcUrl
    {

        #region 静态变量

        private static string Tag = "MapStation";
        private static string Name = "地图区域站点集合";
        private static string Url = "http://static.aqicn.org/mapi/";
        private static AQI.AqiConstant.SourceUpdataInterval Sui = AQI.AqiConstant.SourceUpdataInterval.HOUR;

        private static AQI.AqiConstant.ParamType ParamsType = AQI.AqiConstant.ParamType.GET;
        private static List<string> ParamsList = new List<string>(){
            "lurlv2","z","jsoncallback", "dyn", "bounds", "fst"
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
        ///     读取JSON中的boundsParams字段
        /// </summary>
        /// <returns></returns>
        public override List<AqiParam> enumParams()
        {
            List<AqiParam> apList = new List<AqiParam>();
            //扩展参数
            List<AqiParam> apListTemp = AqiParam.CreateListFormJson(this, "boundsParams");
            //根据 扩展参数 生成最终参数
            foreach (AqiParam apTemp in apListTemp)
            {
                double lon = double.Parse(apTemp["lonStart"]);
                double lat = double.Parse(apTemp["latStart"]);
                double lonEnd = double.Parse(apTemp["lonEnd"]);
                double latEnd = double.Parse(apTemp["latEnd"]);
                double increase = double.Parse(apTemp["increase"]);

                for (; lon < lonEnd; lon = lon + increase)
                {
                    for (; lat < latEnd; lat = lat + increase)
                    {
                        AqiParam ap = new AqiParam("[枚举图块]\\" + apTemp.Name + "\\" + lon.ToString() + "-" + lat.ToString());
                        ap.Add("", createUrlByLonLat(lon, lat, increase));
                        apList.Add(ap);
                    }
                }
            }

            return apList;
        }

        /// <summary>
        /// 拼接Url参数
        /// </summary>
        /// <param name="lon"></param>
        /// <param name="lat"></param>
        /// <param name="increase">间距</param>
        /// <returns></returns>
        private string createUrlByLonLat(double lon, double lat, double increase)
        {
            double lonEnd = lon + increase;
            double latEnd = lat + increase;
            StringBuilder sb = new StringBuilder();
            sb.Append("lurlv2&z=10&bounds=");
            
            sb.Append("(");
                sb.Append("(");
                sb.Append(lon.ToString());
                sb.Append(", ");
                sb.Append(lat.ToString());
                sb.Append(")");
            sb.Append(", ");
                sb.Append("(");
                sb.Append(lonEnd.ToString());
                sb.Append(", ");
                sb.Append(latEnd.ToString());
                sb.Append(")");
            sb.Append(")");
            sb.Append("&fst");

            return sb.ToString();
        }

        #endregion

    }
}
