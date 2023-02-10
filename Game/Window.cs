using System.Runtime.InteropServices;

public static class Window
{
    private const string Prefix = "Window_";

    [DllImport("__Internal", EntryPoint = Prefix + "GetMousePos")]
    public static extern void GetMousePos(out Vector2 mousePos);
}