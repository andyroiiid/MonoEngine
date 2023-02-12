using System.Collections.Generic;

namespace MonoEngine
{
    public static class VertexUtils
    {
        public static void AddRect(
            ICollection<Vertex2D> vertices,
            Vector2 p0, Vector2 p1,
            Vector2 uv0, Vector2 uv1,
            Color color
        )
        {
            var v00 = new Vertex2D(new Vector2(p0.X, p0.Y), new Vector2(uv0.X, uv0.Y), color);
            var v10 = new Vertex2D(new Vector2(p1.X, p0.Y), new Vector2(uv1.X, uv0.Y), color);
            var v01 = new Vertex2D(new Vector2(p0.X, p1.Y), new Vector2(uv0.X, uv1.Y), color);
            var v11 = new Vertex2D(new Vector2(p1.X, p1.Y), new Vector2(uv1.X, uv1.Y), color);
            vertices.Add(v00);
            vertices.Add(v10);
            vertices.Add(v01);
            vertices.Add(v01);
            vertices.Add(v10);
            vertices.Add(v11);
        }
    }
}