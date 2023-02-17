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
        private static readonly int UPosition = Shader.GetUniformLocation("uPosition");

        public static void Use() => Shader.Use();

        public static void SetScreenSize(Vector2 screenSize) => Shader.SetUniform(UScreenSize, screenSize);

        public static void SetPosition(Vector2 position) => Shader.SetUniform(UPosition, position);
    }
}