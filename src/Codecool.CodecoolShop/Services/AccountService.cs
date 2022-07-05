using Codecool.CodecoolShop.Models;
using Data;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Codecool.CodecoolShop.Services;

public interface IAccountService
{
    void SignUpUser(SignUp dto);
}

//public class AccountService : IAccountService
//{
//    private readonly CodecoolShopContext _context;
//    private readonly IPasswordHasher<User> _passwordHasher;

//    public AccountService(CodecoolShopContext context, IPasswordHasher<User> passwordHasher)
//    {
//        _context = context;
//        _passwordHasher = passwordHasher;
//    }

//    public void SignUpUser(SignUp dto)
//    {
//        var newUser = new User
//        {
//            Username = dto.FullName,
//            Email = dto.Email,
//            Password = dto.Password
//        };

//        var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
//        newUser.Password = hashedPassword;
//        _context.Users.Add(newUser);
//        _context.SaveChanges();
//    }
//}