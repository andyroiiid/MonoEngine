using System;
using System.Runtime.InteropServices;

namespace MonoEngine.Bindings
{
    public class Shader
    {
        private const string Prefix = "Shader_";

        [DllImport("__Internal", EntryPoint = Prefix + "Destroy")]
        private static extern void Destroy(IntPtr shader);

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
        private static extern Handle Create(string vertexSource, string fragmentSource);

        [DllImport("__Internal", EntryPoint = Prefix + "Use")]
        private static extern void Use(Handle shader);

        [DllImport("__Internal", EntryPoint = Prefix + "GetUniformLocation")]
        private static extern int GetUniformLocation(Handle shader, string name);

        [DllImport("__Internal", EntryPoint = Prefix + "SetUniform1F")]
        private static extern void SetUniform1F(Handle shader, int location, float x);

        [DllImport("__Internal", EntryPoint = Prefix + "SetUniform2F")]
        private static extern void SetUniform2F(Handle shader, int location, float x, float y);

        [DllImport("__Internal", EntryPoint = Prefix + "SetUniform3F")]
        private static extern void SetUniform3F(Handle shader, int location, float x, float y, float z);

        [DllImport("__Internal", EntryPoint = Prefix + "SetUniform4F")]
        private static extern void SetUniform4F(Handle shader, int location, float x, float y, float z, float w);

        private readonly Handle _handle;

        protected Shader(string vertexSource, string fragmentSource) => _handle = Create(vertexSource, fragmentSource);

        public void Use() => Use(_handle);

        protected int GetUniformLocation(string name) => GetUniformLocation(_handle, name);

        protected void SetUniform(int location, float x)
        {
            SetUniform1F(_handle, location, x);
        }

        protected void SetUniform(int location, float x, float y)
        {
            SetUniform2F(_handle, location, x, y);
        }

        protected void SetUniform(int location, float x, float y, float z)
        {
            SetUniform3F(_handle, location, x, y, z);
        }

        protected void SetUniform(int location, float x, float y, float z, float w)
        {
            SetUniform4F(_handle, location, x, y, z, w);
        }
    }
}