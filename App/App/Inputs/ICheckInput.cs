using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace App.Inputs
{
    public interface ICheckInput
    {
        public bool InputCheck(User user);
    }
}
