using System.Runtime.InteropServices;

namespace MonoEngine
{
    public static class Renderer2D
    {
        private const string Prefix = "Renderer2D_";

        [DllImport("__Internal", EntryPoint = Prefix + "SetClearColor")]
        public static extern void SetClearColor(float r, float g, float b, float a);

        [DllImport("__Internal", EntryPoint = Prefix + "Clear")]
        public static extern void Clear();

        [DllImport("__Internal", EntryPoint = Prefix + "DrawLine")]
        public static extern void DrawLine(float x0, float y0, float x1, float y1);

        public static void DrawLine(Vector2 p0, Vector2 p1) => DrawLine(p0.X, p0.Y, p1.X, p1.Y);

        [DllImport("__Internal", EntryPoint = Prefix + "FillRect")]
        public static extern void FillRect(float x0, float y0, float x1, float y1);

        public static void FillRect(Vector2 p0, Vector2 p1) => FillRect(p0.X, p0.Y, p1.X, p1.Y);
    }
}