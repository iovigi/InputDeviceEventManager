namespace InputDeviceEventManager.Keyboard
{
    using System;
    using Base;
    using Win32;

    internal class KeyboardListener : BaseListener
    {
        public KeyboardListener()
            :base(HookId.WH_KEYBOARD_LL)
        {
        }

        protected override IntPtr HookTrigger(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return HookNativeMethods.CallNextHookEx((int)HookId.WH_KEYBOARD_LL, nCode, wParam, lParam);
        }
    }
}
