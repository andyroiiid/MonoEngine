using System.Runtime.InteropServices;

public static class Debug
{
    private const string Prefix = "Debug_";

    [DllImport("__Internal", EntryPoint = Prefix + "Info")]
    public static extern void Info(string message);

    public static void Log(string message) => Info(message);

    [DllImport("__Internal", EntryPoint = Prefix + "Warn")]
    public static extern void Warn(string message);

    [DllImport("__Internal", EntryPoint = Prefix + "Error")]
    public static extern void Error(string message);
}