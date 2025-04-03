using App.Models;
using BuisnessLogic.Models;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Services;
using Data;
using Data.Entities;
using Data.interfaces;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Inputs
{
    public class InputMethods : IRadioInput, ITextInput, ICheckInput
    {
        private IModuleUserFunc<ModuleInfoRequest> _Repository;
        private Control _Object;
        private int _Position;
        private string _Name;
        public InputMethods(InputConfigModel configModel, IModuleUserFunc<ModuleInfoRequest> repository)
        {
            _Repository = repository ?? throw new ArgumentNullException(nameof(repository));

            _Object = configModel.Control ?? throw new ArgumentNullException(nameof(configModel.Control));

            _Position = configModel.Position;

            _Name = configModel.Info.Name;

        }
        public bool InputRadio(User user)
        {
            var task = ReturnTask(user)!;

            Panel panel = (_Object as Panel)!;

            List<RadioButton> radioButtons = new List<RadioButton>();

            foreach (var control in panel.Controls)
            {
                var rb = control as RadioButton;

                if (rb is null) throw new InvalidCastException();

                radioButtons.Add(rb);
            }
            var answerButton = radioButtons.Where(x => x.Checked).FirstOrDefault();

            if (answerButton is null) throw new NullReferenceException("Nothing answer");

            var answer = answerButton.Text;

            task.Content!.UserAnswer = answer;

            _Repository.ChangeModuleOnUser(user.Email!, task.TestModel!.Name!, TypeModule.Test ,task.TestModel);

            return task.Content!.CorrectAnswer!.ToLower() == answer.ToLower();
        }
        public bool InputText(User user)
        {
            var task = ReturnTask(user)!;

            TextBox textBox = (_Object as TextBox)!;

            task.Content!.UserAnswer = textBox.Text;

            _Repository.ChangeModuleOnUser(user.Email!, task.TestModel!.Name!, TypeModule.Test, task.TestModel);

            return task.Content.CorrectAnswer == textBox.Text;
        }
        public bool InputCheck(User user)
        {
            var task = ReturnTask(user)!;

            CheckedListBox list = (_Object as CheckedListBox)!;

            IList<string> answers = new List<string>();

            foreach (var item in list.Items)
            {
                var check = (item as CheckBox)!;
                if (check.Checked)
                {
                    answers.Add(check.Text);
                }
            }
            var answer = string.Join(",", answers);

            task.Content!.UserAnswer = answer;

            _Repository.ChangeModuleOnUser(user.Email!, task.TestModel!.Name!, TypeModule.Test, task.TestModel);

            return task.Content.CorrectAnswer == answer;
        }
        private Aim? ReturnTask(User user)
        {
            Aim? task = null;

            var moduleTest = user.TestModules;

            var test = moduleTest!.Where(x => x.IsActive is true).SingleOrDefault();

            if (test is null) throw new NullReferenceException(nameof(test));

            task = test.TasksTest![_Position];
            
            return task;
        }


    }
}
