using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public static class Game
{
    private static void Init()
    {
        Debug.Log("Init");
        Debug.Info("This is an info message.");
        Debug.Warn("This is a warn message.");
        Debug.Error("This is an error message.");
        Renderer2D.SetClearColor(0.4f, 0.8f, 1.0f, 1.0f);
    }

    private static void Shutdown()
    {
        Debug.Log("Shutdown");
    }

    private static void Frame()
    {
        Renderer2D.Clear();
        Renderer2D.DrawLine(0.1f, 0.2f, 0.3f, 0.4f);
        Renderer2D.FillRect(-0.5f, -0.5f, 0.0f, 0.0f);
    }

    private static void Resize(int width, int height)
    {
        Debug.Log($"Resize {width}x{height}");
    }
}