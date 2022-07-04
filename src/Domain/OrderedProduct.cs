namespace Domain;

public class OrderedProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Currency { get; set; }
    public double Price { get; set; }
    public Order Order { get; set; }
}