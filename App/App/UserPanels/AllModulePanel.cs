using App.ViewModel;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic;
using BuisnessLogic.Models;
using BuisnessLogic.Models.Request;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UserPanels
{
    public class AllModulePanel
    {
        public Panel WorkPanel { get; set; }
        private MainPanelContext _mainPanelContext;
        private IYandexClient _yandexClient;
        
        private Label Title => new Label()
        {
            Font = FormConstStorage.BaseTitleFont,

            Text = "Обучающий курс",

            AutoSize = true,
        };
        private Panel InnerPanel { get; set; }
        private string _Email;
        private MainUserForm _mainUserForm;
        private UnitOfWork UnitOfWork {  get; set; }
        public AllModulePanel(string email, Panel basepanel, MainUserForm mainUserForm, MainPanelContext mainPanelContext, IYandexClient yandexClient)
        {
            _mainPanelContext = mainPanelContext;
            _yandexClient = yandexClient;
            _mainUserForm = mainUserForm;
            WorkPanel = basepanel;
            WorkPanel.AutoSize = false;
            WorkPanel.AutoScroll = true;
            Title.Location = new Point(0, 0);

            InnerPanel = new Panel()
            {
                Location = new Point(Title.Location.X, Title.Location.Y + Title.Size.Height),

                MaximumSize = new Size(WorkPanel.Width - 35, 0),

                Size = new Size(200, 200),

                AutoScroll = true,

                AutoSize = true,
            };
            var unitOfWork = UnitOfWorkInit.GetUnitOfWork();

            var allTheoretical = unitOfWork.Modules.GetModules(x => x.Type is Data.TypeModule.Theoretical).ToList();

            var allTest = unitOfWork.Modules.GetModules(x => x.Type is Data.TypeModule.Test).ToList();

            UnitOfWork = unitOfWork;

            _Email = email;

            var baseY = Title.Location.Y + Title.Size.Width;

            List<Button> TestButtons = new List<Button>();
            List<Button> TheoreticalButtons = new List<Button>();
            foreach(var module in allTest)
            {
                var button = CreateButtonOnModule(module, new Point(Title.Location.X, baseY));

                InnerPanel.Controls.Add(button);

                TestButtons.Add(button);

                baseY += 100; 
            }
            if(allTest is not null && allTest.Count > 0) baseY = TestButtons.Last().Location.Y + 20;
            foreach (var module in allTheoretical)
            {
                var button = CreateButtonOnModule(module, new Point(Title.Location.X, baseY));

                InnerPanel.Controls.Add(button);

                baseY += button.Size.Height + button.Location.Y + 30;
            }
            WorkPanel.Controls.Add(Title);

            WorkPanel.Controls.Add(InnerPanel);
        }
        private Button CreateButtonOnModule(Module module, Point baseLoc)
        {
            var button = new Button()
            {
                Font = FormConstStorage.BaseFont,
                Text = module.Name,
                ForeColor = FormConstStorage.BaseForeColorForButton,
                BackColor = FormConstStorage.BaseBackColorForButton,
                Location = baseLoc,
                AutoSize = true,
                MaximumSize = new Size(WorkPanel.Size.Width, 50)
            };
            button.Click += Button_Click;
            return button;
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            var button = sender as Button;

            var module = UnitOfWork.Modules.GetModules(x => x.Name == button!.Text & x.Exists is null).SingleOrDefault();

            if (module is null) return; 


            var taskpanel = new TaskPanel(new TaskPanelContext()
            {
               Module = module,
               Position = 0,
               UserEmail = _Email,
            }, UnitOfWork, this.WorkPanel, _mainUserForm, _mainPanelContext, _yandexClient);

            WorkPanel = taskpanel.WorkPanel;
        }
    }
}
