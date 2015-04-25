using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQISet.Exceptions
{
    public class SettingException : ApplicationException
    {
        public SettingException()
            : base()
        {

        }

        public SettingException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
