using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQI.Exception
{
    public class DataDifferentException : System.Exception
    {
        public DataDifferentException()
            : base() { }

        public DataDifferentException(string message)
            : base(message) { }

        public DataDifferentException(string message, System.Exception innerException) 
            : base(message, innerException) { }
    }
}
