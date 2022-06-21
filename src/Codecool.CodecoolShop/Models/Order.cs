namespace Codecool.CodecoolShop.Models;

public class Order
{
    public IEnumerable<Item> ItemCollection = new List<Item>();

    public int Id { get; set; }

    public PaymentInfo PaymentInfo { get; set; }

    public decimal Total { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public string Zip { get; set; }

    public string FullNameShipping { get; set; }

    public string EmailShipping { get; set; }

    public string AddressShipping { get; set; }

    public string CountryShipping { get; set; }

    public string CityShipping { get; set; }

    public string ZipShipping { get; set; }
}