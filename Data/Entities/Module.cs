using EntityFrameworkCore.Projectables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    /// <summary>
    /// Класс Module представляет собой модель для хранения информации о модулях, которые могут быть теоретическими или тестовыми.
    /// Он содержит данные о названии, типе модуля, его активности и связанных пользователях и задачах.
    /// </summary>
    public class Module
    {
        // Уникальный идентификатор модуля.
        public int Id { get; set; }

        // Название модуля. Описывает тему или цель модуля.
        public string? Name { get; set; }

        // Тип модуля (например, теоретический или тестовый). Используется для определения назначения модуля.
        public TypeModule? Type { get; set; }

        // Флаг, указывающий, является ли модуль активным. True — модуль доступен, False — модуль неактивен.
        public bool IsActive { get; set; }

        // Флаг, указывающий на существование модуля. Может использоваться для отметки удаления или архивации модуля.
        public int? Exists { get; set; }

        // Список пользователей, связанных с тестовой частью модуля. Может использоваться для отслеживания участников тестов.
        public List<User>? UsersTest { get; set; } = new List<User>();

        // Список пользователей, связанных с теоретической частью модуля. Может использоваться для отслеживания участников обучения.
        public List<User>? UsersTheoretical { get; set; } = new List<User>();

        // Список задач (целей), связанных с тестовой частью модуля. Содержит вопросы или задания для тестирования.
        public List<Aim>? TasksTest { get; set; }

        // Список задач (целей), связанных с теоретической частью модуля. Содержит материалы или вопросы для обучения.
        public List<Aim>? TasksTheoretical { get; set; }
    }
}
