using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    /// <summary>
    /// Делегат UserAction представляет метод, который принимает объект пользователя (User) и возвращает логическое значение.
    /// Используется для выполнения действий или проверок, связанных с пользователем.
    /// </summary>
    public delegate bool UserAction(User user);
    
    /// <summary>
    /// Интерфейс IModuleUserFunc определяет методы для управления связями между пользователями и модулями.
    /// Он предоставляет функциональность для добавления, удаления и изменения модулей, связанных с конкретным пользователем.
    /// </summary>
    /// <typeparam name="T">Тип данных, представляющий запрос для создания или обновления связи между пользователем и модулем.</typeparam>
    public interface IModuleUserFunc<in T>
    {
        // Удаляет связь между модулем и пользователем на основе переданного запроса (request)
        // и идентификатора пользователя (userid).
        public void DeleteOnUser(T request, int userid);

        // Удаляет связь между модулем и пользователем на основе переданного запроса (request)
        // и электронной почты пользователя (email).
        public void DeleteOnUser(T request, string email);

        // Добавляет связь между пользователем и модулем на основе переданного запроса (request)
        // и идентификатора пользователя (userid).
        public void AddLinkOnUser(T request, int userid);

        // Добавляет связь между пользователем и модулем на основе переданного запроса (request)
        // и электронной почты пользователя (email).
        public void AddLinkOnUser(T request, string email);

        // Изменяет модуль, связанный с пользователем, на основе его электронной почты (userEmail),
        // названия модуля (nameModule), типа модуля (typeModule) и новых данных модуля (newModule).
        public void ChangeModuleOnUser(string userEmail, string nameModule, TypeModule typeModule, Module newModule);
    }
}
