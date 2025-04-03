using App.UserPanels;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic.Extensions;
using BuisnessLogic.Models.Request;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.ViewModel
{
    public partial class MainUserForm : Form
    {
        private MainPanelContext Context {  get; set; }
        private IUserRepositry<UserInfoRequest> _UserRepositry;
        private IYandexClient _YandexClient;
        private MainPanelContext _MainPanelContext;
        private Panel PanelEvents { get; set; } = new Panel()
        {
            Size = new Size(625, 445),
            AutoSize = true,
        };
       
        private Panel PanelEducation {  get; set; } = new Panel()
        {
            Size = new Size(625, 445),
            AutoSize = true,
        };
        private Panel PanelProfile { get; set; } = new Panel()
        {
            Size = new Size(625, 445),
            AutoSize = true,
        };

        internal Panel planeForPreviewImage = new Panel()
        {
            Size = new Size(100, 100), // Размер панели
            Location = new Point(20, 20), // Положение на форме
            BorderStyle = BorderStyle.FixedSingle, // Добавляем рамку для наглядности
            BackColor = Color.White // Фон панели
        };
        public MainUserForm(MainPanelContext context)
        {
            InitializeComponent();

            var unitOfWork = UnitOfWorkInit.GetUnitOfWork();

            _UserRepositry = unitOfWork.Users;

            _YandexClient = unitOfWork.YandexClient;

            this.Context = context;


            PanelEducation.Visible = false;
            PanelEvents.Visible = false;
            PanelProfile.Visible = false;

            // Добавляем planeForPreviewImage в PanelProfile
            //PanelProfile.Controls.Add(planeForPreviewImage);

            var panelA = new AccountPanel(Context.User!.GetUserWithInfo(), this.PanelProfile, this, this.Context, _YandexClient);

            PanelProfile = panelA.WorkPanel;

            var panelB = new AllModulePanel(Context.User!.Email!,this.PanelEducation, this, _MainPanelContext, _YandexClient);

            PanelEducation = panelB.WorkPanel;

            var panelC = new IncidentsPanel(Context.User!.Email!, this.PanelEvents);

            PanelEvents = panelC.WorkPanel;

            

            WorkPanel.Controls.AddRange([ PanelEducation, PanelEvents, PanelProfile]);

            planeForPreviewImage.Paint += panelForImage_Paint;

        }
        private void MainUserForm_Load(object sender, EventArgs e)
        {
            buttonDataBase.Visible = Context.User!.IsAdmin is not null ? (bool)Context.User.IsAdmin : false;
        }
        private void buttonProfile_Click(object sender, EventArgs e)
        {
            ExtensionsManagers.ChangeVisible<Panel>([PanelProfile], [PanelEvents, PanelEducation]);
        }

        private void buttonEducation_Click(object sender, EventArgs e)
        {
            ExtensionsManagers.ChangeVisible<Panel>([PanelEducation], [ PanelEvents, PanelProfile]);
        }

        private void buttonIncidents_Click(object sender, EventArgs e)
        {
            ExtensionsManagers.ChangeVisible<Panel>([PanelEvents], [PanelEducation, PanelProfile]);
        }

        private void buttonDataBase_Click(object sender, EventArgs e)
        {
            var form = new DataBaseForm(Context.User.Email);
            Hide();
            form.ShowDialog();
            Close();
        }

        private async void panelForImage_Paint(object sender, PaintEventArgs e)
        {
            planeForPreviewImage.Controls.Clear();
            if(Context.User!.Photo is not null)
            {
                try
                {
                    using (var httpclient = new HttpClient())
                    {
                        var response = await httpclient.GetStreamAsync(Context.User!.Photo.LinkOnData);
                        panelForImage.Controls.Add(new PictureBox()
                        {
                            Image = Image.FromStream(response),

                            SizeMode = PictureBoxSizeMode.StretchImage,

                            Size = new Size(64, 64),

                            BackColor = Color.DarkSlateGray,
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");

                }
            }
            else
            {
                var button = new Button()
                {
                    Size = new Size(64,64),
                    BackColor = FormConstStorage.BaseBackColorForButton,
                    Font = FormConstStorage.BaseFont,
                    Text = "Загрузить фото"
                };
                button.Click += Button_Click;
                planeForPreviewImage.Controls.Add(button);
            }
        }

        public void RefreshProfileData()
        {
            // Получаем актуальные данные пользователя из контекста или репозитория
            var updatedUser = _UserRepositry.Get(Context.User!.Email);

            if (updatedUser is null) throw new NullReferenceException(nameof(updatedUser));

            // Обновляем данные в Context
            Context.User = updatedUser;

            // Пересоздаем панель Profile с новыми данными
            PanelProfile.Controls.Clear(); // Очищаем старые элементы
            var panelA = new AccountPanel(updatedUser.GetUserWithInfo(), this.PanelProfile, this, _MainPanelContext, _YandexClient);
            PanelProfile = panelA.WorkPanel;

            // Обновляем интерфейс
            WorkPanel.Controls.Remove(PanelProfile); // Удаляем старую панель
            WorkPanel.Controls.Add(PanelProfile);   // Добавляем обновленную панель

            // Обновляем предварительный просмотр фото
            planeForPreviewImage.Invalidate();
        }

        private async void UpdatePreviewImage()
        {
            if (Context.User?.Photo is not null)
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetStreamAsync(Context.User.Photo.LinkOnData);
                    planeForPreviewImage.Controls.Clear(); // Очистка старых элементов
                    planeForPreviewImage.Controls.Add(new PictureBox()
                    {
                        Image = Image.FromStream(response),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(64, 64),
                        BackColor = Color.DarkSlateGray,
                    });
                }
            }
        }

        private async void Button_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"
            };
            var res = openFileDialog.ShowDialog();
            if (res == DialogResult.Cancel) return;
            await LoadFile(openFileDialog.FileName);
           
        }
        private async Task LoadFile(string path)
        {
            using (var file = File.OpenRead(path))
            {
                var fileinfo = ExtensionsManagers.ConfiguratePath(file.Name);
                await _UserRepositry.SetImageProfile(_YandexClient, new FileInfoRequest()
                {
                    File = file,
                    Name = fileinfo.name,
                    Path = fileinfo.path
                    
                }, Context.User!.Email!);
            }
               
        }
       
    }
}
