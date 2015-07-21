using AQI;
using AQI.Abstract;
using AQI.Interface;
using Helper.Util.HTTP;
using SD.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SD.AirQuality
{
    public class GetStationList : AirQuality_POST, IDataType
    {

        #region 静态变量

        private static string tag = "GetStationList";
        private static string name = "山东AQI站点列表";
        private static string url = "http://58.56.98.78:8801/AirDeploy.web/Ajax/AirQuality/AirQuality.ashx";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.NONE;
        private static List<string> pnList = new List<string>(){
            ".Method"
        };
        private static new AqiConstant.ParamSendType pst = AqiConstant.ParamSendType.POST;
        private static new AqiConstant.ParamUrlType put = AqiConstant.ParamUrlType.KEY_VALUE;

        private static AqiConstant.DataType dat = AqiConstant.DataType.XML;

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
                return pnList;
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

        #region IDataType

        public virtual AqiConstant.DataType DAT
        {
            get
            {
                return dat;
            }
        }

        #endregion

    }
}
