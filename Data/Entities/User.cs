
using EntityFrameworkCore.Projectables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    /// <summary>
    /// Класс User представляет модель пользователя системы. 
    /// Он содержит информацию о личных данных, учетных данных и связях с другими сущностями, такими как модули и инциденты.
    /// </summary>
    public class User
    {
        // Уникальный идентификатор пользователя.
        public int Id { get; set; }

        // Фамилия пользователя.
        public string? Surname { get; set; }

        // Электронная почта пользователя. Используется для входа в систему.
        public string? Email { get; set; }

        // Отчество пользователя.
        public string? Patronymic { get; set; }

        // Имя пользователя.
        public string? Name { get; set; }

        // Волонтёрский отряд или группа пользователя.
        public string? ScoutGroup { get; set; }

        // Номер телефона пользователя.
        public string? PhoneNumber { get; set; }

        // Институт или организация, к которой принадлежит пользователь.
        public string? Institute { get; set; }

        // Соль для хэширования пароля. Используется для повышения безопасности при хранении паролей.
        public string? Salt { get; set; }

        // Флаг, указывающий, является ли пользователь администратором. True — администратор, False — обычный пользователь.
        public bool? IsAdmin { get; set; }

        // Связь с объектом бинарных данных (BinaryData), представляющим фото пользователя.
        public BinaryData? Photo { get; set; }

        // Хэш пароля пользователя. Используется для безопасного хранения учетных данных.
        public string? PasswordHash { get; set; }

        // Полное имя пользователя, объединяющее имя, фамилию и отчество.
        [Projectable]
        public string FullName => $"{Name} {Surname} {Patronymic}";

        // Список тестовых модулей, связанных с пользователем. Может использоваться для отслеживания прогресса в тестах.
        public List<Module>? TestModules { get; set; } = new List<Module>();

        // Список теоретических модулей, связанных с пользователем. Может использоваться для отслеживания обучения.
        public List<Module>? TheoreticalModules { get; set; } = new List<Module>();

        // Список инцидентов, связанных с пользователем. Может использоваться для отслеживания событий или проблем.
        public List<Incident> Incidents { get; set; } = new List<Incident>();
    }
}
