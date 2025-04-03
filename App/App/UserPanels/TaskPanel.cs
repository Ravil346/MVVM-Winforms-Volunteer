using App.Inputs;
using App.Models;
using App.ViewModel;
using AxWMPLib;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic;
using BuisnessLogic.Extensions;
using BuisnessLogic.Models;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Services.Repositories;
using Data;
using Data.ConstStorages;
using Data.Entities;
using Data.Interfaces;
using Data.Interfaces.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;
namespace App.UserPanels
{
    public class TaskPanel
    {
        
        public Panel WorkPanel { get; set; }
        
        private List<Aim> Tasks {  get; set; }
        public TaskPanelContext Context { get; private set; }
        private MainPanelContext _context;
        private IYandexClient _yandexClient;
        private Panel InnerPanel { get; set; } = new Panel()
        {
            //BackColor = Color.Black,
            AutoSize = true,
        };
        private Panel PlaneForQuestion { get; set; } = new Panel()
        {
            AutoScroll = true,
        };
        private Panel PlaneForAnswer { get; set; } = new Panel()
        {
            AutoScroll = true,
            AutoSize = true,
        };

        private Button ButtonComplete { get; set; } = new Button()
        {
            
            Text = "Завершить",
            AutoSize = true,
            Font = FormConstStorage.BaseFont,
            ForeColor = FormConstStorage.BaseForeColorForButton
        };

        private Button ButtonChange { get; set; } = new Button()
        {
            
            Text = "Изменить ответ"
            ,
            AutoSize = true,
            Font = FormConstStorage.BaseFont,
            ForeColor = FormConstStorage.BaseForeColorForButton
        };

        private Button ButtonBefore { get; set; } =  new Button()
        {
            
            Text = "Назад"
            ,
            AutoSize = true,
            Font = FormConstStorage.BaseFont,
            ForeColor = FormConstStorage.BaseForeColorForButton
        };

        private Button ButtonNext { get; set; } = new Button()
        {
           
            Text = "Далее",
            AutoSize = true,
            Font = FormConstStorage.BaseFont,
            ForeColor = FormConstStorage.BaseForeColorForButton

        };

        private Button ButtonSave { get; set; } = new Button()
        {
            Text = "Сохранить",
            AutoSize = true,
            Font = FormConstStorage.BaseFont,
            ForeColor = FormConstStorage.BaseForeColorForButton
        };
        private Button ButtonExit { get; set; } = new Button()
        {
            Size = new Size(40,40),
            Image = Image.FromFile(AppConstStorage.FileButtonExitPath),
            Location = new Point(0,1),
            AutoSize = true,

        };
        private Label Title => new Label()
        {
            Font = FormConstStorage.BaseTitleFont,
            Location = new Point(12, 10),
            ForeColor = FormConstStorage.BaseForeColorForButton,
        };
        private Panel CompletePanelBlock { get; set; } = new Panel();

        private IRadioInput? _InputRadio = null;

        private ITextInput? _InputText = null;

        private ICheckInput? _InputCheck = null;

        private IModuleUserFunc<ModuleInfoRequest> _UserModulesRepository;

        private IUserRepositry<UserInfoRequest> _UserRepositry;
        private MainUserForm _mainUserForm;

