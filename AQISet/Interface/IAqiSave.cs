using AQI.Interface;
using System;

namespace AQISet.Interface
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
        /// <param name="grouptag">分组标签</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        bool Save(ISrcUrl isu, string grouptag, byte[] data);
    }
}
