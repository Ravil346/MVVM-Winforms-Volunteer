using Amazon.S3.Model;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic.Extensions;
using BuisnessLogic.Models;
using BuisnessLogic.Models.Request;
using Data;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.ViewModel.WorkForm
{
    public partial class AddModuleForm: Form
    {
        private IYandexClient _YandexClient { get; set; }
        private TypeModule _TypeModule { get; set; }
        private int _CounterFileForTher {  get; set; }
        public Module Module { get; set; }
        
        public int _CounterTask = 0;
        private IModuleRepository<ModuleInfoRequest> ModuleRepository { get; set; }
        public AddModuleForm(IYandexClient yandexClient, TypeModule typeModule, Point? location = null)
        {
            InitializeComponent();
            
            var unitOfWork = UnitOfWorkInit.GetUnitOfWork();

            ModuleRepository = unitOfWork.Modules;

            if(typeModule is TypeModule.Test)
            {
                Module = new Module()
                {
                    TasksTest = new List<Aim>(),
                    Type = typeModule
                    
                };
            }
            if (typeModule is TypeModule.Theoretical)
            {
                Module = new Module()
                {
                    TasksTheoretical = new List<Aim>(),
                    Type = typeModule
                };
            }

            _YandexClient = yandexClient;
            _TypeModule = typeModule;
            this.Location = location ?? new Point(0,0);
        }
        private void Test_CheckedChanged()
        {
            planeForTypeAttribute.Controls.Clear();
            var button = new Button()
            {
                Text = "Добавить задание",
                Size = new Size(250, 30),
                Font = FormConstStorage.BaseFont,
                BackColor = Color.White,
                ForeColor = FormConstStorage.BaseForeColorForButton,
            };
            button.Click += Button_Click;
            planeForTypeAttribute.Controls.Add(button);
        }
        private void Theoretical_CheckedChanged()
        {
            Module.TasksTheoretical = ExtensionsManagers.SetNewTasks();
            
            planeForTypeAttribute.Controls.Clear();
            var label = new Label()
            {
                AutoSize = true,
                Text = "Введите теорию",
                Font = FormConstStorage.BaseFont,
                ForeColor = FormConstStorage.BaseForeColorForButton,
            };
            planeForTypeAttribute.Controls.Add(label);
            var textbox = new TextBox()
            {
                Location = new Point(planeForTypeAttribute.Location.X,label.Location.Y + 30),
                Size = new Size(100, 100),
            };
            var buttonAddFile = new Button()
            {
                Location = new Point(planeForTypeAttribute.Location.X, textbox.Location.Y + 30),
                Text = "Добавить файлы",
                AutoSize = true,
                BackColor = Color.White,
            };
            buttonAddFile.Click += ButtonAddFile_Click;
            textbox.TextChanged += TextboxTheoretical_TextChanged;
            planeForTypeAttribute.Controls.Add(textbox);
            planeForTypeAttribute.Controls.Add(buttonAddFile);
        }
        // не забудь добавить видео формат
        private async void ButtonAddFile_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = true,
            };
            var dialog = openFileDialog.ShowDialog();
            if (dialog == DialogResult.Cancel) return;
            foreach (var path in openFileDialog.FileNames.Select(x => $@"{x}"))
            {
                using (var file = new FileStream(path, FileMode.Open))
                {
                    var par1 = path.Substring(0, path.LastIndexOf(@"\"));
                    var par2 = path.Substring(path.LastIndexOf(@"\") + 1);
                    var res = await _YandexClient.AddModel(file, par1, par2);
                    if (!res.isCorrect) continue;
                    if(_TypeModule is TypeModule.Test)
                    Module.TasksTest![0].Content!.BinaryDatas!.Add(new BinaryData() { LinkOnData = res.resultUrlFromModel });
                    if (_TypeModule is TypeModule.Theoretical)
                     Module.TasksTheoretical![0].Content!.BinaryDatas!.Add(new BinaryData() { LinkOnData = res.resultUrlFromModel });
                }
            }
        }

        private void TextboxTheoretical_TextChanged(object? sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            Module.TasksTheoretical![0].Content!.Text = textbox!.Text;
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            var form = new AddTask(_YandexClient);
            var dialog = form.ShowDialog();
            if (dialog == DialogResult.Cancel) return;
            Module.TasksTest!.Add(form.Assignment);
            Module.Exists = 1;
            _CounterTask++;
            labelQuantityTask.Text = "Количество заданий: " + _CounterTask;
        }
       

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                MessageBox.Show("Введите имя");
                return;
            }
            Module.Name = textName.Text;
            ModuleRepository.AddModule(new ModuleInfoRequest()
            {
                Name = Module.Name,
                TestTasks = Module.TasksTest,
                TheoreticalTasks = Module.TasksTheoretical,
                TypeModule = (TypeModule)Module.Type,
            });
            DialogResult = DialogResult.OK;
            Close();
        }

        private void AddModuleForm_Load(object sender, EventArgs e)
        {
            switch (_TypeModule)
            {
                case TypeModule.Test:
                    Test_CheckedChanged();
                    break;
                case TypeModule.Theoretical:
                    Theoretical_CheckedChanged();
                    break;
            }
        }
    }
}
