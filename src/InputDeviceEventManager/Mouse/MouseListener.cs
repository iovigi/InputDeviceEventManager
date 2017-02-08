namespace InputDeviceEventManager.Mouse
{
    using System;
    using Base;
    using Win32;
    using System.Runtime.InteropServices;

    internal class MouseListener : BaseListener
    {
        public MouseListener()
              : base(HookId.WH_MOUSE_LL)
        {
        }

        protected override IntPtr HookTrigger(int nCode, IntPtr wParam, IntPtr lParam)
        {
            MouseMessageData marshalledMouseStruct = (MouseMessageData)Marshal.PtrToStructure(lParam, typeof(MouseMessageData));

            return HookNativeMethods.CallNextHookEx((int)HookId.WH_MOUSE_LL, nCode, wParam, lParam);
        }
    }
}
