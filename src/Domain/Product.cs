namespace Domain;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Currency { get; set; }
    public string Description { get; set; }
    public double DefaultPrice { get; set; }
    public Category Category { get; set; }
    public Supplier Supplier { get; set; }
}