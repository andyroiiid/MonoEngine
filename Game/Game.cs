using System;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public static class Game
{
    private static void Init()
    {
        Console.WriteLine("Init");
        Test.Interop();
        Console.WriteLine($"Test.GetValue() = {Test.GetValue()}");
        Console.WriteLine($"Test.Add(1.5f, 2.1f) = {Test.Add(1.5f, 2.1f)}");
    }

    private static void Update()
    {
        Test.Clear(0.4f, 0.8f, 1.0f, 1.0f);
    }

    private static void Shutdown()
    {
        Console.WriteLine("Shutdown");
    }
}