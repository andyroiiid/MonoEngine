using System;
using MonoEngine.Core;
using MonoEngine.GL;
using MonoEngine.Shaders;

namespace MonoEngine
{
    public static class DynamicRenderer
    {
        private static readonly Lazy<BaseShader> Shader = new Lazy<BaseShader>();
        private static readonly Lazy<VertexBuffer2D> Vertices = new Lazy<VertexBuffer2D>();

        public static void UseShader() => Shader.Value.Use();

        public static void Resize(int width, int height) => Shader.Value.SetScreenSize(width, height);

        public static void DrawVertices(Vertex2D[] vertices, Primitive primitive, in Vector2 position)
        {
            Shader.Value.SetPosition(position);
            Vertices.Value.UpdateData(vertices);
            Vertices.Value.BindAndDraw(primitive);
        }

        public static void DrawRect(in Vector2 size, in Rect uvRect, in Vector2 position)
        {
            var vertices = new Vertex2D[4];
            VertexUtils.BuildRectTriangleStrip(vertices, new Rect(Vector2.Zero, size), uvRect, Color.White);
            DrawVertices(vertices, Primitive.TriangleStrip, position);
        }
    }
}