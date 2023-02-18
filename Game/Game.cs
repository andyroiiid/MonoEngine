using System.Diagnostics.CodeAnalysis;
using MonoEngine;
using MonoEngine.Bindings;
using MonoEngine.Core;
using MonoEngine.GL;
using MonoEngine.Shaders;
using MonoEngine.Tiles;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class Game
{
    private BitmapFont _font;
    private Tileset _kenneyTinyDungeon;
    private Tileset _kenneyTinyTown;

    private Vector2 _screenSize;
    private Vector2 _mousePos;

    private void Init()
    {
        Debug.Info("Init");

        var gameConfig = JsonUtils.LoadFromFile<GameConfig>("Assets/GameConfig.json");

        Window.Title = gameConfig.Title;
        Window.SetSize(gameConfig.Width, gameConfig.Height);
        Window.Cursor = false;

        ImmediateContext.ClearColor = Color.Black;

        _font = new BitmapFont("Assets/Fonts/SharedTechMono.png");
        _kenneyTinyDungeon = new Tileset("Assets/Textures/Kenney/TinyDungeon.png", 12, 11);
        _kenneyTinyTown = new Tileset("Assets/Textures/Kenney/TinyTown.png", 12, 11);
    }

    private void Shutdown()
    {
        Debug.Info("Shutdown");
    }

    private void Frame()
    {
        Update();
        Draw();
    }

    private void Resize(int width, int height)
    {
        _screenSize = new Vector2(width, height);
        BaseShader.SetScreenSize(_screenSize);
        Debug.Info($"Resize {_screenSize}");
    }

    private void Update()
    {
        if (Window.GetKey(Keys.Escape))
        {
            Window.Close();
        }

        _mousePos = Window.MousePos;
        _mousePos.Y = _screenSize.Y - _mousePos.Y;
    }

    private void Draw()
    {
        ImmediateContext.Clear();

        _font.DrawText("Hello, world!", new Transform(new Vector2(32.0f, 32.0f), 0.0f, Vector2.One), Color.White);
        _kenneyTinyDungeon.DrawTile(
            12,
            new Transform(
                _mousePos,
                Window.Time,
                Vector2.One * 4.0f
            ),
            Color.White
        );
        _kenneyTinyTown.DrawTile(
            2,
            new Transform(
                _mousePos - _kenneyTinyTown.TileSize * 4.0f,
                Window.Time,
                Vector2.One * 4.0f
            ),
            Color.White
        );
    }
}