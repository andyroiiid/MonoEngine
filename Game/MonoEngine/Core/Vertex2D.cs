namespace MonoEngine.Core
{
    public struct Vertex2D
    {
        public Vector2 Position;
        public Vector2 TexCoord;
        public Color Color;

        public Vertex2D(in Vector2 position, in Vector2 texCoord, in Color color)
        {
            Position = position;
            TexCoord = texCoord;
            Color = color;
        }
    }
}