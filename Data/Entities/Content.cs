using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    /// <summary>
    /// Класс Content представляет собой модель для хранения контента, который может быть связан с вопросами,
    /// теорией или другими элементами системы. Он содержит информацию о тексте, ответах, типе ввода и связанных данных.
    /// </summary>
    public class Content
    {
        // Уникальный идентификатор контента.
        public int Id { get; set; }

        // Ответ пользователя на вопрос или задачу.
        public string? UserAnswer { get; set; }

        // Правильный ответ на вопрос или задачу.
        public string? CorrectAnswer { get; set; }

        // Текст контента (например, описание вопроса или теоретический материал).
        public string? Text { get; set; }

        // Тип ввода, который определяет формат ответа (например, текстовое поле, выбор из списка и т.д.).
        public TypeInput TypeInput { get; set; }

        // Связь с объектом цели (Aim), которая представляет собой вопрос или теорию.
        public Aim? Task { get; set; }

        // Идентификатор цели (TaskId), к которой относится этот контент.
        public int? TaskId { get; set; }

        // Список бинарных данных (например, изображений или файлов), связанных с этим контентом.
        public IList<BinaryData>? BinaryDatas { get; set; }

        // Список запутанных или сложных ответов, связанных с этим контентом.
        public IList<ConfusingAnswers>? ConfusingAnswers { get; set; }
    }
}
