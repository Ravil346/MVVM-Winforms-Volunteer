using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Models.Request
{
    public class IncidentInfoRequest
    {
        public string? Name { get; set; }
        public FileInfoRequest FileInfo { get; set; } = null!;
        public User? User { get; set; }
    }
}
