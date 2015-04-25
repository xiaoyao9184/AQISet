using System;

namespace AQI.Interface
{
    /// <summary>
    /// 数据提取 接口
    /// </summary>
    public interface IExtractData
    {
        /// <summary>
        /// 数据提取
        /// </summary>
        /// <param name="data">源数据</param>
        /// <returns></returns>
        byte[] extractData(byte[] data);

    }
}
