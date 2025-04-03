using BuisnessLogic.Models.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Validators
{
    public class PasswordValidator : AbstractValidator<PasswordSaltOptions>
    {
        public PasswordValidator(bool saltValid = false, bool hashValid = false)
        {
            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull();
            if(saltValid)
            RuleFor(u => u.Salt)
                .NotEmpty()
                .NotNull();
            if(hashValid)
            RuleFor(u => u.Hash)
                .NotEmpty()
                .NotNull();
        }
    }
}
