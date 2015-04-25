using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI.Abstract;
using AQI.Interface;

namespace QH
{
    public class QHAqi: ABaseAqiWeb, IAqiWeb
    {

        #region 静态字段

        private static string Name = "(青海省)海西州空气质量实时发布系统";
        private static string Tag = "qhHaixi";
        private static string Url = "http://61.133.239.78:82/";
        private static AQI.AqiConstant.SourceLevel Src = AQI.AqiConstant.SourceLevel.CITY;
        private static AQI.AqiConstant.DataType Dat = AQI.AqiConstant.DataType.XML;
        private static string[] SrcNameSpace = new string[]{
            "QHHX.EnvCityPublishDomainService"
        };
        

        #endregion

        #region 属性

        public override string NAME
        {
            get
            {
                return Name;
            }
        }
        public override string TAG
        {
            get
            {
                return Tag;
            }
        }
        public override string URL
        {
            get
            {
                return Url;
            }
        }
        public override AQI.AqiConstant.SourceLevel SRC
        {
            get
            {
                return Src;
            }
        }
        public override AQI.AqiConstant.DataType DAT
        {
            get
            {
                return Dat;
            }
        }
        
        #endregion

        public QHAqi()
        {
            allSrcNames = new List<string>();
            foreach(string ns in SrcNameSpace)
            {
                allSrcNames.AddRange(getAllClass(ns));
            }
            allSrcNames.Sort();
        }

    }
}
