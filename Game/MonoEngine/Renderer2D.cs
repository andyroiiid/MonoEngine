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

        public static void DrawRect(Vector2 p0, Vector2 p1, Color color)
        {
            DrawTriangleStrip(
                new[]
                {
                    new Vertex2D(new Vector2(p0.X, p0.Y), new Vector2(0.0f, 0.0f), color),
                    new Vertex2D(new Vector2(p1.X, p0.Y), new Vector2(1.0f, 0.0f), color),
                    new Vertex2D(new Vector2(p0.X, p1.Y), new Vector2(0.0f, 1.0f), color),
                    new Vertex2D(new Vector2(p1.X, p1.Y), new Vector2(1.0f, 1.0f), color),
                }
            );
        }

        public static void DrawRect(Vector2 p0, Vector2 p1, float transparency = 1.0f)
        {
            DrawRect(p0, p1, Color.TransparentWhite(transparency));
        }
    }
}