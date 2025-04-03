using BuisnessLogic.Extensions;
using BuisnessLogic.Models.Request;
using Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Validators
{
    public class UserValidator : AbstractValidator<UserInfoRequest>
    {
        private AppDbContext _Database;
        public UserValidator(AppDbContext dbContext, IList<string>? proprertyCanNotRepeatList = null)
        {
            _Database = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            RuleFor(x => x.Email)
                .IsValidEmail();
            ValidOnRepeat();
            
        }
        private void ValidOnRepeat(IList<string>? proprertyCanNotRepeatList = null)
        {
            if (proprertyCanNotRepeatList is not null)
            {
                var list = _Database.Users.ToList().Select(x => new UserInfoRequest()
                {
                    Email = x.Email,
                    Id = x.Id,
                    Salt = x.Salt,
                    Surname = x.Surname,
                    IsAdmin = x.IsAdmin,
                    Name = x.Name,
                    PasswordHash = x.PasswordHash,
                    Patronymic = x.Patronymic,
                });
                foreach (var prop in proprertyCanNotRepeatList)
                {
                    RuleFor(x => x)
                        .PropertyValueMustNotRepeat(list, prop);
                }
            }
        }
    }
}
