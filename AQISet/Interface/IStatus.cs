using System;

namespace AQISet.Interface
{
    /// <summary>
    /// 状态 接口
    /// </summary>
    public interface IStatus
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        string GetInfo();
    }
}

