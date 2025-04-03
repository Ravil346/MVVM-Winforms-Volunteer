using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    /// <summary>
    /// Класс ConfusingAnswers представляет собой модель для хранения запутанных или сложных ответов, 
    /// которые могут быть связаны с определенным контентом.
    /// </summary>
    public class ConfusingAnswers
    {
        // Уникальный идентификатор записи.
        public int Id { get; set; }

        // Текст запутанного или сложного ответа.
        public string? Text { get; set; }

        // Идентификатор контента (ContentId), к которому относится этот ответ.
        public int? ContentId { get; set; }

        // Связь с объектом контента (Content), к которому относится этот ответ.
        public Content? Content { get; set; }
    }
}
