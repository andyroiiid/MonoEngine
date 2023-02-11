using System.Diagnostics.CodeAnalysis;
using MonoEngine;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class Game
{
    private Vector2 _screenSize;
    private BitmapFont _font;
    private Texture _testTexture;

    private void Init()
    {
        Debug.Log("Init");
        Debug.Info("This is an info message.");
        Debug.Warn("This is a warn message.");
        Debug.Error("This is an error message.");
        Window.Cursor = false;
        Renderer2D.SetClearColor(0.2f, 0.2f, 0.2f, 1.0f);

        _font = new BitmapFont("font.png", new Vector2(23, 48));
        _testTexture = new Texture("test.png");

        Debug.Log($"test texture size = {_testTexture.Size}");
    }

    private void Shutdown()
    {
        Debug.Log("Shutdown");
    }

    private void Frame()
    {
        if (Window.GetKey(Keys.Escape))
        {
            Window.Close();
        }

        Renderer2D.Clear();
        _font.DrawText("Hello, world!", new Vector2(32.0f, 32.0f));
        {
            _testTexture.Bind(0);
            var mousePos = Window.MousePos;
            mousePos.Y = _screenSize.Y - mousePos.Y;
            var min = mousePos - _testTexture.Size * 0.5f;
            var max = min + _testTexture.Size;
            Renderer2D.DrawRect(min, max);
        }
    }

    private void Resize(int width, int height)
    {
        _screenSize.X = width;
        _screenSize.Y = height;
        Debug.Log($"Resize {_screenSize}");
    }
}