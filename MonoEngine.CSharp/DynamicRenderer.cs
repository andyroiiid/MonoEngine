using System;
using MonoEngine.Core;
using MonoEngine.GL;

namespace MonoEngine
{
    public static class DynamicRenderer
    {
        private readonly static Lazy<VertexBuffer2D> Vertices = new Lazy<VertexBuffer2D>();

        public static void DrawVertices(Vertex2D[] vertices, Primitive primitive)
        {
            Vertices.Value.UpdateData(vertices);
            Vertices.Value.BindAndDraw(primitive);
        }

        public static void DrawRect(in Rect rect, in Rect uvRect)
        {
            var vertices = new Vertex2D[4];
            VertexUtils.BuildRectTriangleStrip(vertices, rect, uvRect, Color.White);
            DrawVertices(vertices, Primitive.TriangleStrip);
        }
    }
}