using BuisnessLogic.Extensions;
using BuisnessLogic.Models.Request;
using Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Validators
{
    public class ModuleValidator : AbstractValidator<ModuleInfoRequest>
    {
        public ModuleValidator(TypeModule? type = null, bool typeRequirementsEnable = false,bool tasktestIsNotNull = false, bool tasktherIsNotNull = false)
        {

            RuleFor(x => x.Name)
               .NotNull()
               .NotEmpty();

            if (tasktestIsNotNull)
            RuleFor(x => x.TestTasks)
                .NotNull();
            if(tasktherIsNotNull)
            RuleFor(x => x.TheoreticalTasks)
               .NotNull();

        }
    }
}
