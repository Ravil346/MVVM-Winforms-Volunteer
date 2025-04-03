using App.ViewModel;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic;
using BuisnessLogic.Extensions;
using BuisnessLogic.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UserPanels
{
    public class CompletePanel
    {
        public Panel WorkPanel { get; set; }    
      
        private UnitOfWork UnitOfWork { get; set; }
        private string _Email {  get; set; }
        private MainUserForm _mainUserForm;
        private MainPanelContext _context;
        private IYandexClient _yandexClient;

        public CompletePanel(int result, string email, Panel basepanel, MainUserForm mainUserForm, MainPanelContext context, IYandexClient yandexClient)
        {
            _mainUserForm = mainUserForm;
            _yandexClient = yandexClient;
            _context = context;

            WorkPanel = basepanel;

            WorkPanel.Controls.Clear();

            _Email = email;

            UnitOfWork = UnitOfWorkInit.GetUnitOfWork();

            var baseLocation = new Point(180, 230);
            var label = new Label()
            {
                Text = "Ваш результат: " + result,
                Font = FormConstStorage.BaseFont,
                Location = new Point(240, 10),
                Size = new Size(60,50),
                AutoSize = true 
            };
            var button = new Button()
            {
                Text = "На станицу аккаунта",
                Location = new Point(baseLocation.X, label.Size.Height + label.Location.Y + 30),
                Font = FormConstStorage.BaseFont,
                ForeColor = FormConstStorage.BaseForeColorForButton,
                BackColor = FormConstStorage.BaseBackColorForButton,
                AutoSize = true
            };
            button.Click += Button_Click;
            WorkPanel!.Controls.AddRange([label, button]);
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            var user = UnitOfWork.Users.Get(_Email);

            if (user is null) return;

            var panel = new AccountPanel(user.GetUserWithInfo(), this.WorkPanel, _mainUserForm, _context, _yandexClient);


        }
    }
}
