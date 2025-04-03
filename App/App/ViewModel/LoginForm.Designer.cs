namespace App.ViewModel.WorkForm
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            plane = new Panel();
            buttonExit = new Button();
            buttonSend = new Button();
            title = new Label();
            panel2 = new Panel();
            label2 = new Label();
            inputEmail = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            inputPassword = new TextBox();
            plane.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // plane
            // 
            plane.BackColor = Color.Lavender;
            plane.BackgroundImage = Properties.Resources.фон;
            plane.BackgroundImageLayout = ImageLayout.Stretch;
            plane.Controls.Add(buttonExit);
            plane.Controls.Add(buttonSend);
            plane.Controls.Add(title);
            plane.Controls.Add(panel2);
            plane.Controls.Add(panel1);
            plane.Location = new Point(0, 1);
            plane.Margin = new Padding(3, 4, 3, 4);
            plane.Name = "plane";
            plane.Size = new Size(875, 501);
            plane.TabIndex = 0;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.White;
            buttonExit.BackgroundImage = (Image)resources.GetObject("buttonExit.BackgroundImage");
            buttonExit.BackgroundImageLayout = ImageLayout.Stretch;
            buttonExit.Location = new Point(14, 15);
            buttonExit.Margin = new Padding(3, 4, 3, 4);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(56, 53);
            buttonExit.TabIndex = 12;
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonSend
            // 
            buttonSend.BackgroundImage = Properties.Resources.оранжевый;
            buttonSend.BackgroundImageLayout = ImageLayout.Stretch;
            buttonSend.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonSend.ForeColor = Color.White;
            buttonSend.Location = new Point(329, 345);
            buttonSend.Margin = new Padding(3, 4, 3, 4);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(254, 59);
            buttonSend.TabIndex = 11;
            buttonSend.Text = "Войти";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // title
            // 
            title.AutoSize = true;
            title.BackColor = Color.Transparent;
            title.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            title.ForeColor = Color.Black;
            title.Location = new Point(402, 71);
            title.Name = "title";
            title.Size = new Size(93, 35);
            title.TabIndex = 4;
            title.Text = "Вход";
            // 
            // panel2
            // 
            panel2.BackgroundImage = Properties.Resources.светлый_текст;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(inputEmail);
            panel2.Location = new Point(261, 150);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(365, 56);
            panel2.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.Gray;
            label2.Image = Properties.Resources.светлый;
            label2.Location = new Point(20, 20);
            label2.Name = "label2";
            label2.Size = new Size(79, 27);
            label2.TabIndex = 3;
            label2.Text = "Логин";
            // 
            // inputEmail
            // 
            inputEmail.Location = new Point(134, 9);
            inputEmail.Margin = new Padding(3, 4, 3, 4);
            inputEmail.Multiline = true;
            inputEmail.Name = "inputEmail";
            inputEmail.Size = new Size(217, 38);
            inputEmail.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.светлый_текст;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(inputPassword);
            panel1.Location = new Point(261, 239);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(365, 58);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Gray;
            label1.Image = Properties.Resources.светлый;
            label1.Location = new Point(20, 21);
            label1.Name = "label1";
            label1.Size = new Size(92, 27);
            label1.TabIndex = 3;
            label1.Text = "Пароль";
            // 
            // inputPassword
            // 
            inputPassword.Location = new Point(134, 10);
            inputPassword.Margin = new Padding(3, 4, 3, 4);
            inputPassword.Multiline = true;
            inputPassword.Name = "inputPassword";
            inputPassword.Size = new Size(217, 38);
            inputPassword.TabIndex = 2;
            inputPassword.TextChanged += inputPassword_TextChanged;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 495);
            Controls.Add(plane);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "LoginForm";
            plane.ResumeLayout(false);
            plane.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel plane;
        private Panel panel2;
        private Label label2;
        private TextBox inputEmail;
        private Panel panel1;
        private Label label1;
        private TextBox inputPassword;
        private Label title;
        private Button buttonSend;
        private Button buttonExit;
    }
}