namespace InputDeviceEventManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Base;
    using Mouse;
    using Keyboard;
    using MessageLoop;

    public class DeviceListener : BaseDisposableClass
    {
        private IMessageLoop messageLoop;
        private MouseListener mouseListener;
        private KeyboardListener keyboardListener;

        /// <summary>
        /// Creating device listener
        /// </summary>
        /// <param name="manageOwnMessageLoop">If this parameter is true, device listener will start own message loop and it can do big problem, if application have own message loop. If this parameter is false, device listener message loop of the application. This flag need to be true, if application doesn't have own message loop.</param>
        public DeviceListener(bool manageOwnMessageLoop = false)
        {
            this.ManageOwnMessageLoop = manageOwnMessageLoop;

            if (this.ManageOwnMessageLoop)
            {
                //TODO:create native message loop.
                this.messageLoop = new WindowsFormsMessageLoop();
            }
        }

        public bool ManageOwnMessageLoop { get; private set; }

        public void StartListen()
        {
            if(this.ManageOwnMessageLoop)
            {
                this.messageLoop.Start();
            }

            this.mouseListener = new MouseListener();
            this.keyboardListener = new KeyboardListener();
        }

        public void StopListen()
        {
            if (this.mouseListener != null)
            {
                this.mouseListener = null;
            }

            if (this.keyboardListener != null)
            {
                this.keyboardListener = null;
            }

            if (this.ManageOwnMessageLoop && this.messageLoop.IsRunning)
            {
                this.messageLoop.Stop();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.mouseListener.Dispose();
                this.mouseListener = null;
                this.keyboardListener.Dispose();
                this.keyboardListener = null;

                if (this.messageLoop != null)
                {
                    this.messageLoop.Dispose();
                    this.messageLoop = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}
