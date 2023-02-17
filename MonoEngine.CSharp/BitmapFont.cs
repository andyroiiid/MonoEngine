using System.Collections.Generic;
using MonoEngine.Core;
using MonoEngine.GL;
using MonoEngine.Tiles;

namespace MonoEngine
{
    public class BitmapFont
    {
        private readonly Tileset _tileset;

        public BitmapFont(Texture texture)
        {
            _tileset = new Tileset(texture, 16, 16);
        }

        private Vertex2D[] BuildTextVertices(string text, in Color color)
        {
            var position = Vector2.Zero;
            var drawCalls = new List<Tileset.TileDrawCall>(text.Length);
            foreach (var c in text)
            {
                if (!char.IsWhiteSpace(c))
                {
                    drawCalls.Add(new Tileset.TileDrawCall(c, position, color));
                }

                position.X += _tileset.TilePixelSize.X;
            }

            return _tileset.BuildDrawCallTriangles(drawCalls);
        }

        public void DrawText(string text, in Vector2 position, in Color color)
        {
            _tileset.Texture.Bind(0);
            DynamicRenderer.DrawVertices(BuildTextVertices(text, color), Primitive.Triangles, position);
        }
    }
}