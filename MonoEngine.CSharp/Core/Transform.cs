namespace MonoEngine.Core
{
    public struct Transform
    {
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;

        public Transform(in Vector2 position, float rotation, in Vector2 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }

        public Transform(in Vector2 position, float rotation, float scale) : this(
            position,
            rotation,
            Vector2.One * scale
        )
        {
        }

        public Transform(in Vector2 position, float rotation) : this(position, rotation, 1.0f)
        {
        }

        public Transform(in Vector2 position) : this(position, 0.0f)
        {
        }

        public override string ToString() => $"Transform({Position}, {Rotation}, {Scale})";

        public static readonly Transform Identity = new Transform(Vector2.Zero, 0.0f, Vector2.One);
    }
}