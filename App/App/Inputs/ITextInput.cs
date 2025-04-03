using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Inputs
{
    public interface ITextInput
    {
        public bool InputText(User user);
    }
}