        private UnitOfWork _UnitOfWork;
        public TaskPanel(TaskPanelContext context, UnitOfWork unitOfWork,Panel basepanel, MainUserForm mainUserForm, MainPanelContext panelContext, IYandexClient yandexClient)
        {
            WorkPanel = basepanel;
            _yandexClient = yandexClient;
            _context = panelContext;
            WorkPanel.AutoSize = true;
            WorkPanel.AutoScroll = false;

            WorkPanel.Controls.Clear();

            _mainUserForm = mainUserForm;

            Context = context;

            _UserModulesRepository = unitOfWork.Modules;

            _UserRepositry = unitOfWork.Users;

            _UnitOfWork = unitOfWork;

            context.Module = unitOfWork.Modules.GetModule(context.Module.Name!)!;

            WorkPanelConfigurate();

            TaskPanelConfigurate();

            ButtonConfig();


        }
        private void WorkPanelConfigurate()
        {

            CompletePanelBlock = new Panel()
            {
                AutoSize = WorkPanel.AutoSize,
                Size = WorkPanel.Size,
                AutoScroll = WorkPanel.AutoScroll,
                Visible = false,
            };


            InnerPanel.MaximumSize = new Size(WorkPanel.Width - 35, WorkPanel.Height);

            InnerPanel.AutoSize = true;

            InnerPanel.HorizontalScroll.Visible = false;

            InnerPanel.Location = new Point(ButtonExit.Location.X, ButtonExit.Location.Y + InnerPanel.Size.Height);

            PlaneForQuestion.Size = new Size(InnerPanel.Size.Width - 30, InnerPanel.Size.Height + InnerPanel.Location.Y - 30);

            PlaneForAnswer.Size = new Size(InnerPanel.Size.Width - 30, PlaneForQuestion.Size.Height + PlaneForQuestion.Location.Y - 30);

            InnerPanel.Controls.Add(PlaneForQuestion);

            InnerPanel.Controls.Add(PlaneForAnswer);


            WorkPanel.Controls.Add(ButtonExit);

          
        }
        private void ButtonConfig()
        {
            int CommonYLocation =  PlaneForAnswer.Size.Height + PlaneForAnswer.Location.Y + 70; 

            ButtonBefore.Location = new Point(190, CommonYLocation);
            ButtonChange.Location = new Point(50, CommonYLocation);
            ButtonComplete.Location = new Point(420, CommonYLocation);
            ButtonNext.Location = new Point(300, CommonYLocation);
            ButtonSave.Location = new Point(50, CommonYLocation);

            ButtonBefore.Click += buttonBefore_Click;
            ButtonChange.Click += buttonChange_Click;
            ButtonComplete.Click += buttonComplete_Click;
            ButtonNext.Click += buttonNext_Click;
            ButtonSave.Click += buttonAnswer_Click;
            ButtonExit.Click += buttonExit_Click;

            WorkPanel.Controls.Add(ButtonComplete);
            WorkPanel.Controls.Add(ButtonSave);
            WorkPanel.Controls.Add(ButtonNext);
            WorkPanel.Controls.Add(ButtonChange);
            WorkPanel.Controls.Add(ButtonBefore);

            

            WorkPanel.Controls.Add(InnerPanel);


        }
        private void TaskPanelConfigurate()
        {
            Aim? task = null;
            Context.Module.IsActive = true;
            if (Context.Module.Type is TypeModule.Test)
            {
                 Tasks = Context.Module.TasksTest!;
                 task = Context.Module.TasksTest![Context.Position];
            }
            if(Context.Module.Type is TypeModule.Theoretical)
            {
                Tasks = Context.Module.TasksTheoretical!;
                task = Context.Module.TasksTheoretical![Context.Position];
            }
            
            var label = new Label()
            {
                Text = task.Content!.Text,
                Font = FormConstStorage.BaseFont,
                ForeColor = FormConstStorage.BaseTextColor,
                MaximumSize = new Size(InnerPanel.Width - 60, 0),
                AutoSize = true,
            };

            PlaneForQuestion.Controls.Add(label);


            var files = VisibleFile(task.Content.BinaryDatas, label);


            if (task.Content.BinaryDatas is not null) PlaneForQuestion.Controls.AddRange(files);

            PlaneForAnswer.Location = new Point(PlaneForQuestion.Location.X, PlaneForQuestion.Location.Y + PlaneForQuestion.Size.Height + 30);

            PlaneForAnswer.Controls.Add(SwitchTypeOfAnswer(task.Content.TypeInput!));

            ButtonComplete.Visible = false;

            ButtonChange.Visible = false;

            if (Context.Position == Tasks.Count - 1)
            {
                ButtonNext.Visible = false;

                ButtonComplete.Visible = true;
            }

            if (Context.Position == 0)
            {
                ButtonBefore.Visible = false;

                if (string.IsNullOrWhiteSpace(Tasks[Context.Position].Content!.UserAnswer))
                {
                    if(Context.Module.Type is TypeModule.Test)
                    _UserModulesRepository.AddLinkOnUser(new ModuleInfoRequest()
                    {
                        Name = Context.Module.Name!,
                        Id = Context.Module.Id,
                        TestTasks = Tasks,
                        IsActive = true,
                        TypeModule = (TypeModule)Context.Module.Type
                    }, Context.UserEmail!);
                    if (Context.Module.Type is TypeModule.Theoretical)
                    _UserModulesRepository.AddLinkOnUser(new ModuleInfoRequest()
                    {
                        Name = Context.Module.Name!,
                        Id = Context.Module.Id,
                        TheoreticalTasks = Tasks,
                        IsActive = true,
                        TypeModule = (TypeModule)Context.Module.Type
                    }, Context.UserEmail!);

                    var list = (_UserRepositry.GetAllUserModule(Context.Module.Name!, Context.UserEmail!, (TypeModule)Context.Module.Type) ?? throw new NullReferenceException()).ToList();

                    if (list is null || list.Count == 0) return;

                    Context.Module = list.FirstOrDefault();
                }
            }
            if (Context.Module!.Type is TypeModule.Theoretical)
            {
                ButtonChange.Visible = false;

                ButtonSave.Visible = false;

                Title.Text = "Теория: " + Context.Module.Name;
            }
            if (Context.Module!.Type is TypeModule.Test)
            {
                Title.Text = "Задание: " + Context.Module.Name;
            }
            if (!string.IsNullOrWhiteSpace(task.Content.UserAnswer))
            {
                ButtonChange.Visible = true;

                ButtonSave.Visible = false;
            }
            ButtonLocationChange([ButtonSave, ButtonBefore, ButtonComplete, ButtonChange, ButtonNext]);
        }
        private void ButtonLocationChange(IList<Button> list)
        {
            foreach (var button in list)
            {
                button.Location = new Point(button.Location.X, PlaneForAnswer.Size.Height + PlaneForAnswer.Location.Y + 30);
            }
        }

