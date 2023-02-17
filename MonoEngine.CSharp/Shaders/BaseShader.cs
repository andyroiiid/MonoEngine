using MonoEngine.GL;

namespace MonoEngine.Shaders
{
    public class BaseShader : Shader
    {
        private readonly int _screenSizeLocation;

        public BaseShader() : base(ShaderSources.ShaderBaseVertex, ShaderSources.ShaderBaseFragment)
        {
            _screenSizeLocation = GetUniformLocation("uScreenSize");
        }

        public void SetScreenSize(int width, int height)
        {
            SetUniform(_screenSizeLocation, width, height);
        }
    }
}