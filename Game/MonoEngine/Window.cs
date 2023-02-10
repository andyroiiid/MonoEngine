using System.Runtime.InteropServices;

namespace MonoEngine
{
    public static class Window
    {
        private const string Prefix = "Window_";

        [DllImport("__Internal", EntryPoint = Prefix + "ShowCursor")]
        public static extern void ShowCursor();

        [DllImport("__Internal", EntryPoint = Prefix + "HideCursor")]
        public static extern void HideCursor();

        [DllImport("__Internal", EntryPoint = Prefix + "GetMousePos")]
        private static extern void GetMousePos(out Vector2 mousePos);

        public static Vector2 MousePos
        {
            get
            {
                GetMousePos(out var mousePos);
                return mousePos;
            }
        }
    }
}