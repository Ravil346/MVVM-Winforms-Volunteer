using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Data.Interfaces.UserInterfaces
{
    public interface IUpdateUser<in T>
    {
        public void Update(int id, User newModel);
        public void Update(string email, User newModel);
    }
}
