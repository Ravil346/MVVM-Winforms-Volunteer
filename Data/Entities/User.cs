
using EntityFrameworkCore.Projectables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Patronymic { get; set; }
        public string? Name { get; set; }
        public string? ScoutGroup { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Institute { get; set; }
        public string? Salt {  get; set; }
        public bool? IsAdmin { get; set; }
        public BinaryData? Photo { get; set; }
        public string? PasswordHash { get; set; }
        [Projectable]
        public string FullName => Name + Surname + Patronymic;
        public List<Module>? TestModules {  get; set; } = new List<Module>();
        public List<Module>? TheoreticalModules {  get; set; } = new List<Module>();
        public List<Incident> Incidents { get; set; } = new List<Incident>();
    }
}
