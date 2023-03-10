using System.Runtime.InteropServices;

namespace MonoEngine.Bindings
{
    public static class Debug
    {
        private const string Prefix = "Debug_";

        [DllImport("__Internal", EntryPoint = Prefix + "Info")]
        public static extern void Info(string message);

        [DllImport("__Internal", EntryPoint = Prefix + "Warn")]
        public static extern void Warn(string message);

        [DllImport("__Internal", EntryPoint = Prefix + "Error")]
        public static extern void Error(string message);
    }
}