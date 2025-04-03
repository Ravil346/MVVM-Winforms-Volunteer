using BuisnesLogic.Service;
using BuisnessLogic;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Services;
using Data.interfaces;
using Data.Interfaces.UserInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.ViewModel.WorkForm
{
    public partial class LoginForm : Form
    {
        private IGetUser _UserManager { get; set; }
        public LoginForm(Point? location = null)
        {
            InitializeComponent();
            var unitOfWork = UnitOfWorkInit.GetUnitOfWork();
            _UserManager = unitOfWork.Users;
            this.Location = location ?? new Point(0, 0);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputEmail.Text) |
                string.IsNullOrWhiteSpace(inputPassword.Text))
            {
                MessageBox.Show("Ошибка вы не ввели значение");
                return;
            }
            var user = _UserManager.Get(inputEmail.Text);
            if (user is null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }
            using (var passwordManager = new PasswordManager(new PasswordSaltOptions()
            {
                Password = inputPassword.Text,
                Salt = user.Salt!,
                Hash = user.PasswordHash!
            }))
            {
                var res = passwordManager.Compare();
                if (!res)
                {
                    MessageBox.Show("Неверный пароль");
                    return;
                }
            }
            MainUserForm form = new MainUserForm(new MainPanelContext()
            {
                User = user,
            });
            Hide();
            form.ShowDialog();
            Close();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            var form = new MainAuthForm();
            Hide();
            form.ShowDialog();
            Close();
        }

        private void inputPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
