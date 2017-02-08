namespace InputDeviceEventManager.MessageLoop
{
    using System.Threading;
    using System.Windows.Forms;
    using Base;

    internal class WindowsFormsMessageLoop : BaseDisposableClass, IMessageLoop
    {
        private Thread worker;

        public bool IsRunning { get; private set; }

        public void Start()
        {
            this.worker = new Thread(this.Work);
            this.worker.Start();
        }

        public void Stop()
        {
            if (!this.IsRunning)
            {
                return;
            }

            try
            {
                Application.Exit();
            }
            catch
            { }

            if (this.worker != null && !this.worker.Join(1000))
            {
                this.worker.Abort();
                this.worker = null;
            }

            this.IsRunning = false;
        }

        private void Work()
        {
            this.IsRunning = true;
            Application.Run();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
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
