using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    [NotMapped]
    public string ConfirmPassword { get; set; }
    public string Email { get; set; }
}