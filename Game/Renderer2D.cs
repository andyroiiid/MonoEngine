using System.Runtime.InteropServices;

public static class Renderer2D
{
    private const string Prefix = "Renderer2D_";

    [DllImport("__Internal", EntryPoint = Prefix + "SetClearColor")]
    public static extern void SetClearColor(float r, float g, float b, float a);

    [DllImport("__Internal", EntryPoint = Prefix + "Clear")]
    public static extern void Clear();

    [DllImport("__Internal", EntryPoint = Prefix + "DrawLine")]
    public static extern void DrawLine(float x0, float y0, float x1, float y1);

    [DllImport("__Internal", EntryPoint = Prefix + "FillRect")]
    public static extern void FillRect(float x0, float y0, float x1, float y1);
}