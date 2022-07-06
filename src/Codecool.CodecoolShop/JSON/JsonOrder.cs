using System.Collections.Generic;
using Codecool.CodecoolShop.Models;
using Domain;

namespace Codecool.CodecoolShop.JSON;

public class JsonOrder
{
    public Dictionary<string, int> Products { get; set; } = new();

    public Address Address { get; set; }

    public PaymentInfo PaymentInfo { get; set; }
}