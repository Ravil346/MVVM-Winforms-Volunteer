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
            plane = new System.Windows.Forms.Panel();
            planeForPreviewImage = new System.Windows.Forms.Panel();
            buttonUploadPhoto = new System.Windows.Forms.Button();
            buttonSave = new System.Windows.Forms.Button();
            textBoxEmail = new System.Windows.Forms.TextBox();
            textBoxNumber = new System.Windows.Forms.TextBox();
            textBoxInstiut = new System.Windows.Forms.TextBox();
            textBoxScoutGroup = new System.Windows.Forms.TextBox();
            textBoxPatronymic = new System.Windows.Forms.TextBox();
            textBoxSurname = new System.Windows.Forms.TextBox();
            textBoxName = new System.Windows.Forms.TextBox();
            Email = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            Institution = new System.Windows.Forms.Label();
            ScoutGroup = new System.Windows.Forms.Label();
            Patronymic = new System.Windows.Forms.Label();
            Surname = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            title = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            plane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // plane
            // 
            plane.BackColor = System.Drawing.Color.Lavender;
            plane.BackgroundImage = global::App.Properties.Resources.фон;
            plane.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            plane.Location = new System.Drawing.Point(0, 1);
            plane.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            plane.Name = "plane";
            plane.Size = new System.Drawing.Size(876, 502);
            plane.TabIndex = 0;
            // 
            // planeForPreviewImage
            // 
            planeForPreviewImage.Location = new System.Drawing.Point(479, 121);
            planeForPreviewImage.Name = "planeForPreviewImage";
            planeForPreviewImage.Size = new System.Drawing.Size(230, 292);
            planeForPreviewImage.TabIndex = 17;
            planeForPreviewImage.Paint += planeForPreviewImage_Paint;
            // 
            // buttonUploadPhoto
            // 
            buttonUploadPhoto.Location = new System.Drawing.Point(458, 438);
            buttonUploadPhoto.Name = "buttonUploadPhoto";
            buttonUploadPhoto.Size = new System.Drawing.Size(110, 44);
            buttonUploadPhoto.TabIndex = 16;
            buttonUploadPhoto.Text = "Фото";
            buttonUploadPhoto.Click += buttonUploadPhoto_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new System.Drawing.Point(140, 438);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(110, 44);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Обновить";
            buttonSave.Click += buttonSave_Click_1;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new System.Drawing.Point(319, 378);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new System.Drawing.Size(100, 27);
            textBoxEmail.TabIndex = 1;
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new System.Drawing.Point(319, 335);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new System.Drawing.Size(100, 27);
            textBoxNumber.TabIndex = 2;
            // 
            // textBoxInstiut
            // 
            textBoxInstiut.Location = new System.Drawing.Point(319, 290);
            textBoxInstiut.Name = "textBoxInstiut";
            textBoxInstiut.Size = new System.Drawing.Size(100, 27);
            textBoxInstiut.TabIndex = 3;
            // 
            // textBoxScoutGroup
            // 
            textBoxScoutGroup.Location = new System.Drawing.Point(319, 247);
            textBoxScoutGroup.Name = "textBoxScoutGroup";
            textBoxScoutGroup.Size = new System.Drawing.Size(100, 27);
            textBoxScoutGroup.TabIndex = 4;
            // 
            // textBoxPatronymic
            // 
            textBoxPatronymic.Location = new System.Drawing.Point(319, 202);
            textBoxPatronymic.Name = "textBoxPatronymic";
            textBoxPatronymic.Size = new System.Drawing.Size(100, 27);
            textBoxPatronymic.TabIndex = 5;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new System.Drawing.Point(319, 160);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new System.Drawing.Size(100, 27);
            textBoxSurname.TabIndex = 6;
            // 
            // textBoxName
            // 
            textBoxName.Location = new System.Drawing.Point(319, 118);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new System.Drawing.Size(100, 27);
            textBoxName.TabIndex = 7;
            // 
            // Email
            // 
            Email.Location = new System.Drawing.Point(140, 382);
            Email.Name = "Email";
            Email.Size = new System.Drawing.Size(100, 23);
            Email.TabIndex = 8;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(140, 247);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(100, 23);
            label2.TabIndex = 9;
            // 
            // Institution
            // 
            Institution.Location = new System.Drawing.Point(140, 339);
            Institution.Name = "Institution";
            Institution.Size = new System.Drawing.Size(100, 23);
            Institution.TabIndex = 10;
            // 
            // ScoutGroup
            // 
            ScoutGroup.Location = new System.Drawing.Point(140, 290);
            ScoutGroup.Name = "ScoutGroup";
            ScoutGroup.Size = new System.Drawing.Size(100, 23);
            ScoutGroup.TabIndex = 11;
            // 
            // Patronymic
            // 
            Patronymic.Location = new System.Drawing.Point(140, 202);
            Patronymic.Name = "Patronymic";
            Patronymic.Size = new System.Drawing.Size(100, 23);
            Patronymic.TabIndex = 12;
            // 
            // Surname
            // 
            Surname.Location = new System.Drawing.Point(140, 160);
            Surname.Name = "Surname";
            Surname.Size = new System.Drawing.Size(100, 23);
            Surname.TabIndex = 13;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.BackColor = System.Drawing.Color.White;
            nameLabel.Font = new System.Drawing.Font("Georgia", 12F);
            nameLabel.ForeColor = System.Drawing.Color.DimGray;
            nameLabel.Location = new System.Drawing.Point(183, 121);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(57, 24);
            nameLabel.TabIndex = 11;
            nameLabel.Text = "Имя:";
            // 
            // title
            // 
            title.Location = new System.Drawing.Point(49, 33);
            title.Name = "title";
            title.Size = new System.Drawing.Size(100, 23);
            title.TabIndex = 14;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(693, 58);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(100, 50);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // ChangeUser
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(869, 495);
            Controls.Add(plane);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.Panel planeForPreviewImage;
    }
}