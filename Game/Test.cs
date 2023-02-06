using System.Runtime.InteropServices;

public static class Test
{
    [DllImport("__Internal", EntryPoint = "Test_Interop")]
    public static extern void Interop();

    [DllImport("__Internal", EntryPoint = "Test_GetValue")]
    public static extern float GetValue();

    [DllImport("__Internal", EntryPoint = "Test_Add")]
    public static extern float Add(float a, float b);

    [DllImport("__Internal", EntryPoint = "Test_Clear")]
    public static extern void Clear(float r, float g, float b, float a);

    [DllImport("__Internal", EntryPoint = "Test_Log")]
    public static extern void Log(string message);
}