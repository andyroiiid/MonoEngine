using MonoEngine.Core;
using MonoEngine.GL;

namespace MonoEngine.Shaders
{
    public class BaseShader : Shader
    {
        private readonly int _uScreenSize;
        private readonly int _uPosition;

        public BaseShader() : base(ShaderSources.ShaderBaseVertex, ShaderSources.ShaderBaseFragment)
        {
            _uScreenSize = GetUniformLocation("uScreenSize");
            _uPosition = GetUniformLocation("uPosition");
        }

        public void SetScreenSize(int width, int height) => SetUniform(_uScreenSize, width, height);

        public void SetPosition(Vector2 position) => SetUniform(_uPosition, position);
    }
}