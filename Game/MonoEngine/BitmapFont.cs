using System;
using MonoEngine.Bindings;
using MonoEngine.Core;

namespace MonoEngine
{
    public class BitmapFont
    {
        private const int NumCols = 16;
        private const int NumRows = 16;
        private const int NumGrids = NumCols * NumRows;
        private readonly static Vector2 GridUvSize = new Vector2(1.0f / NumCols, 1.0f / NumRows);
        private readonly static Rect[] Grids = new Rect[NumGrids];

        static BitmapFont()
        {
            for (var c = 0; c < NumGrids; c++)
            {
                var col = c % NumCols;
                var row = NumRows - 1 - c / NumCols;
                Grids[c] = new Rect(new Vector2(col * GridUvSize.X, row * GridUvSize.Y), GridUvSize);
            }
        }

        private readonly Texture _texture;
        private readonly Vector2 _charPixelSize;

        public BitmapFont(Texture texture)
        {
            _texture = texture;
            _charPixelSize = _texture.Size * GridUvSize;
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
                        new Rect(position, _charPixelSize),
                        Grids[c],
                        color
                    );
                    offset += 6;
                }

                position.X += _charPixelSize.X;
            }

            return vertices;
        }

        public void DrawText(string text, in Vector2 position, in Color color)
        {
            _texture.Bind(0);
            Renderer2D.DrawTriangles(BuildTextVertices(text, position, color));
        }
    }
}