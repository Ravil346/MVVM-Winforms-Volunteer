﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Incident
    {
        public int Id { get; set; }
       
        public string? Name { get; set; }
        public BinaryData? BinaryData { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public int? Exists {  get; set; } 
    }
}
