using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQI.Exception
{
    /// <summary>
    /// 参数异常
    /// </summary>
    public class ParamException : System.Exception
    {
        public ParamException()
            : base()
        {

        }

        public ParamException(string message)
            : base(message) { }

        public ParamException(string message, System.Exception innerException) 
            : base(message, innerException) { }
    }
}
