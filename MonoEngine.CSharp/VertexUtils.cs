using System.Collections.Generic;
using MonoEngine.Core;

namespace MonoEngine
{
    public static class VertexUtils
    {
        public static void BuildRectTriangleStrip(
            IList<Vertex2D> fourVertices,
            in Rect rect,
            in Rect uvRect,
            in Color color
        )
        {
            fourVertices[0] = new Vertex2D(rect.P00, uvRect.P00, color);
            fourVertices[1] = new Vertex2D(rect.P10, uvRect.P10, color);
            fourVertices[2] = new Vertex2D(rect.P01, uvRect.P01, color);
            fourVertices[3] = new Vertex2D(rect.P11, uvRect.P11, color);
        }

        public static void BuildRectTriangles(
            IList<Vertex2D> sixVertices,
            in Rect rect,
            in Rect uvRect,
            in Color color
        )
        {
            var v00 = new Vertex2D(rect.P00, uvRect.P00, color);
            var v10 = new Vertex2D(rect.P10, uvRect.P10, color);
            var v01 = new Vertex2D(rect.P01, uvRect.P01, color);
            var v11 = new Vertex2D(rect.P11, uvRect.P11, color);
            sixVertices[0] = v00;
            sixVertices[1] = v10;
            sixVertices[2] = v01;
            sixVertices[3] = v01;
            sixVertices[4] = v10;
            sixVertices[5] = v11;
        }
    }
}