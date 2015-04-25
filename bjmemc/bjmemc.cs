using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI.Abstract;
using AQI.Interface;

namespace bjmemc
{
    public class bjmemc : ABaseAqiWeb, IAqiWeb
    {

        #region 静态字段

        private static string Name = "北京空气质量";
        private static string Tag = "bjmemc";
        private static string Url = "http://zx.bjmemc.com.cn/";
        private static AQI.AqiConstant.SourceLevel Src = AQI.AqiConstant.SourceLevel.CITY;
        private static AQI.AqiConstant.DataType Dat = AQI.AqiConstant.DataType.JSON;
        private static string[] SrcNameSpace = new string[]{
            "bjmemc.DataService"
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

        public bjmemc()
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
