namespace App.ViewModel
{
    partial class MainAuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAuthForm));
            plane = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            buttonRegistration = new Button();
            buttonLogin = new Button();
            HeaderText = new Label();
            pictureBox1 = new PictureBox();
            plane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // plane
            // 
            plane.BackColor = Color.Lavender;
            plane.BackgroundImage = (Image)resources.GetObject("plane.BackgroundImage");
            plane.BackgroundImageLayout = ImageLayout.Stretch;
            plane.Controls.Add(pictureBox3);
            plane.Controls.Add(pictureBox2);
            plane.Controls.Add(label2);
            plane.Controls.Add(label1);
            plane.Controls.Add(buttonRegistration);
            plane.Controls.Add(buttonLogin);
            plane.Controls.Add(HeaderText);
            plane.Controls.Add(pictureBox1);
            plane.Location = new Point(2, 1);
            plane.Margin = new Padding(3, 4, 3, 4);
            plane.Name = "plane";
            plane.Size = new Size(887, 542);
            plane.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.пламя;
            pictureBox3.Location = new Point(797, 11);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(71, 62);
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.аграрный;
            pictureBox2.Location = new Point(21, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(66, 62);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(241, 240, 227);
            label2.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(313, 257);
            label2.Name = "label2";
            label2.Size = new Size(240, 27);
            label2.TabIndex = 5;
            label2.Text = "Вы были у нас ранее?";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(241, 240, 227);
            label1.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(204, 184);
            label1.Name = "label1";
            label1.Size = new Size(471, 45);
            label1.TabIndex = 4;
            label1.Text = "Рады приветствовать вас в обучающей интерактивной системе волонтёрского отряда \"Пламя\"!";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonRegistration
            // 
            buttonRegistration.BackgroundImage = Properties.Resources.коричневый;
            buttonRegistration.BackgroundImageLayout = ImageLayout.Stretch;
            buttonRegistration.Font = new Font("Georgia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonRegistration.Location = new Point(298, 336);
            buttonRegistration.Margin = new Padding(3, 4, 3, 4);
            buttonRegistration.Name = "buttonRegistration";
            buttonRegistration.Size = new Size(255, 40);
            buttonRegistration.TabIndex = 2;
            buttonRegistration.Text = "Хочу стать волонтером";
            buttonRegistration.UseVisualStyleBackColor = true;
            buttonRegistration.Click += buttonRegistration_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.BackgroundImage = Properties.Resources.коричневый;
            buttonLogin.BackgroundImageLayout = ImageLayout.Stretch;
            buttonLogin.Font = new Font("Georgia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonLogin.Location = new Point(298, 288);
            buttonLogin.Margin = new Padding(3, 4, 3, 4);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(255, 40);
            buttonLogin.TabIndex = 1;
            buttonLogin.Text = "У меня есть аккаунт";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // HeaderText
            // 
            HeaderText.AutoSize = true;
            HeaderText.BackColor = Color.FromArgb(241, 240, 227);
            HeaderText.Font = new Font("Georgia", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            HeaderText.ForeColor = Color.DarkOrange;
            HeaderText.Location = new Point(204, 126);
            HeaderText.Name = "HeaderText";
            HeaderText.Size = new Size(471, 32);
            HeaderText.TabIndex = 0;
            HeaderText.Text = "Волонтёрский отряд \"Пламя\"!";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(166, 85);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(535, 322);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // MainAuthForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 543);
            Controls.Add(plane);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainAuthForm";
            Text = "MainAuthForm";
            Load += MainAuthForm_Load;
            plane.ResumeLayout(false);
            plane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel plane;
        private Label HeaderText;
        private Button buttonRegistration;
        private Button buttonLogin;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
    }
}