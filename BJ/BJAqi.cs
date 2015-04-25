using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI.Abstract;
using AQI.Interface;

namespace BJ
{
    public class BJAqi : ABaseAqiWeb, IAqiWeb
    {

        #region 静态字段

        private static string Name = "北京空气质量";
        private static string Tag = "bjemc";
        private static string Url = "http://zx.bjmemc.com.cn/";
        private static AQI.AqiSetting.SourceLevel Src = AQI.AqiSetting.SourceLevel.PROVINCIAL;
        private static AQI.AqiSetting.DataType Dat = AQI.AqiSetting.DataType.WCF;
        private static string[] SrcNameSpace = new string[]{
            "BJ.DataService"
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
        public override AQI.AqiSetting.SourceLevel SRC
        {
            get
            {
                return Src;
            }
        }
        public override AQI.AqiSetting.DataType DAT
        {
            get
            {
                return Dat;
            }
        }
        
        #endregion

        public BJAqi()
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
