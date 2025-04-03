using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Models.Request
{
    public class ContentOptions(string useranswer, string corretcanswer, string text, TypeInput typeInput, List<ConfusingAnswers> confusinganswers)
    {
        public string UserAnswer => useranswer;
        public string CorrectAnswer  => corretcanswer;
        public string Text => text;
        public TypeInput TypeInput => typeInput;
        public IList<ConfusingAnswers>? ConfusingAnswers => confusinganswers;
    }
}
