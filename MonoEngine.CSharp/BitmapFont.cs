using System.Collections.Generic;
using MonoEngine.Core;
using MonoEngine.Tiles;

namespace MonoEngine
{
    public class BitmapFont
    {
        private readonly Tileset _tileset;

        public BitmapFont(string filename)
        {
            _tileset = new Tileset(filename, 16, 16);
        }

        public void DrawText(string text, in Transform transform, in Color color)
        {
            var offset = Vector2.Zero;
            var drawCalls = new List<TileDrawCall>(text.Length);
            foreach (var c in text)
            {
                if (!char.IsWhiteSpace(c))
                {
                    drawCalls.Add(new TileDrawCall(c, offset, color));
                }

                offset.X += _tileset.TileSize.X;
            }

            _tileset.DrawTiles(drawCalls, transform);
        }
    }
}