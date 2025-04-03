using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    /// <summary>
    /// Интерфейс IModuleRepository определяет методы для работы с модулями в системе.
    /// Он наследует функциональность от интерфейса IModuleUserFunc<T> и предоставляет дополнительные методы для управления модулями.
    /// </summary>
    /// <typeparam name="T">Тип данных, представляющий запрос для создания или обновления модуля.</typeparam>
    public interface IModuleRepository<in T> : IModuleUserFunc<T>
    {
        // Удаляет модуль из системы по его названию (name).
        public void DeleteModule(string name);

        // Обновляет данные модуля в системе по его уникальному идентификатору (id).
        // Параметр newmodule содержит новые данные модуля.
        public void UpdateModule(int id, Module newmodule);

        // Добавляет новый модуль в систему на основе переданного запроса (request).
        public void AddModule(T request);

        // Возвращает IQueryable коллекцию всех модулей.
        // Позволяет выполнять дополнительные запросы к базе данных.
        public IQueryable<Module> GetModules();

        // Возвращает коллекцию модулей, соответствующих заданному условию (func).
        public IEnumerable<Module> GetModules(Func<Module, bool> func);

        // Возвращает коллекцию теоретических модулей, соответствующих заданному условию (func).
        public IEnumerable<Module> GetTheoreticalModules(Func<Module, bool> func);

        // Возвращает коллекцию тестовых модулей, соответствующих заданному условию (func).
        public IEnumerable<Module> GetTestModules(Func<Module, bool> func);

        // Возвращает модуль по его названию (name).
        // Если модуль не найден, возвращается null.
        public Module? GetModule(string name);
    }
}
