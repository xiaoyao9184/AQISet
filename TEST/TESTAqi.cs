using System;
using System.Collections.Generic;
using System.Reflection;
using AQI;
using AQI.Abstract;
using AQI.Interface;

namespace TEST
{
    public class TESTAqi : ABaseAqiWeb, IAqiWeb
    {
        #region 静态字段

        private static string Name = "测试";
        private static string Tag = "test";
        private static string Url = "http://127.0.0.1/";
        private static AQI.AqiConstant.SourceLevel Src = AQI.AqiConstant.SourceLevel.OTHER;
        private static AQI.AqiConstant.DataType Dat = AQI.AqiConstant.DataType.TEXT;
        private static string[] SrcNameSpace = new string[]{
            "TEST.dotest"
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

        public TESTAqi()
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
