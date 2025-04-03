using Data.Entities;
using Data.Interfaces.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    /// <summary>
    /// Интерфейс IUserRepositry объединяет функциональность для работы с пользователями в системе.
    /// Он наследует методы из интерфейсов IGetUser, ICreateUser<T>, IDeleteUser и IUpdateUser<T>,
    /// предоставляя полный набор операций CRUD (Create, Read, Update, Delete) для управления пользователями.
    /// </summary>
    /// <typeparam name="T">Тип данных, представляющий информацию о пользователе (например, UserInfoRequest).</typeparam>
    public interface IUserRepositry<in T> : IGetUser, ICreateUser<T>, IDeleteUser, IUpdateUser<T>
    {
        // Все методы наследуются от базовых интерфейсов:
        // - IGetUser: методы для получения пользователей.
        // - ICreateUser<T>: методы для создания пользователей.
        // - IDeleteUser: методы для удаления пользователей.
        // - IUpdateUser<T>: методы для обновления пользователей.
    }
}
