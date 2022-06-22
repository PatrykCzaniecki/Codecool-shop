using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.JSON
{
    public class JsonOrder
    {
        public Dictionary<string, int> Products { get; set; } = new Dictionary<string, int>();

        public Address Address { get; set; }

        public PaymentInfo PaymentInfo { get; set; }
    } 
}
