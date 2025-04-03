using EntityFrameworkCore.Projectables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public TypeModule? Type { get; set; }
        public bool IsActive { get; set; }
        public int? Exists { get; set; }
        public List<User>? UsersTest { get; set; } = new List<User>();
        public List<User>? UsersTheoretical { get; set; } = new List<User>();
        public List<Aim>? TasksTest { get; set; } 
        public List<Aim>? TasksTheoretical {  set; get; }
    }
}
