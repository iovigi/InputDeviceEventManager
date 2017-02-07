namespace InputDeviceEventManager.Base
{
    using System;

    internal class BaseDisposableClassWithFinalizer : IDisposable
    {
        protected bool disposed = false;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            disposed = true;
        }
    }
}
