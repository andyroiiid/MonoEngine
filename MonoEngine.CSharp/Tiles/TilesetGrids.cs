using MonoEngine.Core;

namespace MonoEngine.Tiles
{
    public class TilesetGrids
    {
        private readonly Rect[] _grids;

        // Top-left index: 0
        // Top-right index: cols - 1
        // Bottom-right index: cols * rows - 1
        public TilesetGrids(int cols, int rows)
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
}