        private void buttonAnswer_Click(object? sender, EventArgs e)
        {
            if (_InputCheck is not null)
            {
                _UserRepositry.GiveAnswer(_InputCheck.InputCheck, Context.UserEmail!);
                RedirectOnPosition(Context.Position);
            }

            if (_InputRadio is not null)
            {
                _UserRepositry.GiveAnswer(_InputRadio.InputRadio, Context.UserEmail!);
                RedirectOnPosition(Context.Position);
            }

            if (_InputText is not null)
            {
                _UserRepositry.GiveAnswer(_InputText.InputText, Context.UserEmail!);
                RedirectOnPosition(Context.Position);
            }
        }
        private Control? SwitchTypeOfAnswer(TypeInput typeOfInput, string? userAnswer = null)
        {
            User? data = null;

            var task = Tasks![Context.Position];

            var ct = task.Content;

            if (typeOfInput == TypeInput.Text) return GetTextBox(ct);

            else if (typeOfInput == TypeInput.Check) return GetCheckBox(ct);

            else if (typeOfInput == TypeInput.Radio) return GetRadio(ct);

            return null;

        }
        private void buttonBefore_Click(object? sender, EventArgs e)
        {
            RedirectOnPosition(Context.Position - 1);
        }

        private void buttonNext_Click(object? sender, EventArgs e)
        {
            RedirectOnPosition(Context.Position + 1);
        }
        private void RedirectOnPosition(int pos)
        {
            var newtaskPanel = new TaskPanel(this.Context, this._UnitOfWork, this.WorkPanel, _mainUserForm, _context, _yandexClient);
            WorkPanel = newtaskPanel.WorkPanel;
        }
        private void buttonChange_Click(object? sender, EventArgs e)
        {
            var ct = Tasks![Context.Position].Content!;

            var input = SwitchTypeOfAnswer(ct.TypeInput!);



           Tasks![Context.Position].Content!.UserAnswer = input!.Text;

            _UserModulesRepository.ChangeModuleOnUser(Context.UserEmail!, Context.Module.Name!, TypeModule.Test ,Context.Module);

            RedirectOnPosition(Context.Position);
        }

