namespace InputDeviceEventManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Base;
    using Mouse;
    using Keyboard;

    public class DeviceListener : BaseDisposableClass
    {
        private HookEventManager hookEventManager;
        private MouseListener mouseListener;
        private KeyboardListener keyboardListener;

        public void StartListen()
        {
            this.hookEventManager = new HookEventManager();
            this.mouseListener = new MouseListener(this.hookEventManager);
            this.keyboardListener = new KeyboardListener(this.hookEventManager);
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
        }
    }
}
