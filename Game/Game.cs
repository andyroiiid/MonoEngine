using System.Diagnostics.CodeAnalysis;
using MonoEngine;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class Game
{
    private Vector2 _size;
    private Texture _testTexture;

    private void Init()
    {
        Debug.Log("Init");
        Debug.Info("This is an info message.");
        Debug.Warn("This is a warn message.");
        Debug.Error("This is an error message.");
        Window.HideCursor();
        Renderer2D.SetClearColor(0.4f, 0.8f, 1.0f, 1.0f);

        _testTexture = new Texture(2, 2, new byte[]
        {
            0xFF, 0x00, 0x00, 0xFF,
            0x00, 0xFF, 0x00, 0xFF,
            0x00, 0x00, 0xFF, 0xFF,
            0xFF, 0xFF, 0xFF, 0xFF,
        });

        Debug.Log($"test texture size = {_testTexture.GetSize()}");
    }

    private void Shutdown()
    {
        Debug.Log("Shutdown");
    }

    private void Frame()
    {
        Renderer2D.Clear();
        {
            _testTexture.Bind(0);
            var center = _size * 0.5f;
            var min = center - 8.0f;
            var max = center + 8.0f;
            Renderer2D.FillRect(min, max);
        }
        {
            Texture.White.Bind(0);
            Window.GetMousePos(out var mousePos);
            mousePos.Y = _size.Y - mousePos.Y;
            var min = mousePos - 8.0f;
            var max = mousePos + 8.0f;
            Renderer2D.FillRect(min, max);
        }
    }

    private void Resize(int width, int height)
    {
        _size.X = width;
        _size.Y = height;
        Debug.Log($"Resize {_size}");
    }
}