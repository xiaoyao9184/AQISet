using System;
using FluorineFx.AMF3;

namespace FiddlerAmfParser.AMF3
{
    /// <summary>
    /// some expand for FluorineFx AMF3 ByteArray
    /// </summary>
    public static class ByteArrayEx
    {

        /// <summary>
        /// return a GUID string if byte length is 16 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToGUIDString(this ByteArray bytes)
        {
            if (bytes.Length == 16)
            {
                return new Guid(bytes.ToArray()).ToString();
            }
            else
            {
                return BitConverter.ToString(bytes.ToArray());
            }
        }
    }
}
