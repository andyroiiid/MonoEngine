using System.Diagnostics.CodeAnalysis;
using MonoEngine;
using MonoEngine.Bindings;
using MonoEngine.Core;
using MonoEngine.GL;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class Game
{
    private BitmapFont _font;
    private TextureGridAtlas _kenneyTinyDungeon;
    private TextureGridAtlas _kenneyTinyTown;

    private Vector2 _screenSize;

    private void Init()
    {
        Debug.Info("Init");

        var gameConfig = JsonUtils.LoadFromFile<GameConfig>("Assets/GameConfig.json");

        Window.Title = gameConfig.Title;
        Window.SetSize(gameConfig.Width, gameConfig.Height);
        Window.Cursor = false;

        ImmediateContext.SetClearColor(Color.Black);
        ImmediateContext.EnableBlend();

        _font = new BitmapFont(Texture.FromFile("Assets/Fonts/SharedTechMono.png"));
        _kenneyTinyDungeon = new TextureGridAtlas(Texture.FromFile("Assets/Textures/Kenney/TinyDungeon.png"), 12, 11);
        _kenneyTinyTown = new TextureGridAtlas(Texture.FromFile("Assets/Textures/Kenney/TinyTown.png"), 12, 11);
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

        DynamicRenderer.UseShader();

        _font.DrawText("Hello, world!", new Vector2(32.0f, 32.0f), Color.White);

        {
            var mousePos = Window.MousePos;
            mousePos.Y = _screenSize.Y - mousePos.Y;

            _kenneyTinyDungeon.Texture.Bind(0);
            DynamicRenderer.DrawRect(
                _kenneyTinyDungeon.GridPixelSize * 4.0f,
                _kenneyTinyDungeon.GetGridUvRect(12),
                mousePos
            );

            _kenneyTinyTown.Texture.Bind(0);
            DynamicRenderer.DrawRect(
                _kenneyTinyTown.GridPixelSize * 4.0f,
                _kenneyTinyTown.GetGridUvRect(2),
                mousePos - _kenneyTinyTown.GridPixelSize * 4.0f
            );
        }
    }

    private void Resize(int width, int height)
    {
        _screenSize.X = width;
        _screenSize.Y = height;
        DynamicRenderer.Resize(width, height);
        Debug.Info($"Resize {_screenSize}");
    }
}