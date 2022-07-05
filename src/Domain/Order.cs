

namespace Domain;

public class Order
{
    public int Id { get; set; }
    public Address Address { get; set; }
    public string User_id { get; set; }
    public PaymentInfo PaymentInfo { get; set; }
    public string OrderPayed { get; set; }
}