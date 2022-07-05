using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models;

public class LoginInfo
{
    [DisplayName("UserName")] [Required] public string UserName { get; set; }

    [DisplayName("Password")] [Required] public string Password { get; set; }
}