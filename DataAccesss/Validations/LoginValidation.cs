using Entity.DbModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Validations
{
    public class LoginValidation : AbstractValidator<User>
    {
        public LoginValidation()
        {
            RuleFor(s => s.Mail).NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");
            RuleFor(s => s.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
