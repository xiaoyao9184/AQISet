using System;
using System.Collections.Generic;
using System.Reflection;
using AQI.Interface;
using AQI.Abstract;

namespace aqicn
{
    public class aqicn : ABaseAqiWeb, IAqiWeb
    {

        #region 静态字段

        private static string Name = "aqicn";
        private static string Tag = "aqicn";
        private static string Url = "http://aqicn.org/";
        private static AQI.AqiConstant.SourceLevel Src = AQI.AqiConstant.SourceLevel.OTHER;
        private static AQI.AqiConstant.DataType Dat = AQI.AqiConstant.DataType.JSON;
        private static string[] SrcNameSpace = new string[]{
            "aqicn.Station"
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

        public aqicn()
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
