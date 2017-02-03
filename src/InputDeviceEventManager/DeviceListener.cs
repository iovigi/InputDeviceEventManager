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
        private MouseListener mouseListener;
        private KeyboardListener keyboardListener;


        public void StartListen()
        {
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
        }
    }
}
