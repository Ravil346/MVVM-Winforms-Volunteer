using BuisnessLogic.Extensions;
using BuisnessLogic.Models.Request;
using Data;
using Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Validators
{
    public class IncidentValidator : AbstractValidator<IncidentInfoRequest>
    {
        public IncidentValidator(AppDbContext dbContext,bool userIsNotNull = false, bool streamIsNotNull = false)
        {
            if (userIsNotNull)
            {
                RuleFor(x => x.User).NotNull();
                RuleFor(x => x.User!.Email).IsValidEmail();
            }

            if (streamIsNotNull)
            {
                RuleFor(x => x.FileInfo).NotNull();
                RuleFor(x => x.FileInfo.Path).NotEmpty().NotNull();
                RuleFor(x => x.FileInfo.Name).NotEmpty().NotNull();
                RuleFor(x => x.FileInfo.File).NotEmpty().NotNull();
                RuleFor(x => x.Name).NotEmpty().NotNull();
            }
           
               
        }
    }
}
