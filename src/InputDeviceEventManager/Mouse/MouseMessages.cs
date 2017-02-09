namespace InputDeviceEventManager.Mouse
{
    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms644986(v=vs.85).aspx
    /// </summary>
    public enum MouseMessages : int
    {
        //Posted when the user presses the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        WM_LBUTTONDOWN = 0x0201,

        //Posted when the user releases the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        WM_LBUTTONUP = 0x0202,

        //Posted to a window when the cursor moves. If the mouse is not captured, the message is posted to the window that contains the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        WM_MOUSEMOVE = 0x0200,

        //Sent to the focus window when the mouse wheel is rotated. The DefWindowProc function propagates the message to the window's parent. There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
        WM_MOUSEWHEEL = 0x020A,

        //Sent to the active window when the mouse's horizontal scroll wheel is tilted or rotated. The DefWindowProc function propagates the message to the window's parent. There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
         WM_MOUSEHWHEEL = 0x020E,

        //Posted when the user presses the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        WM_RBUTTONDOWN = 0x0204,

        //Posted when the user releases the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        WM_RBUTTONUP = 0x0205
    }
}
