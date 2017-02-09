namespace InputDeviceEventManager.Base
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using Win32;

    internal abstract class BaseListener : BaseDisposableClassWithFinalizer
    {
        private readonly HookId hookId;
        private readonly HookHandle hookHandle;

        public BaseListener(HookId hookId)
        {
            this.hookId = hookId;
            var source = HookNativeMethods.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);

            this.hookHandle = HookNativeMethods.SetWindowsHookEx((int)this.hookId, this.Hook, source, 0);

            if (this.hookHandle.IsInvalid)
            {
                var errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode);
            }
        }

        private IntPtr Hook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return this.HookTrigger(nCode, wParam, lParam);
        }

        protected abstract IntPtr HookTrigger(int nCode, IntPtr wParam, IntPtr lParam);

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            hookHandle.Dispose();

            base.Dispose(disposing);
        }
    }
}
