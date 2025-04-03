namespace App.ViewModel.WorkForm
{
    partial class AddIncident
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
            buttonSave = new Button();
            labelWarning = new Label();
            planeForPreviewImage = new Panel();
            buttonOpenFile = new Button();
            label1 = new Label();
            textName = new TextBox();
            title = new Label();
            pictureBox1 = new PictureBox();
            plane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // plane
            // 
            plane.BackColor = Color.Lavender;
            plane.BackgroundImage = Properties.Resources.фон;
            plane.BackgroundImageLayout = ImageLayout.Stretch;
            plane.Controls.Add(buttonSave);
            plane.Controls.Add(labelWarning);
            plane.Controls.Add(planeForPreviewImage);
            plane.Controls.Add(buttonOpenFile);
            plane.Controls.Add(label1);
            plane.Controls.Add(textName);
            plane.Controls.Add(title);
            plane.Controls.Add(pictureBox1);
            plane.Location = new Point(0, 0);
            plane.Margin = new Padding(3, 4, 3, 4);
            plane.Name = "plane";
            plane.Size = new Size(869, 507);
            plane.TabIndex = 0;
            // 
            // buttonSave
            // 
            buttonSave.BackgroundImage = Properties.Resources.оранжевый;
            buttonSave.BackgroundImageLayout = ImageLayout.Stretch;
            buttonSave.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(319, 397);
            buttonSave.Margin = new Padding(3, 4, 3, 4);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(229, 63);
            buttonSave.TabIndex = 21;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelWarning
            // 
            labelWarning.AutoSize = true;
            labelWarning.Font = new Font("Georgia", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelWarning.ForeColor = Color.DimGray;
            labelWarning.Image = Properties.Resources.светлый;
            labelWarning.ImageAlign = ContentAlignment.TopLeft;
            labelWarning.Location = new Point(212, 277);
            labelWarning.Name = "labelWarning";
            labelWarning.Size = new Size(207, 27);
            labelWarning.TabIndex = 20;
            labelWarning.Text = "В формате 64 * 64";
            // 
            // planeForPreviewImage
            // 
            planeForPreviewImage.Location = new Point(539, 197);
            planeForPreviewImage.Margin = new Padding(3, 4, 3, 4);
            planeForPreviewImage.Name = "planeForPreviewImage";
            planeForPreviewImage.Size = new Size(111, 122);
            planeForPreviewImage.TabIndex = 19;
            // 
            // buttonOpenFile
            // 
            buttonOpenFile.BackgroundImage = Properties.Resources.коричневый;
            buttonOpenFile.BackgroundImageLayout = ImageLayout.Stretch;
            buttonOpenFile.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonOpenFile.Location = new Point(200, 209);
            buttonOpenFile.Margin = new Padding(3, 4, 3, 4);
            buttonOpenFile.Name = "buttonOpenFile";
            buttonOpenFile.Size = new Size(229, 54);
            buttonOpenFile.TabIndex = 18;
            buttonOpenFile.Text = "Добавить фото";
            buttonOpenFile.UseVisualStyleBackColor = true;
            buttonOpenFile.Click += buttonOpenFile_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Georgia", 14F);
            label1.ForeColor = Color.Black;
            label1.Image = Properties.Resources.светлый;
            label1.Location = new Point(212, 148);
            label1.Name = "label1";
            label1.Size = new Size(122, 29);
            label1.TabIndex = 10;
            label1.Text = "Название";
            // 
            // textName
            // 
            textName.Location = new Point(364, 148);
            textName.Margin = new Padding(3, 4, 3, 4);
            textName.Name = "textName";
            textName.Size = new Size(286, 27);
            textName.TabIndex = 9;
            // 
            // title
            // 
            title.AutoSize = true;
            title.BackColor = Color.Transparent;
            title.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            title.ForeColor = Color.Black;
            title.Location = new Point(212, 40);
            title.Name = "title";
            title.Size = new Size(438, 35);
            title.TabIndex = 7;
            title.Text = "Добавление мероприятия";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.светлый_текст;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(122, 96);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(626, 294);
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // AddIncident
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 495);
            Controls.Add(plane);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddIncident";
            Text = "AddIncident";
            plane.ResumeLayout(false);
            plane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel plane;
        private Label title;
        private Label label1;
        private TextBox textName;
        private Button buttonOpenFile;
        private Panel planeForPreviewImage;
        private Label labelWarning;
        private Button buttonSave;
        private PictureBox pictureBox1;
    }
}