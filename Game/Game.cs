using System.Diagnostics.CodeAnalysis;
using MonoEngine;
using MonoEngine.Bindings;
using MonoEngine.Core;
using MonoEngine.GL;
using MonoEngine.Tiles;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class Game
{
    private BitmapFont _font;
    private Tileset _kenneyTinyDungeon;
    private Tileset _kenneyTinyTown;

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
        _kenneyTinyDungeon = new Tileset(Texture.FromFile("Assets/Textures/Kenney/TinyDungeon.png"), 12, 11);
        _kenneyTinyTown = new Tileset(Texture.FromFile("Assets/Textures/Kenney/TinyTown.png"), 12, 11);
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
                _kenneyTinyDungeon.TilePixelSize * 4.0f,
                _kenneyTinyDungeon.GetTileUvRect(12),
                mousePos
            );

            _kenneyTinyTown.Texture.Bind(0);
            DynamicRenderer.DrawRect(
                _kenneyTinyTown.TilePixelSize * 4.0f,
                _kenneyTinyTown.GetTileUvRect(2),
                mousePos - _kenneyTinyTown.TilePixelSize * 4.0f
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