using System.Runtime.InteropServices;
using MonoEngine.Core;

namespace MonoEngine.GL
{
    public static class ImmediateContext
    {
        private const string Prefix = "ImmediateContext_";

        [DllImport("__Internal", EntryPoint = Prefix + "SetClearColor")]
        private static extern void SetClearColor(float r, float g, float b, float a);

        public static Color ClearColor
        {
            set => SetClearColor(value.R, value.G, value.B, value.A);
        }

        [DllImport("__Internal", EntryPoint = Prefix + "Clear")]
        public static extern void Clear();

        private static readonly VertexBuffer2D DynamicVertices = new VertexBuffer2D();

        public static void DrawVertices(Vertex2D[] vertices, Primitive primitive)
        {
            DynamicVertices.UpdateData(vertices);
            DynamicVertices.BindAndDraw(primitive);
        }
    }
}