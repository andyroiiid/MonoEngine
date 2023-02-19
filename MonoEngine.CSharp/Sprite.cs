using MonoEngine.Core;
using MonoEngine.GL;
using MonoEngine.Shaders;

namespace MonoEngine
{
    public class Sprite
    {
        private readonly Texture _texture;
        private readonly VertexBuffer2D _quad;

        public Sprite(string filename, in Vector2 pivot)
        {
            _texture = Texture.FromFile(filename);

            var vertices = new Vertex2D[6];
            VertexUtils.BuildRectTriangles(
                vertices,
                0,
                new Rect(-_texture.Size * pivot, _texture.Size),
                Rect.ZeroToOne,
                Color.White
            );
            _quad = new VertexBuffer2D(vertices);
        }

        public void Draw(in Transform transform)
        {
            BaseShader.Use();
            BaseShader.SetTransform(transform);
            _texture.Bind(0);
            _quad.BindAndDraw(Primitive.Triangles);
        }
    }
}