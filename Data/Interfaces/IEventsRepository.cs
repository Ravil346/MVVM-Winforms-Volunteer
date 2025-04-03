using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Data.Interfaces
{
    /// <summary>
    /// Интерфейс IEventsRepository определяет методы для работы с инцидентами в системе.
    /// Он наследует функциональность от интерфейса IEventsUserFunc<T> и предоставляет дополнительные методы для управления инцидентами.
    /// </summary>
    /// <typeparam name="T">Тип данных, представляющий запрос для создания или обновления инцидента.</typeparam>
    public interface IEventsRepository<in T> : IEventsUserFunc<T>
    {
        // Возвращает IQueryable коллекцию всех инцидентов.
        // Позволяет выполнять дополнительные запросы к базе данных.
        public IQueryable<Incident> GetIncidents();

        // Возвращает коллекцию инцидентов, соответствующих заданному условию (expr).
        public IEnumerable<Incident> GetIncidents(Func<Incident, bool> expr);

        // Асинхронно добавляет новый инцидент в систему на основе переданного запроса (request).
        public Task AddIncident(T request);

        // Удаляет инцидент из системы по его уникальному идентификатору (id).
        public void DeleteIncident(int id);

        // Обновляет данные инцидента в системе по его уникальному идентификатору (id).
        // Параметр newModel содержит новые данные инцидента.
        public void UpdateIncident(int id, Incident newModel);
    }
}
