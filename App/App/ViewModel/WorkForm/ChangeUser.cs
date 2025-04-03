using BuisnesLogic.ServicesInterface;
using BuisnessLogic.Extensions;
using BuisnessLogic.Models.Request;
using Data.Interfaces;
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
    public partial class ChangeUser : Form
    {
        private const string ChangeUserConstant = "ChangeUser";
        private IUserRepositry<UserInfoRequest> _userRepository;
        private FileInfoRequest? _fileInfoRequest;
        private string _EmailOldUser;
        private protected MainPanelContext _context;
        private protected IYandexClient _yandexClient;


        public ChangeUser(string emailOlduser, MainPanelContext context, IYandexClient yandexClient)
        {
            InitializeComponent();

            var unitOfWork = UnitOfWorkInit.GetUnitOfWork();

            _userRepository = unitOfWork.Users;

            _EmailOldUser = emailOlduser;

            _context = context;
            _yandexClient = yandexClient;

            //Controls.Add(buttonUploadPhoto);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;

                var newUser = new UserInfoRequest()
                {
                    Name = textBoxName.Text,
                    Surname = textBoxSurname.Text,
                    Patronymic = textBoxPatronymic.Text,
                    ScoutGroup = textBoxScoutGroup.Text,
                    Email = textBoxEmail.Text,
                    PhoneNumber = textBoxNumber.Text,
                    Institute = textBoxInstiut.Text
                };
                var olduser = _userRepository.Get(_EmailOldUser);

                if (olduser is null) throw new NullReferenceException(nameof(olduser));

                _userRepository.Update(olduser.Id, newUser);

                if (olduser is null)
                {
                    MessageBox.Show("Пользователь не найден.");
                    return;
                }

                _userRepository.Update(olduser.Id, newUser);

                MessageBox.Show("Данные успешно обновлены.");
                // Закрываем форму с результатом OK
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private async void buttonUploadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"
            };
            var res = openFileDialog.ShowDialog();
            if (res == DialogResult.Cancel) return;
            try
            {
                await using (var file = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    var fileinfo = ExtensionsManagers.ConfiguratePath(file.Name);
    
                    planeForPreviewImage.Controls.Add(new PictureBox()
                    {
                        Image = Image.FromStream(file),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(64, 64),
                        BackColor = Color.DarkSlateGray,
                    });

                    await _userRepository.SetImageProfile(_yandexClient, new FileInfoRequest()
                    {
                        File = file,
                        Name = fileinfo.name,
                        Path = fileinfo.path
                    }, _context.User!.Email!);
                }  

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке фото: {ex.Message}");

            }

        }
        private void planeForPreviewImage_Paint(object sender, PaintEventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
    }
}
