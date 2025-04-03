using System.Xml;

namespace App.ViewModel.WorkForm
{
    partial class ChangeUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            plane = new Panel();
            buttonUploadPhoto = new Button();
            buttonSave = new Button();
            textBoxEmail = new TextBox();
            textBoxNumber = new TextBox();
            textBoxInstiut = new TextBox();
            textBoxScoutGroup = new TextBox();
            textBoxPatronymic = new TextBox();
            textBoxSurname = new TextBox();
            textBoxName = new TextBox();
            Email = new Label();
            label2 = new Label();
            Institution = new Label();
            ScoutGroup = new Label();
            Patronymic = new Label();
            Surname = new Label();
            nameLabel = new Label();
            title = new Label();
            pictureBox1 = new PictureBox();
            planeForPreviewImage = new Panel();
            plane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // plane
            // 
            plane.BackColor = Color.Lavender;
            plane.BackgroundImage = Properties.Resources.фон;
            plane.BackgroundImageLayout = ImageLayout.Stretch;
            plane.Controls.Add(planeForPreviewImage);
            plane.Controls.Add(buttonUploadPhoto);
            plane.Controls.Add(buttonSave);
            plane.Controls.Add(textBoxEmail);
            plane.Controls.Add(textBoxNumber);
            plane.Controls.Add(textBoxInstiut);
            plane.Controls.Add(textBoxScoutGroup);
            plane.Controls.Add(textBoxPatronymic);
            plane.Controls.Add(textBoxSurname);
            plane.Controls.Add(textBoxName);
            plane.Controls.Add(Email);
            plane.Controls.Add(label2);
            plane.Controls.Add(Institution);
            plane.Controls.Add(ScoutGroup);
            plane.Controls.Add(Patronymic);
            plane.Controls.Add(Surname);
            plane.Controls.Add(nameLabel);
            plane.Controls.Add(title);
            plane.Controls.Add(pictureBox1);
            plane.Location = new Point(0, 1);
            plane.Margin = new Padding(3, 4, 3, 4);
            plane.Name = "plane";
            plane.Size = new Size(876, 502);
            plane.TabIndex = 0;
            // 
            // buttonUploadPhoto
            // 
            buttonUploadPhoto.Location = new Point(458, 438);
            buttonUploadPhoto.Name = "buttonUploadPhoto";
            buttonUploadPhoto.Size = new Size(110, 44);
            buttonUploadPhoto.TabIndex = 16;
            buttonUploadPhoto.Text = "Фото";
            buttonUploadPhoto.Click += buttonUploadPhoto_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(140, 438);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(110, 44);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Обновить";
            buttonSave.Click += buttonSave_Click_1;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(319, 378);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(100, 27);
            textBoxEmail.TabIndex = 1;
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(319, 335);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(100, 27);
            textBoxNumber.TabIndex = 2;
            // 
            // textBoxInstiut
            // 
            textBoxInstiut.Location = new Point(319, 290);
            textBoxInstiut.Name = "textBoxInstiut";
            textBoxInstiut.Size = new Size(100, 27);
            textBoxInstiut.TabIndex = 3;
            // 
            // textBoxScoutGroup
            // 
            textBoxScoutGroup.Location = new Point(319, 247);
            textBoxScoutGroup.Name = "textBoxScoutGroup";
            textBoxScoutGroup.Size = new Size(100, 27);
            textBoxScoutGroup.TabIndex = 4;
            // 
            // textBoxPatronymic
            // 
            textBoxPatronymic.Location = new Point(319, 202);
            textBoxPatronymic.Name = "textBoxPatronymic";
            textBoxPatronymic.Size = new Size(100, 27);
            textBoxPatronymic.TabIndex = 5;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(319, 160);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(100, 27);
            textBoxSurname.TabIndex = 6;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(319, 118);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 27);
            textBoxName.TabIndex = 7;
            // 
            // Email
            // 
            Email.Location = new Point(140, 382);
            Email.Name = "Email";
            Email.Size = new Size(100, 23);
            Email.TabIndex = 8;
            // 
            // label2
            // 
            label2.Location = new Point(140, 247);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 9;
            // 
            // Institution
            // 
            Institution.Location = new Point(140, 339);
            Institution.Name = "Institution";
            Institution.Size = new Size(100, 23);
            Institution.TabIndex = 10;
            // 
            // ScoutGroup
            // 
            ScoutGroup.Location = new Point(140, 290);
            ScoutGroup.Name = "ScoutGroup";
            ScoutGroup.Size = new Size(100, 23);
            ScoutGroup.TabIndex = 11;
            // 
            // Patronymic
            // 
            Patronymic.Location = new Point(140, 202);
            Patronymic.Name = "Patronymic";
            Patronymic.Size = new Size(100, 23);
            Patronymic.TabIndex = 12;
            // 
            // Surname
            // 
            Surname.Location = new Point(140, 160);
            Surname.Name = "Surname";
            Surname.Size = new Size(100, 23);
            Surname.TabIndex = 13;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.BackColor = Color.White;
            nameLabel.Font = new Font("Georgia", 12F);
            nameLabel.ForeColor = Color.DimGray;
            nameLabel.Location = new Point(183, 121);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(57, 24);
            nameLabel.TabIndex = 11;
            nameLabel.Text = "Имя:";
            // 
            // title
            // 
            title.Location = new Point(49, 33);
            title.Name = "title";
            title.Size = new Size(100, 23);
            title.TabIndex = 14;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(693, 58);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // planeForPreviewImage
            // 
            planeForPreviewImage.Location = new Point(479, 121);
            planeForPreviewImage.Name = "planeForPreviewImage";
            planeForPreviewImage.Size = new Size(230, 292);
            planeForPreviewImage.TabIndex = 17;
            // 
            // ChangeUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 495);
            Controls.Add(plane);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ChangeUser";
            Text = "ChangeUser";
            plane.ResumeLayout(false);
            plane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel plane;
        private Label title;
        private TextBox textBoxEmail;
        private TextBox textBoxNumber;
        private TextBox textBoxInstiut;
        private TextBox textBoxScoutGroup;
        private TextBox textBoxPatronymic;
        private TextBox textBoxSurname;
        private TextBox textBoxName;
        private Label Email;
        private Label label2;
        private Label Institution;
        private Label ScoutGroup;
        private Label Patronymic;
        private Label Surname;
        private Label nameLabel; // Переименованное поле
        private Button buttonSave;
        private PictureBox pictureBox1;
        private Button buttonUploadPhoto;
        private Panel planeForPreviewImage;
    }
}