using System;
using AQISet.Collection;

namespace AQISet.Interface
{
    /// <summary>
    /// 抛出信息 接口
    /// </summary>
    public interface IThrowMessage
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 抛出事件
        /// </summary>
        /// <param name="runMessage">运行信息</param>
        /// <returns></returns>
        bool ThrowEvent(RunMessage runMessage);
        /// <summary>
        /// 抛出事件
        /// </summary>
        /// <param name="eType">信息类型</param>
        /// <param name="eMsg">信息内容</param>
        void ThrowEvent(RunMessage.RunType eType, string eMsg);
    }
}
