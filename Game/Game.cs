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
        Renderer2D.SetClearColor(Color.Black);

        _font = new BitmapFont(new Texture(Assets.FontSharedTechMono));
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
        _font.DrawText("Hello, world!", new Vector2(32.0f, 32.0f), Color.White);
        {
            _testTexture.Bind(0);
            var mousePos = Window.MousePos;
            mousePos.Y = _screenSize.Y - mousePos.Y;
            Renderer2D.DrawRect(new Rect(mousePos - _testTexture.Size * 0.5f, _testTexture.Size), 0.5f);
        }
    }

    private void Resize(int width, int height)
    {
        _screenSize.X = width;
        _screenSize.Y = height;
        Debug.Log($"Resize {_screenSize}");
    }
}