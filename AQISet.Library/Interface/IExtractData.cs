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
        /// <returns>提取后的数据</returns>
        byte[] ExtractData(byte[] data);
    }
}
