namespace InputDeviceEventManager.Keyboard
{
    using System;
    using System.Runtime.InteropServices;
    using Base;
    using Win32;

    internal class KeyboardListener : BaseListener
    {
        public KeyboardListener()
            :base(HookId.WH_KEYBOARD_LL)
        {
        }

        public event KeyboardEventDeledate KeyDown;
        public event KeyboardEventDeledate KeyUp;
        public event KeyboardEventDeledate SystemKeyDown;
        public event KeyboardEventDeledate SystemKeyUp;
        public event KeyboardEventDeledate Action;

        protected override IntPtr HookTrigger(int nCode, IntPtr wParam, IntPtr lParam)
        {
            KeyboardMessages keyboardMessage = (KeyboardMessages)wParam.ToInt32();
            KeyboardMessageData keyboardMessageData = (KeyboardMessageData)Marshal.PtrToStructure(lParam, typeof(KeyboardMessageData));
            var keyboardEventArgs = new KeyboardEventArgs(keyboardMessage, keyboardMessageData.VkCode);

            switch(keyboardMessage)
            {
                case KeyboardMessages.WM_KEYDOWN:
                    this.KeyDown?.Invoke(this, keyboardEventArgs);
                    break;
                case KeyboardMessages.WM_KEYUP:
                    this.KeyUp?.Invoke(this, keyboardEventArgs);
                    break;
                case KeyboardMessages.WM_SYSKEYDOWN:
                    this.SystemKeyDown?.Invoke(this, keyboardEventArgs);
                    break;
                case KeyboardMessages.WM_SYSKEYUP:
                    this.SystemKeyUp?.Invoke(this, keyboardEventArgs);
                    break;
            }

            this.Action?.Invoke(this, keyboardEventArgs);

            return HookNativeMethods.CallNextHookEx((int)HookId.WH_KEYBOARD_LL, nCode, wParam, lParam);
        }
    }
}
