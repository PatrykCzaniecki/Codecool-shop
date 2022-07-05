using System.Linq;
using Data;
using Domain;
using FluentValidation;

namespace Codecool.CodecoolShop.Models.Validators;

//public class SignUpValidator : AbstractValidator<SignUp>
//{
//    public SignUpValidator(CodecoolShopContext dbContext)
//    {
//        RuleFor(x => x.Email).NotEmpty().EmailAddress();

//        RuleFor(x => x.Password).MinimumLength(6);

//        RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

//        RuleFor(x => x.Email).Custom((value, context) =>
//        {
//            var emailInUse = dbContext.Users.Any(u => u.Email == value);
//            if (emailInUse) context.AddFailure("Email", "That email is taken");
//        });
//    }
//}