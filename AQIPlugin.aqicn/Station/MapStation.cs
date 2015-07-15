using System;
using System.Collections.Generic;
using System.Text;
using Helper.Util.HTTP;
using AQI;
using AQI.Abstract;

namespace aqicn.Station
{
    public class MapStation : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "MapStation";
        private static string name = "地图区域站点集合";
        private static string url = "http://static.aqicn.org/mapi/";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.HOUR;

        private static AQI.AqiConstant.ParamSendType ParamsType = AQI.AqiConstant.ParamSendType.GET;
        private static List<string> ParamsList = new List<string>(){
            "lurlv2","z","jsoncallback", "dyn", "bounds", "fst"
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

        #region 内部方法

        /// <summary>
        /// 加载boundsParams用于计算
        /// </summary>
        /// <returns></returns>
        private List<AqiParam> loadBoundsParams()
        {
            List<AqiParam> apList = new List<AqiParam>();
            //扩展参数
            List<AqiParam> apListTemp = AqiParam.CreateListFormJson(this, "boundsParams");

            //根据 扩展参数 生成最终参数
            foreach (AqiParam apTemp in apListTemp)
            {
                double lonS = double.Parse(apTemp["lonStart"]);
                double latS = double.Parse(apTemp["latStart"]);
                double lonEnd = double.Parse(apTemp["lonEnd"]);
                double latEnd = double.Parse(apTemp["latEnd"]);
                double increase = double.Parse(apTemp["increase"]);

                for (double lon = lonS; lon < lonEnd; lon = lon + increase)
                {
                    for (double lat = latS; lat < latEnd; lat = lat + increase)
                    {
                        AqiParam ap = new AqiParam("[枚举图块]\\" + apTemp.Name + "\\" + lon.ToString() + "-" + lat.ToString());
                        //ap.Add("", createurlByLonLat(lon, lat, increase));

                        ap.Add("lurlv2", apTemp["lurlv2"]);
                        ap.Add("z", apTemp["z"]);
                        ap.Add("bounds", createurlByLonLat2(lon, lat, increase));

                        apList.Add(ap);
                    }
                }
            }

            return apList;
        }

        /// <summary>
        /// 拼接url参数
        /// </summary>
        /// <param name="lon"></param>
        /// <param name="lat"></param>
        /// <param name="increase">间距</param>
        /// <returns></returns>
        private string createurlByLonLat(double lon, double lat, double increase)
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

        private string createurlByLonLat2(double lon, double lat, double increase)
        {
            double lonEnd = lon + increase;
            double latEnd = lat + increase;
            StringBuilder sb = new StringBuilder();

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

        #region 重写

        /// <summary>
        /// 加载参数
        ///     读取JSON中的boundsParams字段
        /// </summary>
        /// <returns></returns>
        public override List<AqiParam> EnumParams()
        {
            //过期判断：文件时间
            DateTime dtNewWriteTime = AqiParam.ReadWriteTimeFormJson(this);
            if (dtNewWriteTime > dtParamCacheTime)
            {
                //文件更新
                listParamCache = this.loadBoundsParams();
                dtParamCacheTime = dtNewWriteTime;
            }

            return base.FilterParams();
        }

        #endregion

        #endregion

    }
}
