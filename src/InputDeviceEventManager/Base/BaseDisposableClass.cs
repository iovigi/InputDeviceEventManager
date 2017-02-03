namespace InputDeviceEventManager.Base
{
    using System;

    public class BaseDisposableClass : IDisposable
    {
        private bool disposed = false;

        ~BaseDisposableClass()
        {
            this.Dispose(false);
        }

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