        private void buttonComplete_Click(object? sender, EventArgs e)
        {
            var counter = 0;
            foreach (var task in Tasks!)
            {
                if (task.Content!.UserAnswer == task.Content.CorrectAnswer) counter++;
            }

            if (Tasks![Context.Position].TestModel is not null)
            {
                _UserModulesRepository.DeleteOnUser(new ModuleInfoRequest() { Name = Context.Module.Name!, TypeModule = (TypeModule)Context.Module.Type }, Context.UserEmail);
                Exit(counter);
            }

            if (Context.Module.Type is TypeModule.Theoretical)
            {
                //if (!_TherModuleRedFlag)
                //{
                //    _UserModulesRepository.CloseModuleTheoretical(_Email, (_ModuleBase as TheoreticalModule)!);
                //}

                RedirectToAccount();
                
            }
        }
        private void buttonExit_Click(object? sender, EventArgs e)
        {
            var dialogRes = MessageBox.Show("Вы точно уверены что хотите завершить?", "Message", MessageBoxButtons.YesNo);
            if (dialogRes == DialogResult.Yes)
            {
                _UserModulesRepository.DeleteOnUser(new ModuleInfoRequest() { Name = Context.Module.Name!, TypeModule = (TypeModule)Context.Module.Type }, Context.UserEmail);
                RedirectToAccount();
            }
            else return;
        }
        private void Exit(int res)
        {
            var completePanel = new CompletePanel(res, Context.UserEmail!, this.WorkPanel, _mainUserForm, _context, _yandexClient);

            CompletePanelBlock = completePanel.WorkPanel!;

            InnerPanel.Visible = false;
            PlaneForAnswer.Visible = false;
            PlaneForQuestion.Visible = false;


            CompletePanelBlock.Visible = true;
        }
        private Control[] VisibleFile(IList<BinaryData> datas, Label label)
        {
            var controls = new List<Control>();
            using (var httpclient = new HttpClient())
            {
                foreach (var data in datas)
                {
                    // 1
                    var task = httpclient.GetStreamAsync(data.LinkOnData);

                    task.Wait();

                    var model = task.Result;

                    if (data.TypeFile is TypeFile.Image) controls.Add(GetImage(model, label));
                    
                    if(data.TypeFile is TypeFile.VideoMp4) controls.Add(GetVideo(data.LinkOnData!));
                }
            }
            return controls.ToArray();
        }
        private PictureBox GetImage(Stream model, Label label) => new PictureBox()
        {
            Image = Image.FromStream(model),

            SizeMode = PictureBoxSizeMode.StretchImage,

            Size = new Size(InnerPanel.Width - 60, InnerPanel.Width / 2),

            Location = new Point(PlaneForQuestion.Location.X, PlaneForQuestion.Location.Y + label.Size.Height),

            BackColor = Color.DarkSlateGray,
        };
        private AxWindowsMediaPlayer GetVideo(string url) => new AxWindowsMediaPlayer
        {
            URL = url,
        };
        private InputMethods GetConfigForInput(Control control)
        {
            return new InputMethods(new InputConfigModel()
            {
                Control = control,
                Info = ExtensionsManagers.CreateInfo(Context.Module.Name!, (TypeModule)Context.Module.Type)
            }, _UserModulesRepository);
           
            
        }
        private CheckedListBox GetCheckBox(Content ct)
        {
            var checkbox = new CheckedListBox();

            checkbox.Controls.Add(new CheckBox()
            {
                Text = ct.CorrectAnswer,
            });
            var list = ct!.ConfusingAnswers;

            if (list is null) return null;

            foreach (var cfansw in list)
            {
                checkbox.Controls.Add(new CheckBox() { Text = cfansw.Text });
            }
            _InputCheck = GetConfigForInput(checkbox);
            return checkbox;
        }
        private Panel GetRadio(Content content)
        {
            var panelradio = new Panel()
            {
                AutoScroll = true,
            };
            var list = Tasks![Context.Position].Content!.ConfusingAnswers;

            panelradio.Controls.Add(new RadioButton()
            {
                Text = content!.CorrectAnswer,
                Location = new Point(panelradio.Location.X, panelradio.Location.Y),
                Checked = content.UserAnswer == content!.CorrectAnswer
            });
            if (list is not null)
            {
                int locYCounter = 0;
                foreach (var cfansw in list)
                {
                    panelradio.Controls.Add(new RadioButton()
                    {
                        Location = new Point(panelradio.Location.X, panelradio.Location.Y + locYCounter),
                        Text = cfansw.Text,
                        Checked = content.UserAnswer == cfansw.Text

                    });
                    locYCounter += 30;
                }
            }
            _InputRadio = GetConfigForInput(panelradio);
            return panelradio;
        }
        private TextBox GetTextBox(Content content)
        {
            var textbox = new TextBox()
            {
                Size = new Size(200, 100),
                Multiline = true,
                Text = content.UserAnswer ?? string.Empty
            };
            _InputText = GetConfigForInput(textbox);
            return textbox;
        }
        private void RedirectToAccount()
        {
            var user = _UserRepositry.Get(Context.UserEmail!);

            if (user is null) throw new NullReferenceException(nameof(user));

            var accountpanel = new AccountPanel(user.GetUserWithInfo(), this.WorkPanel, _mainUserForm, _context, _yandexClient);

            WorkPanel = accountpanel.WorkPanel;
        }
    }
}
