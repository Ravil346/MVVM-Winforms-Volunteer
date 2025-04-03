using App.ViewModel.WorkForm;
using AutoMapper;
using BuisnessLogic;
using BuisnessLogic.Extensions;
using BuisnessLogic.Models.Request;
using Data;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UserPanels
{
    public class DataBasePanel 
    {
        public Panel WorkPanel { get; set; }    
        
        private RadioButton UserCheck => new RadioButton()
        {
            Checked = true,
            Size = new Size(20, 20),
            Text = "Пользователи",
            Font = FormConstStorage.BaseFont,
            AutoSize = true,
            Location = new Point(0, 0)
        };
        private RadioButton TestModuleCheck => new RadioButton()
        {
            Size = new Size(20, 20),
            Text = "Тесты",
            AutoSize = true,
            Font = FormConstStorage.BaseFont,
            Location = new Point(120, 0)
        };
        private RadioButton TherModuleCheck => new RadioButton()
        {
            Size = new Size(20, 20),
            Text = "Теория",
            Font = FormConstStorage.BaseFont,
            AutoSize = true
            ,
            Location = new Point(240, 0)
        };
        private RadioButton IncidentCheck => new RadioButton()
        {
            Size = new Size(20, 20),
            Text = "Мероприятия",
            Font = FormConstStorage.BaseFont,
            AutoSize = true,
            Location = new Point(360, 0)
        };

        public DataGridView DataGridViewUsers {  get; set; }

        public DataGridView DataGridViewModules {  get; set; }
        

        public DataGridView DataGridViewIncidents {  get; set; }

        private List<Button> Buttons = new List<Button>();

        private AppDbContext _Database;

        private UnitOfWork _Repositories;

        private Panel PanelForDataGrid;
        public DataBasePanel(Panel basepanel)
        {
            WorkPanel = basepanel;
            WorkPanel.AutoScroll = true;
            WorkPanel.AutoSize = true;
            var unitOfWork = UnitOfWorkInit.GetUnitOfWork();
            _Repositories = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _Database = unitOfWork.DataBase ?? throw new ArgumentNullException(nameof(unitOfWork.DataBase));
            _Database.Incidents.Load();

            _Database.Users.Load();

            _Database.Module.Load();
            PanelForDataGrid = new Panel()
            {
                BackColor = FormConstStorage.BaseColorForBackDataGrid,
                Size = new Size(200, 200),
                AutoSize = true,
                Location = new Point(WorkPanel.Location.X + WorkPanel.Size.Width, 0)
            };
            var grids = InitGrids(new Point(WorkPanel.Location.X, WorkPanel.Location.Y));
            foreach (var gr in grids) PanelForDataGrid.Controls.Add(gr);

            var buttons = CreateButtons(grids.Last().Location);
            foreach (var bt in buttons)
            {
                WorkPanel.Controls.Add(bt);
            }
            InitCheckBoxes(new Point(0,0));

            WorkPanel.Controls.Add(TestModuleCheck);
            WorkPanel.Controls.Add(TherModuleCheck);
            WorkPanel.Controls.Add(UserCheck);
            WorkPanel.Controls.Add(IncidentCheck);

            WorkPanel.Controls.Add(PanelForDataGrid);

        }
        private void InitCheckBoxes(Point BaseLocation)
        {
            UserCheck.CheckedChanged += UserCheck_CheckedChanged;

            TestModuleCheck.CheckedChanged += ModuleCheck_CheckedChanged;

            TherModuleCheck.CheckedChanged += ModuleCheck_CheckedChanged;

            IncidentCheck.CheckedChanged += IncidentCheck_CheckedChanged;
        }

     

        private IList<DataGridView> InitGrids(Point baselocation)
        {
            //var size = new Size(440,110);
            var size = new Size(200, 200);


            DataGridViewUsers = new DataGridView()
            {
                Location = baselocation,
                Size = size,
                AutoSize = true,
                AutoGenerateColumns = true,
                Name = " DataGridViewUsers",
                AllowUserToAddRows = false,
                BackgroundColor = Color.Black,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                CellBorderStyle = DataGridViewCellBorderStyle.Single,

            };
            DataGridViewModules = new DataGridView()
            {
                Location = new Point(0, DataGridViewUsers.Size.Height + DataGridViewUsers.Location.Y),
                Size = size,
                AutoSize = true,
                AutoGenerateColumns = true,
                Name = "DataGridViewModules",
                AllowUserToAddRows = false,
                BackgroundColor = Color.Black,
            };
            DataGridViewIncidents = new DataGridView()
            {
                Location = new Point(0, DataGridViewModules.Size.Height + DataGridViewModules.Location.Y),
                Size = size,
                AutoSize = true,
                AutoGenerateColumns = true,
                Name = "DataGridViewIncidents",
                AllowUserToAddRows = false,
                BackgroundColor = Color.Black,
            };

            

            DataGridViewUsers.DataSource = _Database.Users.Local.ToBindingList();

            DataGridViewModules.DataSource = _Database.Module.Local.ToBindingList();

            DataGridViewIncidents.DataSource = _Database.Incidents.Local.ToBindingList();

            DataGridViewUsers.Columns["Id"].ReadOnly = true;

            DataGridViewIncidents.Columns["Id"].ReadOnly = true;

            DataGridViewModules.Columns["Id"].ReadOnly = true;

            return [DataGridViewIncidents, DataGridViewUsers, DataGridViewModules];
        }
       
        private IList<Button> CreateButtons(Point BaseLocation)
        {
            var size = new Size(133, 30);
            var listName = new List<string>()
            {
                "Добавить",
                "Удалить",
                "Сохранить"
            };
            var listActions = new List<EventHandler>()
            {
                Add,
                Delete,
                Save
            };
            Buttons = new List<Button>();
            for(int i = 0; i < listName.Count; i++)
            {
                var button = new Button()
                {
                    Size = size,
                    Text = listName[i],
                    AutoSize = true,
                    Location = new Point(i == 0 ? BaseLocation.X : Buttons[i - 1].Location.X + size.Width, BaseLocation.Y),
                };
                button.Click += listActions[i];
                Buttons.Add(button);
            }
            return Buttons;
        }
        private void IncidentCheck_CheckedChanged(object? sender, EventArgs e)
        {
            ExtensionsManagers.ChangeVisible<DataGridView>([DataGridViewIncidents], [DataGridViewModules, DataGridViewUsers]);
        }

        private void ModuleCheck_CheckedChanged(object? sender, EventArgs e)
        {
            ExtensionsManagers.ChangeVisible<DataGridView>([DataGridViewModules], [DataGridViewIncidents, DataGridViewUsers]);
        }

        private void UserCheck_CheckedChanged(object? sender, EventArgs e)
        {
            ExtensionsManagers.ChangeVisible<DataGridView>([DataGridViewUsers], [DataGridViewModules, DataGridViewIncidents]);
        }

        private void Add(object? sender, EventArgs e)
        {
            Form? form = null;

            if (TestModuleCheck.Checked) form = new AddModuleForm(_Repositories.YandexClient, TypeModule.Test);

            if(TherModuleCheck.Checked) form = new AddModuleForm(_Repositories.YandexClient, TypeModule.Theoretical);

            if (IncidentCheck.Checked) form = new AddIncident();

            form.ShowDialog();

          
        }
        private void Delete(object? sender, EventArgs e)
        {
            if (TestModuleCheck.Checked | TherModuleCheck.Checked)
            {
                _Repositories.Modules.DeleteModule((int)DataGridViewModules.SelectedCells[0].Value);
            }
            if (IncidentCheck.Checked)
            {
                _Repositories.Incidents.DeleteIncident((int)DataGridViewIncidents.SelectedCells[0].Value);
            }
        }
        private  void Save(object? sender, EventArgs e)
        {
        }
        
    }
}
