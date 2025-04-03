using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.UserInterfaces
{
    public interface IGetUser
    {
        public IEnumerable<User> GetUsers(Func<User, bool> exprfinding, bool asNoTracking = false);
        public IQueryable<User> GetUsers(bool asNoTracking = false);
        public User? Get(int id);
        public User? Get(string email);
        public IEnumerable<User> Get<T>(string propertyName, T propertyValue) where T : class;
    }
}
