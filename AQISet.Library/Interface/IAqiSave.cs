using AQI;
using AQI.Interface;
using System;

namespace AQI.Interface
{
    /// <summary>
    /// 保存者 接口
    /// </summary>
    public interface IAqiSave
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 类型
        /// </summary>
        string SaverType{ get; }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="isu">数据源</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        bool Save(ISrcUrl isu, byte[] data);

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="isu">数据源</param>
        /// <param name="param">参数</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        bool Save(ISrcUrl isu, AqiParam param, byte[] data);
    }
}
