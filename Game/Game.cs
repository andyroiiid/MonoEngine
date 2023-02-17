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
    private VertexBuffer2D _dynamicVertices;
    private TextureGridAtlas _kenneyTinyTown;
    private TextureGridAtlas _kenneyTinyDungeon;

    private Vector2 _screenSize;

    private void Init()
    {
        Debug.Info("Init");

        Window.Cursor = false;
        Renderer2D.SetClearColor(Color.Black);

        _font = new BitmapFont(new Texture(Assets.FontSharedTechMono));
        _dynamicVertices = new VertexBuffer2D();
        _kenneyTinyTown = new TextureGridAtlas(new Texture(Assets.KenneyTinyTown), 12, 11);
        _kenneyTinyDungeon = new TextureGridAtlas(new Texture(Assets.KenneyTinyDungeon), 12, 11);
    }

    private void Shutdown()
    {
        Debug.Info("Shutdown");
    }

    private void DrawRect(in Rect rect, in Rect uvRect)
    {
        var vertices = new Vertex2D[4];
        VertexUtils.BuildRectTriangleStrip(vertices, rect, uvRect, Color.White);
        _dynamicVertices.UpdateData(vertices);
        _dynamicVertices.BindAndDraw(Primitive.TriangleStrip);
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
            var mousePos = Window.MousePos;
            mousePos.Y = _screenSize.Y - mousePos.Y;

            _kenneyTinyTown.Texture.Bind(0);
            DrawRect(
                new Rect(mousePos - _kenneyTinyTown.GridPixelSize * 4.0f, _kenneyTinyTown.GridPixelSize * 4.0f),
                _kenneyTinyTown.GetGridUvRect(2)
            );

            _kenneyTinyDungeon.Texture.Bind(0);
            DrawRect(
                new Rect(mousePos, _kenneyTinyDungeon.GridPixelSize * 4.0f),
                _kenneyTinyDungeon.GetGridUvRect(12)
            );
        }
    }

    private void Resize(int width, int height)
    {
        _screenSize.X = width;
        _screenSize.Y = height;
        Debug.Info($"Resize {_screenSize}");
    }
}