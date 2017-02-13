# InputDeviceEventManager
.NET Manager of events from mouse and keyboard.<br />
[![Build status](https://ci.appveyor.com/api/projects/status/njojqsefcsk9wu1o?svg=true)](https://ci.appveyor.com/project/iovigi/inputdeviceeventmanager)<br />
Nuget:https://www.nuget.org/packages/InputDeviceEventManager/1.0.1<br />
## Example:<br /> 
```C#
namespace InputDeviceEventManager.Example
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using InputDeviceEventManager;
    using Keyboard;
    using Mouse;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            DeviceListener deviceListener = new DeviceListener();
            deviceListener.StartListen();
            deviceListener.MouseAction += OnMouseAction;
            deviceListener.KeyboardAction += OnKeyboardAction;

            Console.ReadLine();
            deviceListener.StopListen();
        }

        private static void OnKeyboardAction(object sender, KeyboardEventArgs keyboardEventArgs)
        {
            Console.WriteLine(keyboardEventArgs.VirtualKeyCode);
        }

        private static void OnMouseAction(object sender, Mouse.MouseEventArgs mouseEventArgs)
        {
            Console.WriteLine(mouseEventArgs.Point.X);
        }
    }
}
```