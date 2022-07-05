﻿using Codecool.CodecoolShop.Models;
using Data;
using Domain;

namespace Codecool.CodecoolShop.Services
{
    public interface IAccountService
    {

    }

    public class AccountService
    {
        private readonly CodecoolShopContext _context;

        public AccountService(CodecoolShopContext context)
        {
            _context = context;
        }

        public void SignUpUser(SignUp dto)
        {
            var newUser = new User()
            {
                Username = dto.FullName,
                Email = dto.Email,
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
