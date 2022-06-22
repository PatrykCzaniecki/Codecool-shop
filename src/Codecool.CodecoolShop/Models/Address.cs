using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models;

public class Address
{
    [DisplayName("Full name")] [Required] public string FullName { get; set; }

    [Required] public string Phone { get; set; }

    [Required] public string Email { get; set; }

    [Required] public string Street { get; set; }

    [Required] public string Country { get; set; }

    [Required] public string City { get; set; }

    [Required] public string Zip { get; set; }
}