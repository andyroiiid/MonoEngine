using System.Runtime.InteropServices;
using MonoEngine.Core;

namespace MonoEngine.Bindings
{
    public static class Window
    {
        private const string Prefix = "Window_";

        [DllImport("__Internal", EntryPoint = Prefix + "Close")]
        public static extern void Close();

        [DllImport("__Internal", EntryPoint = Prefix + "SetCursor")]
        private static extern void SetCursor(bool enabled);

        [DllImport("__Internal", EntryPoint = Prefix + "GetMousePos")]
        private static extern void GetMousePos(out Vector2 mousePos);

        [DllImport("__Internal", EntryPoint = Prefix + "GetKey")]
        public static extern bool GetKey(int key);

        public static bool Cursor
        {
            set => SetCursor(value);
        }

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