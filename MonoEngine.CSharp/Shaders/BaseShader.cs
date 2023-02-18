using MonoEngine.Core;
using MonoEngine.GL;

namespace MonoEngine.Shaders
{
    public static class BaseShader
    {
        private static readonly Shader Shader = new Shader(
            ShaderSources.ShaderBaseVertex,
            ShaderSources.ShaderBaseFragment
        );

        private static readonly int UScreenSize = Shader.GetUniformLocation("uScreenSize");
        private static readonly int UTransform = Shader.GetUniformLocation("uTransform");

        public static void Use() => Shader.Use();

        public static void SetScreenSize(in Vector2 screenSize) => Shader.SetUniform(UScreenSize, screenSize);

        public static void SetTransform(in Transform transform) => Shader.SetUniform(
            UTransform,
            transform.Position.X,
            transform.Position.Y,
            transform.Rotation,
            transform.Scale.X,
            transform.Scale.Y
        );
    }
}