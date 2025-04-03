using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Models.Request
{
    public class ModuleOnUserInfo
    {
        public string Name { get; set; } = null!;
        public TypeModule TypeModule { get; set; }
    }
}
