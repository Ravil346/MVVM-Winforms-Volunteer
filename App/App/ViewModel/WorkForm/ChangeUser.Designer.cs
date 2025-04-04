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
            label7 = new Label();
            buttonUploadPhoto = new Button();
            buttonSave = new Button();
            textBoxEmail = new TextBox();
            textBoxNumber = new TextBox();
            textBoxInstiut = new TextBox();
            textBoxScoutGroup = new TextBox();
            textBoxPatronymic = new TextBox();
            textBoxSurname = new TextBox();
            textBoxName = new TextBox();
            planeForPreviewImage = new Panel();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label8 = new Label();
            nameLabel = new Label();
            plane.SuspendLayout();
            SuspendLayout();
            // 
            // plane
            // 
            plane.BackColor = Color.Lavender;
            plane.BackgroundImage = Properties.Resources.фон;
            plane.BackgroundImageLayout = ImageLayout.Stretch;
            plane.Controls.Add(planeForPreviewImage);
            plane.Controls.Add(label5);
            plane.Controls.Add(label3);
            plane.Controls.Add(label4);
            plane.Controls.Add(label1);
            plane.Controls.Add(label2);
            plane.Controls.Add(label8);
            plane.Controls.Add(nameLabel);
            plane.Controls.Add(label7);
            plane.Controls.Add(buttonUploadPhoto);
            plane.Controls.Add(buttonSave);
            plane.Controls.Add(textBoxEmail);
            plane.Controls.Add(textBoxNumber);
            plane.Controls.Add(textBoxInstiut);
            plane.Controls.Add(textBoxScoutGroup);
            plane.Controls.Add(textBoxPatronymic);
            plane.Controls.Add(textBoxSurname);
            plane.Controls.Add(textBoxName);
            plane.Location = new Point(0, 1);
            plane.Margin = new Padding(3, 4, 3, 4);
            plane.Name = "plane";
            plane.Size = new Size(723, 484);
            plane.TabIndex = 0;
            plane.Paint += plane_Paint;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(0, 0, 0, 0);
            label7.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(71, 32);
            label7.Name = "label7";
            label7.Size = new Size(167, 35);
            label7.TabIndex = 24;
            label7.Text = "Профиль";
            // 
            // buttonUploadPhoto
            // 
            buttonUploadPhoto.BackgroundImage = Properties.Resources.оранжевый;
            buttonUploadPhoto.BackgroundImageLayout = ImageLayout.Stretch;
            buttonUploadPhoto.Font = new Font("Georgia", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonUploadPhoto.ForeColor = Color.White;
            buttonUploadPhoto.Location = new Point(406, 383);
            buttonUploadPhoto.Name = "buttonUploadPhoto";
            buttonUploadPhoto.Size = new Size(230, 57);
            buttonUploadPhoto.TabIndex = 16;
            buttonUploadPhoto.Text = "Фото";
            buttonUploadPhoto.Click += buttonUploadPhoto_Click;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Orange;
            buttonSave.BackgroundImage = Properties.Resources.оранжевый;
            buttonSave.BackgroundImageLayout = ImageLayout.Stretch;
            buttonSave.Font = new Font("Georgia", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonSave.ForeColor = SystemColors.ControlLightLight;
            buttonSave.Location = new Point(67, 383);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(310, 57);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Обновить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click_1;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(257, 335);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(100, 27);
            textBoxEmail.TabIndex = 1;
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(257, 292);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(100, 27);
            textBoxNumber.TabIndex = 2;
            // 
            // textBoxInstiut
            // 
            textBoxInstiut.Location = new Point(257, 247);
            textBoxInstiut.Name = "textBoxInstiut";
            textBoxInstiut.Size = new Size(100, 27);
            textBoxInstiut.TabIndex = 3;
            // 
            // textBoxScoutGroup
            // 
            textBoxScoutGroup.Location = new Point(257, 204);
            textBoxScoutGroup.Name = "textBoxScoutGroup";
            textBoxScoutGroup.Size = new Size(100, 27);
            textBoxScoutGroup.TabIndex = 4;
            // 
            // textBoxPatronymic
            // 
            textBoxPatronymic.Location = new Point(257, 159);
            textBoxPatronymic.Name = "textBoxPatronymic";
            textBoxPatronymic.Size = new Size(100, 27);
            textBoxPatronymic.TabIndex = 5;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(257, 117);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(100, 27);
            textBoxSurname.TabIndex = 6;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(257, 75);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 27);
            textBoxName.TabIndex = 7;
            // 
            // planeForPreviewImage
            // 
            planeForPreviewImage.BackColor = Color.NavajoWhite;
            planeForPreviewImage.Location = new Point(406, 78);
            planeForPreviewImage.Name = "planeForPreviewImage";
            planeForPreviewImage.Size = new Size(230, 292);
            planeForPreviewImage.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(0, 0, 0, 0);
            label5.Font = new Font("Georgia", 12F);
            label5.ForeColor = Color.DimGray;
            label5.Location = new Point(79, 338);
            label5.Name = "label5";
            label5.Size = new Size(73, 24);
            label5.TabIndex = 32;
            label5.Text = "Почта:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(0, 0, 0, 0);
            label3.Font = new Font("Georgia", 12F);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(79, 292);
            label3.Name = "label3";
            label3.Size = new Size(99, 24);
            label3.TabIndex = 30;
            label3.Text = "Телефон:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 0, 0);
            label4.Font = new Font("Georgia", 12F);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(79, 250);
            label4.Name = "label4";
            label4.Size = new Size(102, 24);
            label4.TabIndex = 29;
            label4.Text = "Институт:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            label1.Font = new Font("Georgia", 12F);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(79, 204);
            label1.Name = "label1";
            label1.Size = new Size(67, 24);
            label1.TabIndex = 28;
            label1.Text = "Отряд";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
            label2.Font = new Font("Georgia", 12F);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(79, 162);
            label2.Name = "label2";
            label2.Size = new Size(100, 24);
            label2.TabIndex = 27;
            label2.Text = "Отчество:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(0, 0, 0, 0);
            label8.Font = new Font("Georgia", 12F);
            label8.ForeColor = Color.DimGray;
            label8.Location = new Point(79, 120);
            label8.Name = "label8";
            label8.Size = new Size(103, 24);
            label8.TabIndex = 26;
            label8.Text = "Фамилия:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.BackColor = Color.FromArgb(0, 0, 0, 0);
            nameLabel.Font = new Font("Georgia", 12F);
            nameLabel.ForeColor = Color.DimGray;
            nameLabel.Location = new Point(79, 78);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(57, 24);
            nameLabel.TabIndex = 25;
            nameLabel.Text = "Имя:";
            // 
            // ChangeUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 481);
            Controls.Add(plane);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ChangeUser";
            Text = "ChangeUser";
            plane.ResumeLayout(false);
            plane.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label label7;

        #endregion

        private System.Windows.Forms.Panel plane;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.TextBox textBoxInstiut;
        private System.Windows.Forms.TextBox textBoxScoutGroup;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonUploadPhoto;
        private Panel planeForPreviewImage;
        private Label label5;
        private Label label3;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label label8;
        private Label nameLabel;
    }
}