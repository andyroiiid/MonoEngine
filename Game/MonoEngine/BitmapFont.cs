using System.Collections.Generic;
using System.Linq;

namespace MonoEngine
{
    public class BitmapFont
    {
        private const float OneOverSixteen = 1.0f / 16.0f;

        private readonly Texture _texture;
        private readonly Vector2 _charSize;

        public BitmapFont(string filename, Vector2 charSize)
        {
            _texture = new Texture(filename);
            _charSize = charSize;
        }

        private static Vector2 GetTexCoord(char c)
        {
            var col = c % 16;
            var row = 15 - c / 16;
            return new Vector2(col * OneOverSixteen, row * OneOverSixteen);
        }

        public List<Vertex2D> BuildTextVertices(string text, Vector2 position)
        {
            var vertices = new List<Vertex2D>(text.Length * 6);
            foreach (var texCoord in text.Select(GetTexCoord))
            {
                VertexUtils.AddRect(vertices, position, position + _charSize, texCoord, texCoord + OneOverSixteen);
                position.X += _charSize.X;
            }

            return vertices;
        }

        public void DrawText(List<Vertex2D> vertices)
        {
            _texture.Bind(0);
            Renderer2D.DrawTriangles(vertices.ToArray());
        }

        public void DrawText(string text, Vector2 position)
        {
            DrawText(BuildTextVertices(text, position));
        }
    }
}