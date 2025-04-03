using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Models
{
    public class TaskPanelContext
    {
        public Module Module { get; set; } = null!;
        public int Position { get; set; }

        public string? UserEmail { get; set; }
    }
}
