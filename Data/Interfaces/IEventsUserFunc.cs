using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    /// <summary>
    /// Интерфейс IEventsUserFunc определяет методы для управления связями между пользователями и инцидентами.
    /// Он предоставляет функциональность для добавления, удаления и получения инцидентов, связанных с конкретным пользователем.
    /// </summary>
    /// <typeparam name="T">Тип данных, представляющий запрос для создания связи между пользователем и инцидентом.</typeparam>
    public interface IEventsUserFunc<in T>
    {
        // Удаляет связь между инцидентом и пользователем.
        // Параметр id указывает идентификатор инцидента, а userid — идентификатор пользователя.
        public void DeleteLinkOnUser(int id, int userid);

        // Добавляет связь между пользователем и инцидентом на основе переданного запроса (request).
        public void AddLinkOnUser(T request);

        // Возвращает коллекцию инцидентов, связанных с пользователем по его уникальному идентификатору (id).
        // Если инциденты отсутствуют, возвращается null.
        public IEnumerable<Incident>? GetUserIncidents(int id);
    }
}
