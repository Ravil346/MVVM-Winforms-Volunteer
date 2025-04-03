using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using User = Data.Entities.User;

namespace App.Inputs
{
    public interface ICheckInput
    {
        public bool InputCheck(User user);
    }
}
