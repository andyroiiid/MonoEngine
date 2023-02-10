using System.Diagnostics.CodeAnalysis;
using MonoEngine;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class Game
{
    private Vector2 _screenSize;
    private Texture _fontTexture;
    private Texture _testTexture;

    private void Init()
    {
        Debug.Log("Init");
        Debug.Info("This is an info message.");
        Debug.Warn("This is a warn message.");
        Debug.Error("This is an error message.");
        Window.HideCursor();
        Renderer2D.SetClearColor(0.4f, 0.8f, 1.0f, 1.0f);

        _fontTexture = new Texture("font.png");
        _testTexture = new Texture("test.png");

        Debug.Log($"font texture size = {_fontTexture.Size}");
        Debug.Log($"test texture size = {_testTexture.Size}");
    }

    private void Shutdown()
    {
        Debug.Log("Shutdown");
    }

    private void Frame()
    {
        Renderer2D.Clear();
        {
            _fontTexture.Bind(0);
            var min = _screenSize * 0.5f;
            var max = min + _fontTexture.Size;
            Renderer2D.FillRect(min, max);
        }
        {
            _testTexture.Bind(0);
            Window.GetMousePos(out var mousePos);
            mousePos.Y = _screenSize.Y - mousePos.Y;
            var min = mousePos - _testTexture.Size * 0.5f;
            var max = mousePos + _testTexture.Size * 0.5f;
            Renderer2D.FillRect(min, max);
        }
    }

    private void Resize(int width, int height)
    {
        _screenSize.X = width;
        _screenSize.Y = height;
        Debug.Log($"Resize {_screenSize}");
    }
}