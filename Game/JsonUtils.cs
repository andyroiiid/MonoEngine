using System.IO;
using Newtonsoft.Json;

public static class JsonUtils
{
    public static T LoadFromFile<T>(string filename)
    {
        return JsonConvert.DeserializeObject<T>(File.ReadAllText(filename));
    }
}