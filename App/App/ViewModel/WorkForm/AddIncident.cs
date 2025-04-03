using BuisnesLogic.ServicesInterface;
using BuisnessLogic;
using BuisnessLogic.Extensions;
using BuisnessLogic.Models.Request;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.ViewModel.WorkForm
{
    public partial class AddIncident : Form
    {
        private IEventsRepository<IncidentInfoRequest> _eventsRepository; 

        private FileInfoRequest? _fileInfoRequest;
        private UnitOfWork UnitOfWork;
        public AddIncident()
        {
            InitializeComponent();
            
            UnitOfWork = UnitOfWorkInit.GetUnitOfWork();

            _eventsRepository = UnitOfWork.Incidents;

            buttonSave.Visible = false;
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            ViewFile();
            buttonSave.Visible = true;
        }
        private void ViewFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"
            };
            var res = openFileDialog.ShowDialog();
            if (res == DialogResult.Cancel) return;
            var file = new FileStream($@"{openFileDialog.FileName}", FileMode.Open);
            var fileinfo = ExtensionsManagers.ConfiguratePath(file.Name);
            planeForPreviewImage.Controls.Add(new PictureBox()
            {
                Image = Image.FromStream(file),

                SizeMode = PictureBoxSizeMode.StretchImage,

                Size = new Size(64, 64),

                BackColor = Color.DarkSlateGray,
            });
            _fileInfoRequest = new FileInfoRequest()
            {
                File = file,
                Name = fileinfo.name,
                Path = fileinfo.path,
            };
        }
        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textName.Text)) throw new NullReferenceException();

            await _eventsRepository.AddIncident(ExtensionsManagers.CreateIncident(_fileInfoRequest!, textName.Text));

            Hide();
            Close();

        }
    }
}
