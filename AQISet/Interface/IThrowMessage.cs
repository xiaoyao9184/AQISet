using System;
using AQISet.Collection;

namespace AQISet.Interface
{
    public interface IThrowMessage
    {
        string Name { get; }
        bool ThrowEvent(RunMessage runMessage);
        void ThrowEvent(RunMessage.RunType eType, string eMsg);
    }
}
