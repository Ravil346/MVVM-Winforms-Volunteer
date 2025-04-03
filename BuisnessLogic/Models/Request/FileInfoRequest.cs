using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Models.Request
{
    public class FileInfoRequest
    {
        public string? Name { get; set; }
        public Stream? File { get; set; }
        public string? Path { get; set; }
    }
}
