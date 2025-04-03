using BuisnessLogic.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Models.Request
{
    public class PasswordSaltOptions : SaltResultModel
    {
        public string Password { get; set; } = null!;
    }
}
