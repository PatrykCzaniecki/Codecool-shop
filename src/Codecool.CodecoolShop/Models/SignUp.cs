using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models;

public class SignUp
{
    [Required] public string FullName { get; set; }

    [Required]
    [RegularExpression(
        "\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z")]
    public string Email { get; set; }

    [Required] public string Password { get; set; }
}