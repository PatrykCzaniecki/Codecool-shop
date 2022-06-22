using System.IO;
using System.Text.Json;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.JSON;

public static class JsonFile
{
    public static void SaveToJsonFile(Order value, int orderNumber)
    {
        var jsonOrder = new JsonOrder();
        foreach (var product in value.Cart.Products)
        {
            jsonOrder.Products.Add(product.Key.Name,product.Value);
        }
        jsonOrder.Address = value.Address;
        jsonOrder.PaymentInfo = value.PaymentInfo;

        var options = new JsonSerializerOptions {WriteIndented = true};
        var jsonString = JsonSerializer.Serialize(jsonOrder, options);
        File.WriteAllText($"../JsonFileOrder{orderNumber}.json", jsonString);
    }
}