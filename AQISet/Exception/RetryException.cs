using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQISet.Exceptions
{
    public class RetryException : ApplicationException
    {
        public RetryException()
            : base()
        {

        }

        public RetryException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
