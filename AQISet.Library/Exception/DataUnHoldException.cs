using System;

namespace AQI.Exception
{
    /// <summary>
    /// 数据未抓取
    /// </summary>
    public class DataUnHoldException : System.Exception
    {
        public DataUnHoldException(string message)
            : base(message)
        { }

        public DataUnHoldException(string message, System.Exception innerException) 
            : base(message, innerException) 
        { }
    }
}
