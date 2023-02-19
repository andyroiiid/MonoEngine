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
    private Vector2 _screenSize;
    private Sprite _cursor;

    private void Init()
    {
        Debug.Info("Init");

        Window.Title = "Test Game";
        Window.SetSize(1280, 720);
        Window.Cursor = false;

        ImmediateContext.ClearColor = Color.Black;

        _cursor = new Sprite("Assets/Textures/Cursor.png", Vector2.Half);

        World.DebugPrint();
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

        _cursor.Draw(new Transform(Window.MousePos, 0.0f, 2.0f));
    }

    private void Resize(int width, int height)
    {
        _screenSize = new Vector2(width, height);
        BaseShader.SetScreenSize(_screenSize);
        Debug.Info($"Resize {_screenSize}");
    }
}