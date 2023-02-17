namespace MonoEngine.Core
{
    public struct Rect
    {
        public Vector2 Position;
        public Vector2 Size;

        public Vector2 P00 => Position;
        public Vector2 P01 => new Vector2(Position.X, Position.Y + Size.Y);
        public Vector2 P10 => new Vector2(Position.X + Size.X, Position.Y);
        public Vector2 P11 => Position + Size;

        public Rect(in Vector2 position, in Vector2 size)
        {
            Position = position;
            Size = size;
        }

        public override string ToString() => $"Rect({Position}, {Size})";

        public static readonly Rect ZeroToOne = new Rect(Vector2.Zero, Vector2.One);
    }
}