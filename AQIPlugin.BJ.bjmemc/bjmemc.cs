using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI.Abstract;
using AQI.Interface;

namespace bjmemc
{
    public class bjmemc : ABaseAqiWeb
    {

        #region 静态字段

        private static string name = "北京空气质量";
        private static string tag = "bjmemc";
        private static string url = "http://zx.bjmemc.com.cn/";
        private static AQI.AqiConstant.SourceLevel src = AQI.AqiConstant.SourceLevel.CITY;
        private static AQI.AqiConstant.DataType dat = AQI.AqiConstant.DataType.JSON;
        private static string[] srcNameSpace = new string[]{
            "bjmemc.DataService"
        };
        

        #endregion

        #region 属性

        public override string Name
        {
            get
            {
                return name;
            }
        }
        public override string Tag
        {
            get
            {
                return tag;
            }
        }
        public override string Url
        {
            get
            {
                return url;
            }
        }
        public override string[] SrcUrlNameSpace
        {
            get
            {
                return srcNameSpace;
            }
        }
        public override AQI.AqiConstant.SourceLevel SRC
        {
            get
            {
                return src;
            }
        }
        public override AQI.AqiConstant.DataType DAT
        {
            get
            {
                return dat;
            }
        }
        
        #endregion

    }
}
