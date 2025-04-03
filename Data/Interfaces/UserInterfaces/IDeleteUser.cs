using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.UserInterfaces
{
    /// <summary>
    /// Интерфейс IDeleteUser определяет методы для удаления пользователя из системы.
    /// Он предоставляет возможность удаления пользователя как по уникальному идентификатору, так и по электронной почте.
    /// </summary>
    public interface IDeleteUser
    {
        // Удаляет пользователя из системы по его уникальному идентификатору.
        public void Delete(int id);

        // Удаляет пользователя из системы по его электронной почте.
        public void Delete(string email);
    }
}
