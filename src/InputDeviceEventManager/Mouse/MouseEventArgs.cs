namespace InputDeviceEventManager.Mouse
{
    public class MouseEventArgs
    {
        public MouseEventArgs(MouseMessages mouseMessage, Point point)
        {
            this.MouseMessage = mouseMessage;
            this.Point = point;
        }

        public MouseMessages MouseMessage { get; private set; }
        public Point Point { get; private set; }
    }
}
