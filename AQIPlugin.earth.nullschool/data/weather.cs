using AQI;
using AQI.Abstract;
using AQI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace earth.data
{
    public class weather : ABaseSrcUrl, IDataType
    {

        #region 静态变量

        private static string tag = "weather";
        private static string name = "nullschool的全球风图weather";
        private static string url = "http://earth.nullschool.net/data/weather/current/current-wind-surface-level-gfs-0.5.epak";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.HOUR;
        private static AqiConstant.HttpType httpType = AqiConstant.HttpType.GET;

        private static AqiConstant.DataType dat = AqiConstant.DataType.OTHER;

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
        public override AqiConstant.HttpType HT
        {
            get
            {
                return httpType;
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
