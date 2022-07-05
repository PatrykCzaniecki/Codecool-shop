using System.ComponentModel.DataAnnotations;

namespace Domain;

public class PaymentInfo
{
    [Key]
    public int Id { get; set; }
    public string NameOnCard { get; set; }
    public string CardNumber { get; set; }
    public string ExpMonth { get; set; }
    public string ExpYear { get; set; }
    public string CVV { get; set; }
}