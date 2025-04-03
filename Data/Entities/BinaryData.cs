using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BinaryData
    {
        public int Id { get; set; }
        public string? LinkOnData { get; set; }
        public TypeFile? TypeFile { get; set; }
        public int PositionInText { get; set; }
        public Incident? Incident { get; set; }
        public int? IncidentId { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }
        public Content? Content { get; set; }
        public int? ContentId { get; set; }
        
    }
}
