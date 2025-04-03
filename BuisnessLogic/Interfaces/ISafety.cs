using BuisnessLogic.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.interfaces
{
    public interface ISafety
    {
        public bool Compare();
        public SaltResultModel Salt(uint length = 8);
    }
}
