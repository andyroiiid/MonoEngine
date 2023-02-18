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

        public override string ToString() => $"Transform({Position}, {Rotation}, {Scale})";

        public static readonly Transform Identity = new Transform(Vector2.Zero, 0.0f, Vector2.One);
    }
}