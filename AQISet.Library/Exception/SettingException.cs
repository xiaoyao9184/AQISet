using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQI.Exception
{
    public class SettingException : System.Exception
    {
        public SettingException()
            : base()
        {

        }

        public SettingException(string message, System.Exception innerException) 
            : base(message, innerException) { }
    }
}
