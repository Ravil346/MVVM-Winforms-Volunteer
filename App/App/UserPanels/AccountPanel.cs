using System;
using System.Linq;
using System.Windows.Forms;
using App.ViewModel;
using App.ViewModel.WorkForm;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic.Extensions;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Models;

using Data.Interfaces;
using AppContext = BuisnessLogic.Models.AppContext;

namespace App.UserPanels
{
    public class AccountPanel
    {
        public Panel WorkPanel { get; set; }
        private IUserRepositry<UserInfoRequest> UserRepositry { get; set; }
        private MainUserForm _mainUserForm;
        private readonly MainPanelContext _context;
        private IYandexClient _yandexClient;

        private UserInfoRequest _userInfoRequest;

        public AccountPanel(UserInfoRequest user, Panel panel, MainUserForm mainUserForm, MainPanelContext context, IYandexClient yandexClient)
        {
            UserRepositry = UnitOfWorkInit.GetUnitOfWork().Users;
            _userInfoRequest = user;
            WorkPanel = panel;
            WorkPanel.AutoScroll = true;
            WorkPanel.AutoSize = true;
            WorkPanel.Visible = true; // Устанавливаем видимость панели
            WorkPanel.Controls.Clear(); // Очищаем старые элементы
            _mainUserForm = mainUserForm;
            _yandexClient = yandexClient;
            _context = context;

            
            
            // Добавляем заголовок
            var title = new Label()
            {
                Text = "Личные данные",
                Location = new Point(2, 10),
                Font = FormConstStorage.BaseTitleFont,
                AutoSize = true
            };
            WorkPanel.Controls.Add(title);

            // Добавляем planeForPreviewImage
            WorkPanel.Controls.Add(mainUserForm.planeForPreviewImage);
            mainUserForm.planeForPreviewImage.Location = new Point(20, 105); // Фиксированное положение для фото

            
            
            
            // Создаем метки
            var ls = CreateUserinfoLabels();
            if (ls != null && ls.Any())
            {
                WorkPanel.Controls.AddRange(ls);

                // Добавляем кнопку "Изменить"
                WorkPanel.Controls.Add(CreateButtonChange(new Point(
                    WorkPanel.Location.X + 180,
                    ls.Last().Location.Y + ls.Last().Height + 10 // Положение кнопки под последней меткой
                )));
            }
            else
            {
                // Если меток нет, добавляем кнопку внизу панели
                WorkPanel.Controls.Add(CreateButtonChange(new Point(
                    WorkPanel.Location.X,
                    100 // Фиксированное положение
                )));
            }
        }

        private Button CreateButtonChange(Point buttonLocation)
        {
            var button = new Button()
            {
                Size = new Size(200, 50), // Фиксированный размер
                BackColor = Color.LightGray, //
                Font = new Font("Segoe UI", 11, FontStyle.Bold), // Жирный шрифт
                Location = buttonLocation,
                Text = "Изменить",
                AutoSize = false // Отключаем автоматическое изменение размера
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
                _mainUserForm.RefreshProfileData(); // Обновляем данные профиля
        }

       private Label[]? CreateUserinfoLabels()
       {
           const int locationX = 180; // Сдвигаем данные правее фото
           const int step = 30;
       
           var user = UserRepositry.Get(_userInfoRequest.Email!);
       
           if (user is null) return null;
       
           var info = user.GetUserWithInfo();
       
           var rightUser = info.GetType().GetProperties()
               .Where(x => x.Name != nameof(info.Id) &&
                           x.Name != nameof(info.Salt) &&
                           x.Name != nameof(info.PasswordHash) &&
                           x.Name != nameof(info.IsAdmin));
       
           int counterLocationY = 100; // Начинаем ниже заголовка и фото
       
           return rightUser.Select(x =>
           {
               // Создаем заголовок (жирный шрифт)
               var labelTitle = new Label()
               {
                   Name = $"Title_{x.Name}",
                   Text = $"{x.Name}:",
                   Font = new Font("Segoe UI", 11, FontStyle.Bold), // Жирный шрифт
                   Location = new Point(locationX, counterLocationY),
                   AutoSize = true
               };
       
               // Создаем текст (обычный шрифт)
               var labelText = new Label()
               {
                   Name = $"Value_{x.Name}",
                   Text = $"{x.GetValue(info) ?? string.Empty}".CutString(20),
                   Font = new Font("Segoe UI", 11, FontStyle.Regular), // Обычный шрифт
                   Location = new Point(locationX + 180, counterLocationY), // Правее заголовка
                   AutoSize = true
               };
       
               counterLocationY += step;
               return new[] { labelTitle, labelText }; // Возвращаем массив из двух меток
           }).SelectMany(labels => labels).ToArray();
       }
    }
}