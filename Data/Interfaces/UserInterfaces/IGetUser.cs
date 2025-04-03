using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.UserInterfaces
{
    /// <summary>
    /// Интерфейс IGetUser определяет методы для получения пользователей из системы.
    /// Он предоставляет различные способы поиска и фильтрации пользователей.
    /// </summary>
    public interface IGetUser
    {
        // Возвращает коллекцию пользователей, соответствующих заданному условию (exprfinding).
        // Параметр asNoTracking определяет, следует ли отслеживать изменения возвращаемых объектов.
        public IEnumerable<User> GetUsers(Func<User, bool> exprfinding, bool asNoTracking = false);

        // Возвращает IQueryable коллекцию всех пользователей.
        // Параметр asNoTracking определяет, следует ли отслеживать изменения возвращаемых объектов.
        public IQueryable<User> GetUsers(bool asNoTracking = false);

        // Возвращает пользователя по его уникальному идентификатору (id).
        // Если пользователь не найден, возвращается null.
        public User? Get(int id);

        // Возвращает пользователя по его электронной почте (email).
        // Если пользователь не найден, возвращается null.
        public User? Get(string email);

        // Возвращает коллекцию пользователей, у которых указанное свойство (propertyName) 
        // соответствует заданному значению (propertyValue).
        // T — тип значения свойства.
        public IEnumerable<User> Get<T>(string propertyName, T propertyValue) where T : class;
    }
}
