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

        [DllImport("__Internal", EntryPoint = Prefix + "DrawVertices")]
        private static extern void DrawVertices(Vertex2D[] vertices, int numVertices, int mode);

        public static void DrawLines(Vertex2D[] vertices)
        {
            DrawVertices(vertices, vertices.Length, GlConstants.Lines);
        }

        public static void DrawTriangles(Vertex2D[] vertices)
        {
            DrawVertices(vertices, vertices.Length, GlConstants.Triangles);
        }

        public static void DrawTriangleStrip(Vertex2D[] vertices)
        {
            DrawVertices(vertices, vertices.Length, GlConstants.TriangleStrip);
        }

        public static void DrawRect(in Rect rect, in Rect uvRect, in Color color)
        {
            var fourVertices = new Vertex2D[4];
            VertexUtils.BuildRectTriangleStrip(fourVertices, rect, uvRect, color);
            DrawTriangleStrip(fourVertices);
        }

        public static void DrawRect(in Rect rect, in Rect uvRect, float transparency = 1.0f)
        {
            DrawRect(rect, uvRect, Color.TransparentWhite(transparency));
        }

        public static void DrawRect(in Rect rect, in Color color)
        {
            DrawRect(rect, Rect.ZeroToOne, color);
        }

        public static void DrawRect(in Rect rect, float transparency = 1.0f)
        {
            DrawRect(rect, Color.TransparentWhite(transparency));
        }
    }
}