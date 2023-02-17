using System;
using MonoEngine.Bindings;
using MonoEngine.Core;
using MonoEngine.GL;

namespace MonoEngine
{
    public class BitmapFont
    {
        private readonly TextureGridAtlas _atlas;
        private readonly VertexBuffer2D _dynamicVertices;

        public BitmapFont(Texture texture)
        {
            _atlas = new TextureGridAtlas(texture, 16, 16);
            _dynamicVertices = new VertexBuffer2D();
        }

        private Vertex2D[] BuildTextVertices(string text, Vector2 position, in Color color)
        {
            var vertices = new Vertex2D[text.Length * 6];
            var offset = 0;
            foreach (var c in text)
            {
                if (!char.IsWhiteSpace(c))
                {
                    VertexUtils.BuildRectTriangles(
                        new ArraySegment<Vertex2D>(vertices, offset, 6),
                        new Rect(position, _atlas.GridPixelSize),
                        _atlas.GetGridUvRect(c),
                        color
                    );
                    offset += 6;
                }

                position.X += _atlas.GridPixelSize.X;
            }

            return vertices;
        }

        public void DrawText(string text, in Vector2 position, in Color color)
        {
            _atlas.Texture.Bind(0);
            _dynamicVertices.UpdateData(BuildTextVertices(text, position, color));
            _dynamicVertices.BindAndDraw(Primitive.Triangles);
        }
    }
}