using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Data.Interfaces
{
    public interface IEventsRepository<in T> : IEventsUserFunc<T>
    {
        public IQueryable<Incident> GetIncidents();
        public IEnumerable<Incident> GetIncidents(Func<Incident, bool> expr);
        public Task AddIncident(T request);
        public void DeleteIncident(int id);
        public void UpdateIncident(int id, Incident newModel);

    }
}
