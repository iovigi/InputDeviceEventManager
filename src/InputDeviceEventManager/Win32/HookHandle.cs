namespace InputDeviceEventManager.Win32
{
    using System;
    using Microsoft.Win32.SafeHandles;

    public class HookHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public HookHandle()
            :base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            return HookNativeMethods.UnhookWindowsHookEx(handle);
        }
    }
}
