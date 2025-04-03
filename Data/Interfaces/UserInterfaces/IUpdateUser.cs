using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Data.Interfaces.UserInterfaces
{
    /// <summary>
    /// Интерфейс IUpdateUser определяет методы для обновления данных пользователя в системе.
    /// Он предоставляет возможность обновления пользователя как по уникальному идентификатору, так и по электронной почте.
    /// </summary>
    /// <typeparam name="T">Тип данных, представляющий информацию о пользователе (например, UserInfoRequest).</typeparam>
    public interface IUpdateUser<in T>
    {
        // Обновляет данные пользователя в системе по его уникальному идентификатору.
        // Параметр newModel содержит новые данные пользователя.
        public void Update(int id, User newModel);

        // Обновляет данные пользователя в системе по его электронной почте.
        // Параметр newModel содержит новые данные пользователя.
        public void Update(string email, User newModel);
    }
}
