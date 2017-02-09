namespace InputDeviceEventManager.MessageLoop
{
    using System.Windows.Forms;
    using Base;

    internal class WindowsFormsMessageLoop : BaseDisposableClass, IMessageLoop
    {
        private ApplicationContext applicationContext;

        public bool IsRunning { get; private set; }

        public void Start()
        {
            this.IsRunning = true;
            this.applicationContext = new ApplicationContext();

            Application.Run(this.applicationContext);
        }

        public void Stop()
        {
            if (!this.IsRunning)
            {
                return;
            }

            try
            {
                if (this.applicationContext != null)
                {
                    this.applicationContext.ExitThread();
                }
            }
            catch
            { }

            this.applicationContext = null;
            this.IsRunning = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.Stop();
            }

            base.Dispose(disposing);
        }
    }
}
