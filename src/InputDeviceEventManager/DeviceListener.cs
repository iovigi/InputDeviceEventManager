namespace InputDeviceEventManager
{
    using System.Threading;
    using Base;
    using Mouse;
    using Keyboard;
    using MessageLoop;

    public class DeviceListener : BaseDisposableClass
    {
        private readonly object syncRoot = new object();

        private Thread worker;

        private IMessageLoop messageLoop;
        private KeyboardListener keyboardListener;
        private MouseListener mouseListener;

        public DeviceListener()
        {
            this.keyboardListener = new KeyboardListener();
            this.mouseListener = new MouseListener();
            this.messageLoop = new WindowsFormsMessageLoop();
        }

        public event MouseEventDeledate MouseLeftButtonDown
        {
            add
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.LeftButtonDown += value;
                }
            }
            remove
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.LeftButtonDown -= value;
                }
            }
        }

        public event MouseEventDeledate MouseLeftButtonUp
        {
            add
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.LeftButtonUp += value;
                }
            }
            remove
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.LeftButtonUp -= value;
                }
            }
        }

        public event MouseEventDeledate MouseMove
        {
            add
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.Move += value;
                }
            }
            remove
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.Move -= value;
                }
            }
        }

        public event MouseEventDeledate MouseWheelRotate
        {
            add
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.WheelRotate += value;
                }
            }
            remove
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.WheelRotate -= value;
                }
            }
        }

        public event MouseEventDeledate MouseHorizontalWheelRotate
        {
            add
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.HorizontalWheelRotate += value;
                }
            }
            remove
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.HorizontalWheelRotate -= value;
                }
            }
        }

        public event MouseEventDeledate MouseRightButtonDown
        {
            add
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.RightButtonDown += value;
                }
            }
            remove
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.RightButtonDown -= value;
                }
            }
        }

        public event MouseEventDeledate MouseRightButtonUp
        {
            add
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.RightButtonUp += value;
                }
            }
            remove
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.RightButtonUp -= value;
                }
            }
        }

        public event MouseEventDeledate MouseAction
        {
            add
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.Action += value;
                }
            }
            remove
            {
                var mouseListener = this.mouseListener;

                if (mouseListener != null)
                {
                    mouseListener.Action -= value;
                }
            }
        }

        public event KeyboardEventDeledate KeyboardKeyDown
        {
            add
            {
                var keyboardListener = this.keyboardListener;

                if (keyboardListener != null)
                {
                    keyboardListener.KeyDown += value;
                }
            }
            remove
            {
                var keyboardListener = this.keyboardListener;

                if (keyboardListener != null)
                {
                    keyboardListener.KeyDown -= value;
                }
            }
        }

        public event KeyboardEventDeledate KeyboardKeyUp
        {
            add
            {
                var keyboardListener = this.keyboardListener;

                if (keyboardListener != null)
                {
                    keyboardListener.KeyUp += value;
                }
            }
            remove
            {
                var keyboardListener = this.keyboardListener;

                if (keyboardListener != null)
                {
                    keyboardListener.KeyUp -= value;
                }
            }
        }

        public event KeyboardEventDeledate KeyboardSystemKeyDown
        {
            add
            {
                var keyboardListener = this.keyboardListener;

                if (keyboardListener != null)
                {
                    keyboardListener.SystemKeyDown += value;
                }
            }
            remove
            {
                var keyboardListener = this.keyboardListener;

                if (keyboardListener != null)
                {
                    keyboardListener.SystemKeyDown -= value;
                }
            }
        }

        public event KeyboardEventDeledate KeyboardSystemKeyUp
        {
            add
            {
                var keyboardListener = this.keyboardListener;

                if (keyboardListener != null)
                {
                    keyboardListener.SystemKeyUp += value;
                }
            }
            remove
            {
                var keyboardListener = this.keyboardListener;

                if (keyboardListener != null)
                {
                    keyboardListener.SystemKeyUp -= value;
                }
            }
        }

        public event KeyboardEventDeledate KeyboardAction
        {
            add
            {
                var keyboardListener = this.keyboardListener;

                if (keyboardListener != null)
                {
                    keyboardListener.Action += value;
                }
            }
            remove
            {
                var keyboardListener = this.keyboardListener;

                if (keyboardListener != null)
                {
                    keyboardListener.Action -= value;
                }
            }
        }

        public void StartListen()
        {
            this.worker = new Thread(() =>
           {
               this.keyboardListener.Hook();
               this.mouseListener.Hook();

               this.messageLoop.Start();
           });

            worker.Start();
        }

        public void StopListen()
        {
            this.messageLoop.Stop();

            const int timeOfWaitingToStop = 1000;//1 second

            if (this.worker != null && !this.worker.Join(timeOfWaitingToStop))
            {
                try
                {
                    this.worker.Abort();
                    this.worker = null;
                }
                catch
                { }
            }

            this.mouseListener.UnHook();
            this.keyboardListener.UnHook();
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
