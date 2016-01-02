using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQI.Interface
{
    /// <summary>
    /// 数据类型 接口
    ///     扩展AqiFileSaver
    /// </summary>
    public interface IDataType
    {
        AQI.AqiConstant.DataType DAT { get; }
    }
}
