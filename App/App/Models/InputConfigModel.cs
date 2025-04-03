using BuisnessLogic.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class InputConfigModel
    {
        public ModuleOnUserInfo Info { get; set; } = null!;
        public int Position { get; set; }
        public Control? Control {  get; set; }
    }
}
