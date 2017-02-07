namespace InputDeviceEventManager.Mouse
{
    using System;
    using Base;
    using Win32;

    internal class MouseListener : BaseListener
    {
        public MouseListener()
              : base(HookId.WH_MOUSE_LL)
        {
        }

        protected override IntPtr HookTempleteMethod(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return HookNativeMethods.CallNextHookEx((int)HookId.WH_MOUSE_LL, nCode, wParam, lParam);
        }
    }
}
