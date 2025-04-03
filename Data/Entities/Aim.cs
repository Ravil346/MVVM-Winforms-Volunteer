using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    /// <summary>
    /// Класс Aim представляет собой сущность "Цель" в базе данных.
    /// Цель связана с контентом и может быть ассоциирована как с тестовыми, так и с теоретическими модулями.
    /// </summary>
    public class Aim
    {
        // Уникальный идентификатор цели. Используется как первичный ключ в базе данных.
        public int Id { get; set; }

        // Ссылка на контент, связанный с целью. Это свойство представляет связь "один-к-одному" или "один-ко-многим"
        // с таблицей Content. Может быть null, если контент не назначен.
        public Content? Content { get; set; }

        // Навигационное свойство для связи с тестовым модулем (TestModule).
        // Представляет связь "многие-к-одному" с таблицей Module.
        public virtual Module? TestModel { get; set; } 

        // Внешний ключ для связи с тестовым модулем (TestModule).
        // Может быть null, если цель не связана с тестовым модулем.
        public int? TestModuleId { get; set; }

        // Навигационное свойство для связи с теоретическим модулем (TheoreticalModule).
        // Представляет связь "многие-к-одному" с таблицей Module.
        public virtual Module? TheoreticalModel { get; set; }

        // Внешний ключ для связи с теоретическим модулем (TheoreticalModule).
        // Может быть null, если цель не связана с теоретическим модулем.
        public int? TheoretiesModuleId { get; set; }
    }
}
