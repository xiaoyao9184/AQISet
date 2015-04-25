using System;
using System.Collections.Generic;
using System.Reflection;
using TJ.handler;
using AQI;
using AQI.Abstract;
using AQI.Interface;

namespace TJ
{
    public class TJAqi: ABaseAqiWeb, IAqiWeb
    {

        #region 静态字段

        private static string Name = "天津市环境空气质量GIS发布平台";
        private static string Tag = "tjemc";
        private static string Url = "http://air.tjemc.org.cn/";
        private static AQI.AqiConstant.SourceLevel Src = AQI.AqiConstant.SourceLevel.PROVINCIAL;
        private static AQI.AqiConstant.DataType Dat = AQI.AqiConstant.DataType.JSON;
        private static string[] SrcNameSpace = new string[]{
            "TJ.handler"
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

        public TJAqi()
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
