using MonoEngine.Bindings;
using MonoEngine.Core;

namespace MonoEngine
{
    public class TextureGridAtlas
    {
        public readonly Texture Texture;
        public readonly Vector2 GridPixelSize;

        private class Grids
        {
            private readonly Rect[] _grids;

            public Grids(int cols, int rows)
            {
                _grids = new Rect[cols * rows];

                var i = 0;
                var gridSize = new Vector2(1.0f / cols, 1.0f / rows);
                for (var row = rows - 1; row >= 0; row--) // top left is the first grid
                {
                    for (var col = 0; col < cols; col++)
                    {
                        _grids[i] = new Rect(new Vector2(col * gridSize.X, row * gridSize.Y), gridSize);
                        i++;
                    }
                }
            }

            public Rect this[int index] => _grids[index];
        }

        private readonly Grids _grids;

        public Rect GetGridUvRect(int index) => _grids[index];

        public TextureGridAtlas(Texture texture, int cols, int rows)
        {
            Texture = texture;
            GridPixelSize = Texture.Size / new Vector2(cols, rows);
            _grids = new Grids(cols, rows);
        }
    }
}