using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class GameConfig
{
    public string Title { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}