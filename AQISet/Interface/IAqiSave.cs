using System;
using AQI.Interface;

namespace AQISet.Interface
{
    /// <summary>
    /// 保存接口
    /// </summary>
    public interface IAqiSave
    {
        string Name { get; }

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
