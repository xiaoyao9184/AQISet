using System;
using System.Collections.Generic;
using System.Reflection;
using AQI;
using AQI.Abstract;
using AQI.Interface;

namespace SX
{
    public class SXAqi: ABaseAqiWeb, IAqiWeb
    {

        #region 静态字段

        private static string Name = "陕西省空气质量实时发布系统";
        private static string Tag = "sxAQIWeb";
        private static string Url = "http://113.140.66.226:8024/sxAQIWeb";
        private static AQI.AqiConstant.SourceLevel Src = AQI.AqiConstant.SourceLevel.PROVINCIAL;
        private static AQI.AqiConstant.DataType Dat = AQI.AqiConstant.DataType.XML;
        private static string[] SrcNameSpace = new string[]{
            "SX.City","SX.Station"
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

        public SXAqi()
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
