using App.ViewModel;
using App.ViewModel.WorkForm;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic.Extensions;
using BuisnessLogic.Models.Request;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UserPanels
{
    public class AccountPanel
    {
        public Panel WorkPanel { get; set; }    
        private IUserRepositry<UserInfoRequest> UserRepositry { get; set; }
        private MainUserForm _mainUserForm;
        private MainPanelContext _context;
        private IYandexClient _yandexClient;

        private UserInfoRequest _userInfoRequest;
        public AccountPanel(UserInfoRequest user, Panel panel, MainUserForm mainUserForm, MainPanelContext context, IYandexClient yandexClient)
        {
            UserRepositry = UnitOfWorkInit.GetUnitOfWork().Users;
            _userInfoRequest = user;
            WorkPanel = panel;
            WorkPanel.AutoScroll = true;
            WorkPanel.AutoSize = true;
            WorkPanel.Controls.Clear();
            _mainUserForm = mainUserForm;
            _yandexClient = yandexClient;
            _context = context;

            var locationTitle = new Point(2, 10);
            var title = new Label()
            {
                Text = "Личные данные",
                Location = locationTitle,
                Font = FormConstStorage.BaseTitleFont,
                AutoSize = true
            };
            WorkPanel.Controls.Add(title);

            var ls = CreateUserinfoLabels();

            WorkPanel.Controls.AddRange(ls);

            WorkPanel.Controls.Add(CreateButtonChange(new Point(WorkPanel.Location.X ,ls.Last().Size.Height + ls.Last().Location.Y)));
           
        }

        private Button CreateButtonChange(Point buttonLocation)
        {
            Size buttonSize = new Size(120, 30);
            var button = new Button()
            {
                Size = buttonSize,
                BackColor = FormConstStorage.BaseBackColorForButton,
                Font = FormConstStorage.BaseFont,
                Location = buttonLocation,
                Text = "Изменить",
                AutoSize = true
            };
            button.Click += ButtonChange_Click;
            return button;  
        }

        private void ButtonChange_Click(object? sender, EventArgs e)
        {
            var form = new ChangeUser(_userInfoRequest.Email!, _context, _yandexClient);
            _mainUserForm.Hide();
            var dialogRes = form.ShowDialog();
            _mainUserForm.Show();

            if (dialogRes == DialogResult.OK)
                _mainUserForm.RefreshProfileData(); // Обновляем данные профиля;

        }
        private Label[]? CreateUserinfoLabels()
        {
            const int locationX = 140;
            const int step = 30;

            var user = UserRepositry.Get(_userInfoRequest.Email!);

            if (user is null) return null;

            var info = user.GetUserWithInfo();

            var rightUser = info.GetType().GetProperties()
                .Where(x => x.Name != nameof(info.Id) &
                x.Name != nameof(info.Salt) &
                x.Name != nameof(info.PasswordHash) &
                x.Name != nameof(info.IsAdmin) &
                x.Name != nameof(info.Id));
            int counterLocationY = 50;
            return rightUser.Select(x => 
            {

                var label = new Label()
                {
                    Name = x.Name,
                    Text = (x.Name + ":" + x.GetValue(info) ?? string.Empty).ToString().CutString(20),
                    Font = FormConstStorage.BaseFont,
                    Location = new Point(locationX, counterLocationY),
                    AutoSize = true
                };
                counterLocationY += step;
                return label;
            }).ToArray();
        }
    }
}
