namespace AQISet.Interface
{
    using System;

    public interface IStatus
    {
        string GetInfo();

        string Name { get; }
    }
}

