using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQISet.Cfg
{
    public class Language
    {
        public static Dictionary<double, string> SomeTime = new Dictionary<double, string>(){
            { AQI.AqiConstant.DAY7, "7天" },
            { AQI.AqiConstant.DAY, "天" },
            { AQI.AqiConstant.HOUR12, "12小时" },
            { AQI.AqiConstant.HOUR, "小时" },
            { AQI.AqiConstant.MINUTE30, "30分钟" },
            { AQI.AqiConstant.MINUTE, "分钟" },
            { -1, "" }
        };

        /// <summary>
        /// 将时间转为文字
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string GetSomeTime(double time)
        {
            string timename = SomeTime[time];

            if (timename == null)
            {
                TimeSpan ts = new TimeSpan(0, 0, (int)time);
                timename = ts.ToString("dd'天'hh'小时'mm'分钟'ss'秒'");
            }
            else if (timename == "")
            {
                timename = "手动";
            }
            else
            {
                timename = "每" + timename;
            }

            return timename;
        }



    }
}
