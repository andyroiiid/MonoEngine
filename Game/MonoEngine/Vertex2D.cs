namespace MonoEngine
{
    public struct Vertex2D
    {
        public Vector2 Position;
        public Vector2 TexCoord;
        public Color Color;

        public Vertex2D(Vector2 position, Vector2 texCoord, Color color)
        {
            Position = position;
            TexCoord = texCoord;
            Color = color;
        }

        public Vertex2D(Vector2 position, Vector2 texCoord) : this(position, texCoord, Color.White)
        {
        }
    }
}