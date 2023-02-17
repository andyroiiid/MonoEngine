using System;
using System.Collections.Generic;
using MonoEngine.Core;
using MonoEngine.GL;

namespace MonoEngine.Tiles
{
    public class Tileset
    {
        public readonly Texture Texture;
        public readonly Vector2 TilePixelSize;

        private readonly TilesetGrids _grids;

        public Tileset(Texture texture, int cols, int rows)
        {
            Texture = texture;
            TilePixelSize = Texture.Size / new Vector2(cols, rows);
            _grids = new TilesetGrids(cols, rows);
        }

        public Rect GetTileUvRect(int index) => _grids[index];

        public struct TileDrawCall
        {
            public readonly int Index;
            public readonly Vector2 Position;
            public readonly Color Color;

            public TileDrawCall(int index, in Vector2 position, in Color color)
            {
                Index = index;
                Position = position;
                Color = color;
            }
        }

        public Vertex2D[] BuildDrawCallTriangles(IList<TileDrawCall> drawCalls)
        {
            var vertices = new Vertex2D[drawCalls.Count * 6];
            var offset = 0;
            foreach (var drawCall in drawCalls)
            {
                VertexUtils.BuildRectTriangles(
                    new ArraySegment<Vertex2D>(vertices, offset, 6),
                    new Rect(drawCall.Position, TilePixelSize),
                    GetTileUvRect(drawCall.Index),
                    drawCall.Color
                );
                offset += 6;
            }

            return vertices;
        }
    }
}