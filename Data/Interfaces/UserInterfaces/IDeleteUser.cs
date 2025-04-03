using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.UserInterfaces
{
    public interface IDeleteUser
    {
        public void Delete(int id);
        public void Delete(string email);
    }
}
