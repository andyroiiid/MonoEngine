namespace MonoEngine.Core
{
    public struct Color
    {
        public float R;
        public float G;
        public float B;
        public float A;

        public Color(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public override string ToString() => $"Color({R}, {G}, {B}, {A})";

        public static readonly Color Black = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        public static readonly Color Red = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        public static readonly Color Green = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        public static readonly Color Blue = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        public static readonly Color Yellow = new Color(1.0f, 1.0f, 0.0f, 1.0f);
        public static readonly Color Magenta = new Color(1.0f, 0.0f, 1.0f, 1.0f);
        public static readonly Color Cyan = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        public static readonly Color White = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        public static Color TransparentWhite(float transparency) => new Color(1.0f, 1.0f, 1.0f, transparency);
    }
}