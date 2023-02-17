using MonoEngine.Core;

namespace MonoEngine.Tiles
{
    public struct TileDrawCall
    {
        public readonly int Index;
        public readonly Vector2 Offset;
        public readonly Color Color;

        public TileDrawCall(int index, in Vector2 offset, in Color color)
        {
            Index = index;
            Offset = offset;
            Color = color;
        }
    }
}