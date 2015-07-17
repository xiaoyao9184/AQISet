using System;
using System.Collections.Generic;
using AQI;
using AQI.Abstract;
using AQI.Exception;

namespace typhoon.Api
{
    public class TyphoonInfo_Manual : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "TyphoonInfo_Manual";
        private static string name = "浙江台风详情";
        private static string url = "http://typhoon.zjwater.gov.cn/Api/TyphoonInfo";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.NONE;
        private static List<string> pn = new List<string>(){
            "depthsParams.", ".yearidStart", ".yearidEnd", ".yearidDepth"
        };
        private static new AqiConstant.ParamSendType pst = AqiConstant.ParamSendType.GET;
        private static new AqiConstant.ParamUrlType put = AqiConstant.ParamUrlType.PATH;

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
                return pst;
            }
        }
        public override AqiConstant.ParamUrlType ParamUrlType
        {
            get
            {
                return put;
            }
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 加载depthsParams用于计算
        /// </summary>
        /// <returns></returns>
        private List<AqiParam> loadDepthsParams()
        {
            List<AqiParam> apList = new List<AqiParam>();
            //扩展参数
            List<AqiParam> apListTemp = AqiParam.CreateListFormJson(this, this.Tag, "depthsParams");
            //根据 扩展参数 生成最终参数
            foreach (AqiParam apTemp in apListTemp)
            {
                int idS = Int32.Parse(apTemp["yearidStart"]);
                int idE = Int32.Parse(apTemp["yearidEnd"]);
                int idD = Int32.Parse(apTemp["yearidDepth"]);

                for (int yearid = idS; yearid <= idE; yearid++)
                {
                    int id = yearid % 100;
                    if (id > idD)
                    {
                        yearid = (yearid / 100) * 100 + 101;
                        continue;
                    }
                    AqiParam ap = new AqiParam(apTemp.Name + "\\" + yearid);
                    ap.Add("", yearid.ToString());
                    apList.Add(ap);
                }
            }

            return apList;
        }

        #endregion

        #region 重写方法

        /// <summary>
        /// 加载参数
        ///     读取JSON中的depthsParams字段
        /// </summary>
        /// <returns></returns>
        public override bool LoadParams()
        {
            this.listParamCache = this.loadDepthsParams();
            this.dtParamCacheTime = AqiParam.ReadWriteTimeFormJson(this);

            return true;
        }

        #endregion

    }
}
