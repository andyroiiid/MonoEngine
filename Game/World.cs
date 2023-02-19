using System.IO;
using MonoEngine.Bindings;

public static class World
{
    private static readonly ldtk.LdtkJson Ldtk;

    static World()
    {
        Ldtk = ldtk.LdtkJson.FromJson(File.ReadAllText("Assets/World.ldtk"));
    }

    private static void DebugPrint(ldtk.LayerDefinition layer)
    {
        Debug.Info($"Layer {layer.Identifier} {layer.Type}");
    }

    private static void DebugPrint(ldtk.TilesetDefinition tileset)
    {
        Debug.Info($"Tileset {tileset.Identifier}");
        Debug.Info($"{tileset.CWid}, {tileset.CHei}");
    }

    private static void DebugPrint(ldtk.Level level)
    {
        Debug.Info($"Level {level.Identifier}");
        Debug.Info($"Position = {level.WorldX}, {level.WorldY}");
        Debug.Info($"Size = {level.PxWid}, {level.PxHei}");

        foreach (var field in level.FieldInstances)
        {
            Debug.Info($"{field.Identifier} = {field.Value}");
        }

        foreach (var layer in level.LayerInstances)
        {
            Debug.Info($"Layer {layer.Identifier} {layer.Type}");
        }
    }

    public static void DebugPrint()
    {
        var defs = Ldtk.Defs;
        foreach (var layer in defs.Layers)
        {
            DebugPrint(layer);
        }

        foreach (var tileset in defs.Tilesets)
        {
            DebugPrint(tileset);
        }

        foreach (var level in Ldtk.Levels)
        {
            DebugPrint(level);
        }
    }
}