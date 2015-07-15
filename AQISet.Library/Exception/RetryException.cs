using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQI.Exception
{
    public class RetryException : System.Exception
    {
        public RetryException()
            : base()
        {

        }

        public RetryException(string message, System.Exception innerException) 
            : base(message, innerException) { }
    }
}
