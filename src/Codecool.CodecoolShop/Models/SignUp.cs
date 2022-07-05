using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models;

public class SignUp
{
    public string FullName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }
}