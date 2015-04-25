using System;

namespace AQISet.Exceptions
{
    /// <summary>
    /// 数据未抓取
    /// </summary>
    public class DataUnHoldException : ApplicationException
    {
        public DataUnHoldException(string message)
            : base(message)
        { }

        public DataUnHoldException(string message, Exception innerException) 
            : base(message, innerException) 
        { }
    }
}
