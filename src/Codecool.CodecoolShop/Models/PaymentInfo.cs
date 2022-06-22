using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models;

public class PaymentInfo
{
    [Required]
    public string NameOnCard { get; set; }
    [Required]
    public string CardNumber { get; set; }
    [Required]
    public string ExpMonth { get; set; }
    [Required]
    public string ExpYear { get; set; }
    [Required]
    public string CVV { get; set; }
}