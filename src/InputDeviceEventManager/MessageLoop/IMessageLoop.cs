namespace InputDeviceEventManager.MessageLoop
{
    using System;

    internal interface IMessageLoop : IDisposable
    {
        bool IsRunning { get; }

        void Start();
        void Stop();
    }
}
