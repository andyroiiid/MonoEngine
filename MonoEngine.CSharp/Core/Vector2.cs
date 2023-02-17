namespace MonoEngine.Core
{
    public struct Vector2
    {
        public float X;
        public float Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"Vector2({X}, {Y})";

        public static Vector2 operator +(in Vector2 v) => v;

        public static Vector2 operator -(in Vector2 v) => new Vector2(-v.X, -v.Y);

        public static Vector2 operator +(in Vector2 a, in Vector2 b) => new Vector2(a.X + b.X, a.Y + b.Y);

        public static Vector2 operator +(in Vector2 v, float f) => new Vector2(v.X + f, v.Y + f);

        public static Vector2 operator -(in Vector2 a, in Vector2 b) => new Vector2(a.X - b.X, a.Y - b.Y);

        public static Vector2 operator -(in Vector2 v, float f) => new Vector2(v.X - f, v.Y - f);

        public static Vector2 operator *(in Vector2 a, in Vector2 b) => new Vector2(a.X * b.X, a.Y * b.Y);

        public static Vector2 operator *(in Vector2 v, float f) => new Vector2(v.X * f, v.Y * f);

        public static Vector2 operator /(in Vector2 a, in Vector2 b) => new Vector2(a.X / b.X, a.Y / b.Y);

        public static Vector2 operator /(in Vector2 v, float f) => new Vector2(v.X / f, v.Y / f);

        public static readonly Vector2 Zero = new Vector2(0.0f, 0.0f);
        public static readonly Vector2 One = new Vector2(1.0f, 1.0f);
        public static readonly Vector2 Right = new Vector2(1.0f, 0.0f);
        public static readonly Vector2 Left = new Vector2(-1.0f, 0.0f);
        public static readonly Vector2 Up = new Vector2(0.0f, 1.0f);
        public static readonly Vector2 Down = new Vector2(0.0f, -1.0f);
    }
}