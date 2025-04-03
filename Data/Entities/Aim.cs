using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Aim
    {
        public int Id { get; set; }
        
        public Content? Content { get; set; }
        
        public virtual Module? TestModel { get; set; } 
        
        public int? TestModuleId { get; set; }
        
        public virtual Module? TheoreticalModel { get; set; }
        
        public int? TheoretiesModuleId { get; set; }
    }
}
