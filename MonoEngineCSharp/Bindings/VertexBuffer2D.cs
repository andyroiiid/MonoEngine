using System;
using System.Runtime.InteropServices;
using MonoEngine.Core;

namespace MonoEngine.Bindings
{
    public class VertexBuffer2D
    {
        private const string Prefix = "VertexBuffer2D_";

        [DllImport("__Internal", EntryPoint = Prefix + "Destroy")]
        private static extern void Destroy(IntPtr vertexBuffer2D);

        // ReSharper disable once ClassNeverInstantiated.Local
        private class Handle : SafeHandle
        {
            public Handle() : base(IntPtr.Zero, true)
            {
            }

            protected override bool ReleaseHandle()
            {
                Destroy(handle);
                return true;
            }

            public override bool IsInvalid => handle == IntPtr.Zero;
        }

        [DllImport("__Internal", EntryPoint = Prefix + "Create")]
        private static extern Handle Create();

        [DllImport("__Internal", EntryPoint = Prefix + "CreateWithData")]
        private static extern Handle CreateWithData(Vertex2D[] vertices, int count);

        [DllImport("__Internal", EntryPoint = Prefix + "UpdateData")]
        private static extern void UpdateData(Handle vertexBuffer2D, Vertex2D[] vertices, int count);

        [DllImport("__Internal", EntryPoint = Prefix + "BindAndDraw")]
        private static extern void BindAndDraw(Handle vertexBuffer2D, int mode);

        private readonly Handle _handle;

        public VertexBuffer2D() => _handle = Create();

        public VertexBuffer2D(Vertex2D[] vertices) => _handle = CreateWithData(vertices, vertices.Length);

        public void UpdateData(Vertex2D[] vertices) => UpdateData(_handle, vertices, vertices.Length);

        public void BindAndDraw(GL.Primitive primitive) => BindAndDraw(_handle, (int)primitive);
    }
}