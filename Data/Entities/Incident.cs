using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    /// <summary>
    /// Класс Incident представляет собой модель для хранения информации о происшествиях (инцидентах). 
    /// Он содержит данные о названии, связанных пользователях, бинарных данных и статусе существования инцидента.
    /// </summary>
    public class Incident
    {
        // Уникальный идентификатор инцидента.
        public int Id { get; set; }

        // Название инцидента. Описывает суть или тему происшествия.
        public string? Name { get; set; }

        // Связь с объектом бинарных данных (BinaryData), если к инциденту прикреплены файлы (например, изображения или документы).
        public BinaryData? BinaryData { get; set; }

        // Список пользователей, связанных с этим инцидентом. Может использоваться для отслеживания участников или ответственных лиц.
        public List<User> Users { get; set; } = new List<User>();

        // Флаг, указывающий на существование инцидента. Может использоваться для отметки активности или завершения инцидента.
        public int? Exists { get; set; }
    }
}
