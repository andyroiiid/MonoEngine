using System.Runtime.InteropServices;
using MonoEngine.Core;

namespace MonoEngine.Bindings
{
    public static class Window
    {
        private const string Prefix = "Window_";

        [DllImport("__Internal", EntryPoint = Prefix + "SetTitle")]
        private static extern void SetTitle(string title);

        public static string Title
        {
            set => SetTitle(value);
        }

        [DllImport("__Internal", EntryPoint = Prefix + "SetSize")]
        public static extern void SetSize(int width, int height);

        [DllImport("__Internal", EntryPoint = Prefix + "SetCursor")]
        private static extern void SetCursor(bool enabled);

        public static bool Cursor
        {
            set => SetCursor(value);
        }

        [DllImport("__Internal", EntryPoint = Prefix + "Close")]
        public static extern void Close();

        [DllImport("__Internal", EntryPoint = Prefix + "GetTime")]
        private static extern float GetTime();

        public static float Time => GetTime();

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

        [DllImport("__Internal", EntryPoint = Prefix + "GetKey")]
        public static extern bool GetKey(int key);
    }
}