namespace InputDeviceEventManager.Keyboard
{
    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms644985(v=vs.85).aspx
    /// </summary>
    public enum KeyboardMessages : int
    {
        WM_KEYDOWN = 0x0100,//Posted to the window with the keyboard focus when a nonsystem key is pressed. A nonsystem key is a key that is pressed when the ALT key is not pressed. 

        WM_KEYUP = 0x0101,//Posted to the window with the keyboard focus when a nonsystem key is released. A nonsystem key is a key that is pressed when the ALT key is not pressed, or a keyboard key that is pressed when a window has the keyboard focus. 

        WM_SYSKEYDOWN = 0x0104,//Posted to the window with the keyboard focus when the user presses the F10 key (which activates the menu bar) or holds down the ALT key and then presses another key. It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYDOWN message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter. 

        WM_SYSKEYUP = 0x0105,//Posted to the window with the keyboard focus when the user releases a key that was pressed while the ALT key was held down. It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYUP message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter. 
    }
}
