using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IEventsUserFunc<in T>
    {
        public void DeleteLinkOnUser(int id, int userid);
        public void AddLinkOnUser(T request);
        public IEnumerable<Incident>? GetUserIncidents(int id);
    }
}
