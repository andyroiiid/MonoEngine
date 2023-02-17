using System;
using MonoEngine.Core;
using MonoEngine.GL;

namespace MonoEngine
{
    public class BitmapFont
    {
        private readonly TextureGridAtlas _atlas;

        public BitmapFont(Texture texture)
        {
            _atlas = new TextureGridAtlas(texture, 16, 16);
        }

        private Vertex2D[] BuildTextVertices(string text, in Color color)
        {
            var position = Vector2.Zero;
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
            DynamicRenderer.DrawVertices(BuildTextVertices(text, color), Primitive.Triangles, position);
        }
    }
}