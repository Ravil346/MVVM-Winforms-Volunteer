using App.ViewModel.WorkForm;
using BuisnesLogic.Service.Clients;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic;
using BuisnessLogic.Extensions;
using BuisnessLogic.Models;
using BuisnessLogic.Models.Request;
using Data;
using Data.Interfaces;
using Data.Interfaces.UserInterfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.ViewModel
{
    public partial class DataBaseForm : Form
    {
        private AppDbContext _Database;

        private UnitOfWork _Repositories;
        private IYandexClient _YandexClient { get; set; }
        private string _Email { get; set; }
        private IGetUser userRepositry { get; set; }
        public DataBaseForm(string email, Point? location = null)
        {
            InitializeComponent();

            _Email = email;

            _Repositories = UnitOfWorkInit.GetUnitOfWork();

            _Database = _Repositories!.DataBase;

            userRepositry = _Repositories.Users;

            _Database.Module.Load();
            _Database.Incidents.Load();
            _Database.Users.Load();
            dataGridViewModule.DataSource = _Database.Module.Local.ToBindingList();

            dataGridViewEvents.DataSource = _Database.Incidents.Local.ToBindingList();

            dataGridUser.DataSource = _Database.Users.Local.ToBindingList();
            dataGridViewEvents.Columns["Id"].ReadOnly = true;
            dataGridViewModule.Columns["Id"].ReadOnly = true;
            dataGridUser.Columns["Id"].ReadOnly = true;
            this.Location = location ?? new Point(0, 0);
        }

        private void DataBaseForm_Load(object sender, EventArgs e)
        {
            radioButtonTestActive.Checked = true;
            radioButtonTheoreticalActive.Checked = false;
            radioButtonUser.Checked = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            buttonDelete.Enabled = false;
            Add();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = false;
            Delete();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            var user = userRepositry.Get(_Email);
            if (user is null) return;
            var form = new MainUserForm(new MainPanelContext()
            {
                User = user
            });
            Hide();
            form.ShowDialog();
            Close();
        }

        private void Add()
        {
            Form? form = null;

            if (radioButtonTestActive.Checked) form = new AddModuleForm(_Repositories.YandexClient, TypeModule.Test);

            if (radioButtonTheoreticalActive.Checked) form = new AddModuleForm(_Repositories.YandexClient, TypeModule.Theoretical);

            if (radioButtonEvents.Checked) form = new AddIncident();

            form.ShowDialog();


        }
        private void Delete()
        {
            if (radioButtonTestActive.Checked | radioButtonTheoreticalActive.Checked)
            {
                _Repositories.Modules.DeleteModule((int)dataGridViewModule.SelectedCells[0].Value);
            }
            if (radioButtonEvents.Checked)
            {
                _Repositories.Incidents.DeleteIncident((int)dataGridViewEvents.SelectedCells[0].Value);
            }
        }

        private void radioButtonTestActive_CheckedChanged(object sender, EventArgs e)
        {
            ExtensionsManagers.ChangeVisible<DataGridView>([dataGridViewModule], [dataGridViewEvents, dataGridUser]);
        }

        private void radioButtonTheoreticalActive_CheckedChanged(object sender, EventArgs e)
        {
            ExtensionsManagers.ChangeVisible<DataGridView>([dataGridViewModule], [dataGridViewEvents, dataGridUser]);
        }

        private void radioButtonUser_CheckedChanged(object sender, EventArgs e)
        {
            ExtensionsManagers.ChangeVisible<DataGridView>([dataGridUser], [dataGridViewModule, dataGridViewEvents]);
        }

        private void radioButtonEvents_CheckedChanged(object sender, EventArgs e)
        {
            ExtensionsManagers.ChangeVisible<DataGridView>([dataGridViewEvents], [dataGridViewModule, dataGridUser]);
        }

        private void dataGridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
