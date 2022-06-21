using System.IO;
using System.Text.Json;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.JSON;

public static class JsonFile
{
    public static void SaveToJsonFile(Order value, int orderNumber)
    {
        var options = new JsonSerializerOptions {WriteIndented = true};
        var jsonString = JsonSerializer.Serialize(value, options);
        jsonString += JsonSerializer.Serialize(value.ItemCollection, options);
        File.WriteAllText($"../JsonFileOrder{orderNumber}.json", jsonString);
    }
}