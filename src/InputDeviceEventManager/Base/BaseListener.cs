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

            this.hookHandle = HookNativeMethods.SetWindowsHookEx((int)this.hookId, (x,y,z)=> {
                Console.WriteLine(x.ToString());
                return HookNativeMethods.CallNextHookEx((int)hookId, x, y, z);
            }, source,
               0);

            if (this.hookHandle.IsInvalid)
            {
                var errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode);
            }
        }

        private IntPtr HookTrigger(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return HookNativeMethods.CallNextHookEx((int)hookId, nCode, wParam, lParam);
        }

        protected abstract IntPtr HookTempleteMethod(int nCode, IntPtr wParam, IntPtr lParam);

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                this.hookHandle.Dispose();
                return;
            }

            base.Dispose(disposing);
        }
    }
}
