using BuisnesLogic.ServicesInterface;
using BuisnessLogic.Extensions;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Models;
using Data.Entities;
using Data.Interfaces;
using AppContext = BuisnessLogic.Models.AppContext;

namespace App.ViewModel.WorkForm
{
    public partial class ChangeUser : Form
    {
        private const string ChangeUserConstant = "ChangeUser";
        private IUserRepositry<UserInfoRequest> _userRepository;
        private FileInfoRequest? _fileInfoRequest;
        private string _EmailOldUser;
        private readonly MainPanelContext _context;
        private protected IYandexClient _yandexClient;

        public ChangeUser(string emailOlduser, MainPanelContext context, IYandexClient yandexClient)
        {
            InitializeComponent();

            var unitOfWork = UnitOfWorkInit.GetUnitOfWork();

            _userRepository = unitOfWork.Users;

            _EmailOldUser = emailOlduser;

            _context = AppContext.CurrentContext;
            //_yandexClient = yandexClient;
            _yandexClient = yandexClient;


            // Получаем данные текущего пользователя
            var user = _userRepository.Get(_EmailOldUser);
            if (user is null)
            {
                throw new NullReferenceException(nameof(user));
            }

            // Заполняем текстовые поля
            textBoxName.Text = user.Name ?? string.Empty;
            textBoxSurname.Text = user.Surname ?? string.Empty;
            textBoxPatronymic.Text = user.Patronymic ?? string.Empty;
            textBoxScoutGroup.Text = user.ScoutGroup ?? string.Empty;
            textBoxEmail.Text = user.Email ?? string.Empty;
            textBoxNumber.Text = user.PhoneNumber ?? string.Empty;
            textBoxInstiut.Text = user.Institute ?? string.Empty;

            // Отображаем фото профиля
            if (user.Photo != null)
            {
                try
                {
                    Up(user);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки фото: {ex.Message}");
                }
            }

        }

        private async void Up(User? user)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStreamAsync(user.Photo.LinkOnData);
                planeForPreviewImage.Controls.Clear();
                planeForPreviewImage.Controls.Add(new PictureBox()
                {
                    Image = Image.FromStream(response),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(230, 290),
                    BackColor = Color.DarkSlateGray,
                });
            }
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

                MessageBox.Show("Данные успешно обновлены.");
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
                await using (var file = File.OpenRead(openFileDialog.FileName))
                {
                   
                    var fileinfo = ExtensionsManagers.ConfiguratePath(file.Name);

                    // Очищаем старые элементы
                    planeForPreviewImage.Controls.Clear();
                    
                    // Добавляем новое фото
                    planeForPreviewImage.Controls.Add(new PictureBox()
                    {
                        Image = Image.FromStream(file),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(230, 290),
                        BackColor = Color.DarkSlateGray,
                    });
                   
                    // Сохраняем фото на сервере
                    await _userRepository.SetImageProfile(_yandexClient, new FileInfoRequest()
                    {
                        File = file,
                        Name = fileinfo.name,
                        Path = fileinfo.path
                    }, _context.User.Email);

                    // Обновляем предварительный просмотр фото
                    
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

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plane_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}