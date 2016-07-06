using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI;
using AQI.Abstract;
using AQI.Interface;

namespace LN.Ajax.Permutation
{
    public class Get : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "Get";
        private static string name = "站点24小时历史AQI&浓度";
        private static string url = "http://211.137.19.74:8089/Ajax/Get{0}?stationCode={1}";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.HOUR;
        private static List<string> pn = new List<string>(){
            "p", "stationCode"
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
        public override AQI.AqiConstant.SourceUpdataInterval SUI
        {
            get
            {
                return sui;
            }
        }

        public override List<string> ParamName
        {
            get { return pn; }
        }

        public override AqiConstant.ParamSendType ParamSendType
        {
            get { return ps; }
        }

        #endregion

        #region 重写IMakeParam

        /// <summary>
        /// 拼接含参数Url
        ///     .重写
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="param">参数列表</param>
        /// <returns>完整URL</returns>
        public override string MakeUrl(AqiParam param)
        {
            return string.Format(Url, param["p"], param["stationCode"]);
        }

        #endregion

        #region 重写ICacheParam

        /// <summary>
        /// 加载参数
        ///     读取JSON中的boundsParams字段
        /// </summary>
        /// <returns></returns>
        public override bool LoadParams()
        {
            this.listParamCache = this.PermutationParams();
            this.dtParamCacheTime = AqiParam.ReadWriteTimeFormJson(this);
            return true;
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 加载boundsParams用于计算
        /// </summary>
        /// <returns></returns>
        private List<AqiParam> PermutationParams()
        {
            List<AqiParam> apList = new List<AqiParam>();
            //扩展参数
            List<AqiParam> apListTemp = AqiParam.CreateListFormJson(this, this.Tag, "Params");

            //根据 扩展参数 生成最终参数
            foreach (AqiParam apTemp in apListTemp)
            {
                Dictionary<string, string[]> data = new Dictionary<string, string[]>();

                foreach (var kv in apTemp)
                {
                    string[] v = kv.Value.Split('.');

                    data.Add(kv.Key,v);
                }
                List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
                ForPermutation(data, ref result);

                foreach (Dictionary<string, string> map in result)
                {
                    AqiParam ap = new AqiParam(apTemp, map);
                    apList.Add(ap);
                }
            }

            return apList;
        }

        /// <summary>
        /// 排列组合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="result"></param>
        /// <param name="tempValueList"></param>
        public static void ForPermutation<T>(Dictionary<T, T[]> data, ref List<Dictionary<T, T>> result,
            List<T> tempValueList = null)
        {
            if (tempValueList == null)
            {
                tempValueList = new List<T>();
            }

            int index = tempValueList.Count;
            T key = data.Keys.ElementAt(index);

            foreach (T value in data[key])
            {
                tempValueList.Add(value);
                if (index != (data.Count - 1))
                {
                    ForPermutation(data, ref result, tempValueList);
                }
                else
                {
                    Dictionary<T, T> t = new Dictionary<T, T>();
                    for (int i = 0; i < data.Count; i++)
                    {
                        T k = data.Keys.ElementAt(i);
                        T v = tempValueList[i];
                        t.Add(k, v);
                    }

                    result.Add(t);
                }
                tempValueList.RemoveAt(tempValueList.Count - 1);
            }
        }


        /// <summary>
        /// 拼接url参数
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

            sb.Append("(");
            sb.Append("(");
            sb.Append(lon.ToString());
            sb.Append(",");
            sb.Append(lat.ToString());
            sb.Append(")");
            sb.Append(",");
            sb.Append("(");
            sb.Append(lonEnd.ToString());
            sb.Append(",");
            sb.Append(latEnd.ToString());
            sb.Append(")");
            sb.Append(")");
            sb.Append("&fst");

            return sb.ToString();
        }


        #endregion

    }
}
