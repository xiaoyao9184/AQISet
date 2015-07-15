using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQI.Exception
{
    /// <summary>
    /// 配置异常
    /// </summary>
    public class ConfigException : System.Exception
    {
        public ConfigException()
            : base()
        {

        }

        public ConfigException(string message)
            : base(message) { }

        public ConfigException(string message, System.Exception innerException) 
            : base(message, innerException) { }
    }
}
