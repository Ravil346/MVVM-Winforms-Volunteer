using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    /// <summary>
    /// Класс BinaryData представляет бинарные данные (например, изображения, видео или другие файлы), связанные с контентом.
    /// Этот класс хранит ссылку на внешний ресурс или путь к файлу, а также информацию о связи с другими сущностями (например, пользователями или инцидентами).
    /// </summary>
    public class BinaryData
    {
        // Уникальный идентификатор бинарных данных.
        public int Id { get; set; }

        // Ссылка на внешний ресурс или путь к файлу, содержащему бинарные данные.
        public string? LinkOnData { get; set; }

        // Тип файла (например, изображение, видео и т. д.). Используется для определения типа содержимого.
        public TypeFile? TypeFile { get; set; }

        // Позиция, где эти данные должны быть вставлены в текст задачи.
        public int PositionInText { get; set; }

        // Связь с объектом инцидента (Incident), если данные связаны с инцидентом.
        public Incident? Incident { get; set; }

        // Идентификатор инцидента (IncidentId), если данные связаны с инцидентом.
        public int? IncidentId { get; set; }

        // Связь с пользователем (User), если данные загружены пользователем.
        public User? User { get; set; }

        // Идентификатор пользователя (UserId), если данные связаны с пользователем.
        public int? UserId { get; set; }

        // Связь с контентом (Content), к которому относятся эти данные.
        public Content? Content { get; set; }

        // Идентификатор контента (ContentId), если данные связаны с контентом.
        public int? ContentId { get; set; }
    }
}
