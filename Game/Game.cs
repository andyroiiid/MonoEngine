using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public static class Game
{
    private static void Init()
    {
        Test.Log("Init");
        Test.Interop();
        Test.Log($"Test.GetValue() = {Test.GetValue()}");
        Test.Log($"Test.Add(1.5f, 2.1f) = {Test.Add(1.5f, 2.1f)}");
    }

    private static void Shutdown()
    {
        Test.Log("Shutdown");
    }

    private static void Frame()
    {
        Test.Clear(0.4f, 0.8f, 1.0f, 1.0f);
    }

    private static void Resize(int width, int height)
    {
        Test.Log($"Resize {width}x{height}");
    }
}