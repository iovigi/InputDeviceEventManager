namespace InputDeviceEventManager.Base
{
    using System;

    public class BaseDisposableClass : IDisposable
    {
        protected bool disposed = false;

        public void Dispose()
        {
            this.Dispose(true);
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
