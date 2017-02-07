namespace InputDeviceEventManager.Win32
{
    using System;
    using System.Runtime.InteropServices;

    public static class HookNativeMethods
    {
        private const string USER_32_DLL = "user32.dll";

        /// <summary>
        /// Installs an application-defined hook procedure into a hook chain. You would install a hook procedure to monitor the system for certain types of events. These events are associated either with a specific thread or with all threads in the same desktop as the calling thread. 
        /// </summary>
        /// <param name="idHook">The type of hook procedure to be installed. This parameter can be one of the following values.</param>
        /// <param name="lpfn">Type: HOOKPROC. A pointer to the hook procedure.If the dwThreadId parameter is zero or specifies the identifier of a thread created by a different process, the lpfn parameter must point to a hook procedure in a DLL.Otherwise, lpfn can point to a hook procedure in the code associated with the current process.</param>
        /// <param name="hInstance">Type: HINSTANCE. A handle to the DLL containing the hook procedure pointed to by the lpfn parameter.The hMod parameter must be set to NULL if the dwThreadId parameter specifies a thread created by the current process and if the hook procedure is within the code associated with the current process.</param>
        /// <param name="threadId">Type: DWORD. The identifier of the thread with which the hook procedure is to be associated.For desktop apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the same desktop as the calling thread.For Windows Store apps, see the Remarks section.</param>
        /// <returns>Type: HHOOK. If the function succeeds, the return value is the handle to the hook procedure. If the function fails, the return value is NULL.To get extended error information, call GetLastError.</returns>
        //<remarks>https://msdn.microsoft.com/en-us/library/windows/desktop/ms644990(v=vs.85).aspx</remarks>
        [DllImport(USER_32_DLL, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern HookHandle SetWindowsHookEx(int idHook, HookProc lpfn,
        IntPtr hInstance, int threadId);

        /// <summary>
        /// Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function. 
        /// </summary>
        /// <param name="idHook">Type: HHOOK. A handle to the hook to be removed.This parameter is a hook handle obtained by a previous call to SetWindowsHookEx.</param>
        /// <returns>Type: BOOL. If the function succeeds, the return value is nonzero.If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
        /// <remarks>https://msdn.microsoft.com/en-us/library/windows/desktop/ms644993(v=vs.85).aspx</remarks>
        [DllImport(USER_32_DLL, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr idHook);

        /// <summary>
        /// Passes the hook information to the next hook procedure in the current hook chain. A hook procedure can call this function either before or after processing the hook information. 
        /// </summary>
        /// <param name="idHook">Type: HHOOK. This parameter is ignored.</param>
        /// <param name="nCode">Type: int. The hook code passed to the current hook procedure.The next hook procedure uses this code to determine how to process the hook information.</param>
        /// <param name="wParam">Type: WPARAM. The wParam value passed to the current hook procedure.The meaning of this parameter depends on the type of hook associated with the current hook chain.</param>
        /// <param name="lParam">Type: LPARAM.The lParam value passed to the current hook procedure.The meaning of this parameter depends on the type of hook associated with the current hook chain.</param>
        /// <returns>Type: LRESULT. This value is returned by the next hook procedure in the chain.The current hook procedure must also return this value.The meaning of the return value depends on the hook type. For more information, see the descriptions of the individual hook procedures.</returns>
        /// <remarks>https://msdn.microsoft.com/en-us/library/windows/desktop/ms644974(v=vs.85).aspx</remarks>
        [DllImport(USER_32_DLL, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(int idHook, int nCode,
        IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        public static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
