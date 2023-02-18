using System.Collections.Generic;
using MonoEngine.Core;
using MonoEngine.GL;
using MonoEngine.Shaders;

namespace MonoEngine.Tiles
{
    public class Tileset
    {
        public readonly Vector2 TileSize;

        private readonly Texture _texture;
        private readonly TilesetGrids _grids;

        public Tileset(string filename, int cols, int rows)
        {
            _texture = Texture.FromFile(filename);
            TileSize = _texture.Size / new Vector2(cols, rows);
            _grids = new TilesetGrids(cols, rows);
        }

        private void Draw(Vertex2D[] vertices, in Transform transform)
        {
            BaseShader.Use();
            BaseShader.SetTransform(transform);
            _texture.Bind(0);
            ImmediateContext.DrawVertices(vertices, Primitive.Triangles);
        }

        public void DrawTile(int index, in Transform transform, in Color color)
        {
            var vertices = new Vertex2D[6];
            VertexUtils.BuildRectTriangles(
                vertices,
                0,
                new Rect(Vector2.Zero, TileSize),
                _grids[index],
                color
            );

            Draw(vertices, transform);
        }

        public void DrawTiles(IList<TileDrawCall> drawCalls, in Transform transform)
        {
            var vertices = new Vertex2D[drawCalls.Count * 6];
            var offset = 0;
            foreach (var drawCall in drawCalls)
            {
                VertexUtils.BuildRectTriangles(
                    vertices,
                    offset,
                    new Rect(drawCall.Offset, TileSize),
                    _grids[drawCall.Index],
                    drawCall.Color
                );
                offset += 6;
            }

            Draw(vertices, transform);
        }
    }
}