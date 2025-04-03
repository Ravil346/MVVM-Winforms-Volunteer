using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IModuleRepository<in T> : IModuleUserFunc<T>
    {
        public void DeleteModule(string name);
        public void UpdateModule(int id, Module newmodule);
        public void AddModule(T request);
        public IQueryable<Module> GetModules();
        public IEnumerable<Module> GetModules(Func<Module, bool> func);
        public IEnumerable<Module> GetTheoreticalModules(Func<Module, bool> func);
        public IEnumerable<Module> GetTestModules(Func<Module, bool> func);
        public Module? GetModule(string name);
    }
}
