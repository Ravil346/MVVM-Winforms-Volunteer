using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public delegate bool UserAction(User user);
    public interface IModuleUserFunc<in T>
    {
        public void DeleteOnUser(T request, int userid);
        public void DeleteOnUser(T request, string email);
        public void AddLinkOnUser(T request, int userid);
        public void AddLinkOnUser(T request, string email);
        public void ChangeModuleOnUser(string userEmail, string nameModule, TypeModule typeModule, Module newModule);
    }
}
