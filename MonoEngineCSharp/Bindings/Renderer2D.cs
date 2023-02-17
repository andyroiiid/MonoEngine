using System.Runtime.InteropServices;
using MonoEngine.Core;

namespace MonoEngine.Bindings
{
    public static class Renderer2D
    {
        private const string Prefix = "Renderer2D_";

        [DllImport("__Internal", EntryPoint = Prefix + "SetClearColor")]
        private static extern void SetClearColor(float r, float g, float b, float a);

        public static void SetClearColor(in Color color) => SetClearColor(color.R, color.G, color.B, color.A);

        [DllImport("__Internal", EntryPoint = Prefix + "Clear")]
        public static extern void Clear();
    }
}