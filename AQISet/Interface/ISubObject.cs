using System;

namespace AQISet.Interface
{
    /// <summary>
    /// 子对象 接口
    /// </summary>
    public interface ISubObject
    {
        /// <summary>
        /// 根据名称获取子对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        object GetSubObject(string name);
    }
}

