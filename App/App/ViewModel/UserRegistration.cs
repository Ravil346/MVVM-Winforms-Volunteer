using AutoMapper;
using BuisnesLogic.Service;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Services;
using Data.interfaces;
using Data.Interfaces;
using System.Text.RegularExpressions;


namespace App.ViewModel.WorkForm
{
    public partial class UserRegistration : Form
    {
        private IUserRepositry<UserInfoRequest> _UserManager { get; set; }

        public UserRegistration(Point? location = null)
        {

            InitializeComponent();

            var unitOfWork = UnitOfWorkInit.GetUnitOfWork();

            _UserManager = unitOfWork.Users;


            this.Location = location ?? new Point(0, 0);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputFIO.Text) |
                string.IsNullOrWhiteSpace(inputEmail.Text) |
                string.IsNullOrWhiteSpace(inputGroups.Text) |
                string.IsNullOrWhiteSpace(inputPassword.Text))
            {
                MessageBox.Show("Ошибка вы не ввели значение");
                return;
            }
            var data = inputFIO.Text.Split(" ");

            using (var passwordManager = new PasswordManager(new PasswordSaltOptions() { Password = inputPassword.Text }))
            {
                var password = passwordManager.Salt(8);

                try
                {
                    var newuser = new UserInfoRequest()
                    {
                        Email = inputEmail.Text,
                        Surname = data[0],
                        Name = data[data.Length is 1 ? 0 : 1],
                        Patronymic = data[data.Length is 1 ? 0 : 1],
                        PasswordHash = password.Hash,
                        Salt = password.Salt,
                        ScoutGroup = inputGroups.Text,
                    };
                    _UserManager.Create(newuser);
                    var accountForm = new MainUserForm(new MainPanelContext()
                    {
                        User = newuser,
                    });
                    Hide();
                    accountForm.ShowDialog();
                    Close();
                }
                catch (Exception ex) when (ex.Message.Contains("user"))
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                catch (Exception ex) when (ex.Message.Contains("This"))
                {
                    MessageBox.Show("Это некотректный email адрес");
                    return;
                }
                var user = _UserManager.Get(inputEmail.Text);
                if (user is not null)
                {
                    MessageBox.Show("Попробуйте зарегистрироваться позже");
                    return;
                }

            }

        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            var form = new MainAuthForm();
            Hide();
            form.ShowDialog();
            Close();
        }
    }
}
