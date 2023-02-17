using MonoEngine.Core;

namespace MonoEngine
{
    public static class VertexUtils
    {
        public static void BuildRectTriangles(
            Vertex2D[] vertices,
            int offset,
            in Rect rect,
            in Rect uvRect,
            in Color color
        )
        {
            var v00 = new Vertex2D(rect.P00, uvRect.P00, color);
            var v10 = new Vertex2D(rect.P10, uvRect.P10, color);
            var v01 = new Vertex2D(rect.P01, uvRect.P01, color);
            var v11 = new Vertex2D(rect.P11, uvRect.P11, color);
            vertices[offset + 0] = v00;
            vertices[offset + 1] = v10;
            vertices[offset + 2] = v01;
            vertices[offset + 3] = v01;
            vertices[offset + 4] = v10;
            vertices[offset + 5] = v11;
        }
    }
}