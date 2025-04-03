using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string? UserAnswer { get; set; }
        public string? CorrectAnswer { get; set; }
        public string? Text { get; set; }
        public TypeInput TypeInput { get; set; }

        /// <summary>
        /// Question or text in theory
        /// </summary>
        public Aim? Task { get; set; }
        public int? TaskId { get; set; }
        public IList<BinaryData>? BinaryDatas { get; set; }
        public IList<ConfusingAnswers>? ConfusingAnswers { get; set; }
    }
}
