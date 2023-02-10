using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class Game
{
    private Vector2 _size;

    private void Init()
    {
        Debug.Log("Init");
        Debug.Info("This is an info message.");
        Debug.Warn("This is a warn message.");
        Debug.Error("This is an error message.");
        Renderer2D.SetClearColor(0.4f, 0.8f, 1.0f, 1.0f);
    }

    private void Shutdown()
    {
        Debug.Log("Shutdown");
    }

    private void Frame()
    {
        Renderer2D.Clear();
        Window.GetMousePos(out var mousePos);
        mousePos.Y = _size.Y - mousePos.Y;
        var min = mousePos - Vector2.One * 4.0f;
        var max = mousePos + Vector2.One * 4.0f;
        Renderer2D.FillRect(min, max);
    }

    private void Resize(int width, int height)
    {
        _size.X = width;
        _size.Y = height;
        Debug.Log($"Resize {_size}");
    }
}