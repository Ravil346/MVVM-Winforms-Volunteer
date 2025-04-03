using App.ViewModel.WorkForm;
using BuisnessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.ViewModel
{
    public partial class MainAuthForm : Form
    {
        public MainAuthForm()
        {
            InitializeComponent();
        }

        private void MainAuthForm_Load(object sender, EventArgs e)
        {
            plane.BackColor = FormConstStorage.PlanesBackColor;
            HeaderText.ForeColor = FormConstStorage.BaseTextColor;
            buttonLogin.ForeColor = FormConstStorage.BaseForeColorForButton;
            buttonLogin.BackColor = FormConstStorage.BaseBackColorForButton;
            buttonRegistration.BackColor = FormConstStorage.BaseBackColorForButton;
            buttonRegistration.ForeColor = FormConstStorage.BaseForeColorForButton;

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var form = new LoginForm();
            Hide();
            form.ShowDialog();
            Close();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            var form = new UserRegistration();
            Hide();
            form.ShowDialog();
            Close();
        }
    }
}
