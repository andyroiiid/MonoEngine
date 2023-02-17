using System.Diagnostics.CodeAnalysis;
using MonoEngine;
using MonoEngine.Bindings;
using MonoEngine.Core;
using MonoEngine.GL;
using MonoEngine.Shaders;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class Game
{
    private BaseShader _shader;
    private BitmapFont _font;
    private TextureGridAtlas _kenneyTinyTown;
    private TextureGridAtlas _kenneyTinyDungeon;

    private Vector2 _screenSize;

    private void Init()
    {
        Debug.Info("Init");

        Window.Cursor = false;
        ImmediateContext.SetClearColor(Color.Black);
        ImmediateContext.EnableBlend();

        _shader = new BaseShader();
        _font = new BitmapFont(new Texture(Assets.FontSharedTechMono));
        _kenneyTinyTown = new TextureGridAtlas(new Texture(Assets.KenneyTinyTown), 12, 11);
        _kenneyTinyDungeon = new TextureGridAtlas(new Texture(Assets.KenneyTinyDungeon), 12, 11);
    }

    private void Shutdown()
    {
        Debug.Info("Shutdown");
    }

    private void Frame()
    {
        if (Window.GetKey(Keys.Escape))
        {
            Window.Close();
        }

        ImmediateContext.Clear();

        _shader.Use();

        _font.DrawText("Hello, world!", new Vector2(32.0f, 32.0f), Color.White);

        {
            var mousePos = Window.MousePos;
            mousePos.Y = _screenSize.Y - mousePos.Y;

            _kenneyTinyTown.Texture.Bind(0);
            DynamicRenderer.DrawRect(
                new Rect(mousePos - _kenneyTinyTown.GridPixelSize * 4.0f, _kenneyTinyTown.GridPixelSize * 4.0f),
                _kenneyTinyTown.GetGridUvRect(2)
            );

            _kenneyTinyDungeon.Texture.Bind(0);
            DynamicRenderer.DrawRect(
                new Rect(mousePos, _kenneyTinyDungeon.GridPixelSize * 4.0f),
                _kenneyTinyDungeon.GetGridUvRect(12)
            );
        }
    }

    private void Resize(int width, int height)
    {
        _screenSize.X = width;
        _screenSize.Y = height;
        _shader.SetScreenSize(width, height);
        Debug.Info($"Resize {_screenSize}");
    }
}