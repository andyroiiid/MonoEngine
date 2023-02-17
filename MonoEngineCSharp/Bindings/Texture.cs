using System;
using System.IO;
using System.Runtime.InteropServices;
using MonoEngine.Core;

namespace MonoEngine.Bindings
{
    public class Texture
    {
        private const string Prefix = "Texture_";

        [DllImport("__Internal", EntryPoint = Prefix + "Destroy")]
        private static extern void Destroy(IntPtr texture);

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
        private static extern Handle Create(int width, int height, byte[] data);

        [DllImport("__Internal", EntryPoint = Prefix + "LoadFromMemory")]
        private static extern Handle LoadFromMemory(byte[] bytes, int length);

        [DllImport("__Internal", EntryPoint = Prefix + "GetSize")]
        private static extern void GetSize(Handle texture, out Vector2 size);

        [DllImport("__Internal", EntryPoint = Prefix + "Bind")]
        private static extern void Bind(Handle texture, uint unit);

        private readonly Handle _handle;

        public Texture(int width, int height, byte[] pixelData) => _handle = Create(width, height, pixelData);

        public Texture(byte[] fileData) => _handle = LoadFromMemory(fileData, fileData.Length);

        public static Texture FromFile(string filename) => new Texture(File.ReadAllBytes(filename));

        public Vector2 Size
        {
            get
            {
                GetSize(_handle, out var size);
                return size;
            }
        }

        public void Bind(uint unit) => Bind(_handle, unit);

        public readonly static Texture White = new Texture(
            2,
            2,
            new byte[]
            {
                0xFF, 0xFF, 0xFF, 0xFF,
                0xFF, 0xFF, 0xFF, 0xFF,
                0xFF, 0xFF, 0xFF, 0xFF,
                0xFF, 0xFF, 0xFF, 0xFF
            }
        );
    }
}