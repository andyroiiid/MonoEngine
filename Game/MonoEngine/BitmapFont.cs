using System.Collections.Generic;

namespace MonoEngine
{
    public class BitmapFont
    {
        private const int NumCols = 16;
        private const int NumRows = 16;
        private const int NumGrids = NumCols * NumRows;
        private readonly static Vector2 GridUvSize = new Vector2(1.0f / NumCols, 1.0f / NumRows);
        private readonly static List<Vector2> TexCoords = new List<Vector2>(NumGrids);

        static BitmapFont()
        {
            for (var c = 0; c < NumGrids; c++)
            {
                var col = c % NumCols;
                var row = NumRows - 1 - c / NumCols;
                TexCoords.Add(new Vector2(col * GridUvSize.X, row * GridUvSize.Y));
            }
        }

        private readonly Texture _texture;
        private readonly Vector2 _charPixelSize;

        public BitmapFont(Texture texture)
        {
            _texture = texture;
            _charPixelSize = _texture.Size * GridUvSize;
        }

        private List<Vertex2D> BuildTextVertices(string text, Vector2 position, Color color)
        {
            var vertices = new List<Vertex2D>(text.Length * 6);
            foreach (var c in text)
            {
                if (!char.IsWhiteSpace(c))
                {
                    var texCoord = TexCoords[c];
                    VertexUtils.AddRect(
                        vertices,
                        position,
                        position + _charPixelSize,
                        texCoord,
                        texCoord + GridUvSize,
                        color
                    );
                }

                position.X += _charPixelSize.X;
            }

            return vertices;
        }

        public void DrawText(string text, Vector2 position, Color color)
        {
            var vertices = BuildTextVertices(text, position, color);
            _texture.Bind(0);
            Renderer2D.DrawTriangles(vertices.ToArray());
        }
    }
}