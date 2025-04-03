using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.UserInterfaces
{
    /// <summary>
    /// Интерфейс ICreateUser определяет метод для создания пользователя.
    /// Он является обобщенным (generic) и позволяет работать с различными типами данных, представляющими информацию о пользователе.
    /// </summary>
    /// <typeparam name="T">Тип данных, представляющий информацию о пользователе (например, UserInfoRequest).</typeparam>
    public interface ICreateUser<in T>
    {
        /// Метод Create используется для создания нового пользователя.
        public void Create(T userinfo);
    }
}
