namespace App.ViewModel.WorkForm
{
    partial class UserRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserRegistration));
            plane = new Panel();
            buttonExit = new Button();
            panel4 = new Panel();
            label4 = new Label();
            inputEmail = new TextBox();
            buttonSend = new Button();
            panel3 = new Panel();
            label3 = new Label();
            inputGroups = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            inputPassword = new TextBox();
            InputContainer = new Panel();
            text = new Label();
            inputFIO = new TextBox();
            title = new Label();
            plane.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            InputContainer.SuspendLayout();
            SuspendLayout();
            // 
            // plane
            // 
            plane.BackColor = Color.Lavender;
            plane.Controls.Add(buttonExit);
            plane.Controls.Add(panel4);
            plane.Controls.Add(buttonSend);
            plane.Controls.Add(panel3);
            plane.Controls.Add(panel1);
            plane.Controls.Add(InputContainer);
            plane.Controls.Add(title);
            plane.Location = new Point(0, 1);
            plane.Name = "plane";
            plane.Size = new Size(800, 450);
            plane.TabIndex = 0;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.White;
            buttonExit.BackgroundImage = (Image)resources.GetObject("buttonExit.BackgroundImage");
            buttonExit.BackgroundImageLayout = ImageLayout.Stretch;
            buttonExit.Location = new Point(3, 3);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(40, 40);
            buttonExit.TabIndex = 13;
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(label4);
            panel4.Controls.Add(inputEmail);
            panel4.Location = new Point(381, 219);
            panel4.Name = "panel4";
            panel4.Size = new Size(273, 35);
            panel4.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 18F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(0, 1);
            label4.Name = "label4";
            label4.Size = new Size(93, 29);
            label4.TabIndex = 3;
            label4.Text = "Почта";
            // 
            // inputEmail
            // 
            inputEmail.Location = new Point(117, 1);
            inputEmail.Multiline = true;
            inputEmail.Name = "inputEmail";
            inputEmail.Size = new Size(156, 34);
            inputEmail.TabIndex = 2;
            // 
            // buttonSend
            // 
            buttonSend.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonSend.Location = new Point(285, 351);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(218, 33);
            buttonSend.TabIndex = 10;
            buttonSend.Text = "Зарегистрироваться";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(inputGroups);
            panel3.Location = new Point(63, 218);
            panel3.Name = "panel3";
            panel3.Size = new Size(273, 35);
            panel3.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 18F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(0, 1);
            label3.Name = "label3";
            label3.Size = new Size(106, 29);
            label3.TabIndex = 3;
            label3.Text = "Группа";
            // 
            // inputGroups
            // 
            inputGroups.Location = new Point(117, 1);
            inputGroups.Multiline = true;
            inputGroups.Name = "inputGroups";
            inputGroups.Size = new Size(156, 34);
            inputGroups.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(inputPassword);
            panel1.Location = new Point(381, 140);
            panel1.Name = "panel1";
            panel1.Size = new Size(273, 35);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 18F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 1);
            label1.Name = "label1";
            label1.Size = new Size(110, 29);
            label1.TabIndex = 3;
            label1.Text = "Пароль";
            // 
            // inputPassword
            // 
            inputPassword.Location = new Point(112, 1);
            inputPassword.Multiline = true;
            inputPassword.Name = "inputPassword";
            inputPassword.Size = new Size(161, 34);
            inputPassword.TabIndex = 2;
            // 
            // InputContainer
            // 
            InputContainer.Controls.Add(text);
            InputContainer.Controls.Add(inputFIO);
            InputContainer.Location = new Point(63, 139);
            InputContainer.Name = "InputContainer";
            InputContainer.Size = new Size(273, 35);
            InputContainer.TabIndex = 3;
            // 
            // text
            // 
            text.AutoSize = true;
            text.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            text.ForeColor = Color.Black;
            text.Location = new Point(0, 1);
            text.Name = "text";
            text.Size = new Size(77, 29);
            text.TabIndex = 3;
            text.Text = "ФИО";
            // 
            // inputFIO
            // 
            inputFIO.Location = new Point(82, 1);
            inputFIO.Multiline = true;
            inputFIO.Name = "inputFIO";
            inputFIO.Size = new Size(191, 34);
            inputFIO.TabIndex = 2;
            // 
            // title
            // 
            title.AutoSize = true;
            title.BackColor = Color.Lavender;
            title.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            title.ForeColor = Color.Black;
            title.Location = new Point(285, 30);
            title.Name = "title";
            title.Size = new Size(178, 29);
            title.TabIndex = 1;
            title.Text = "Регистрация";
            // 
            // UserRegistration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(plane);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserRegistration";
            Text = "UserRegistration";
            plane.ResumeLayout(false);
            plane.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            InputContainer.ResumeLayout(false);
            InputContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel plane;
        private Label title;
        private Panel InputContainer;
        private Label text;
        private TextBox inputFIO;
        private Panel panel1;
        private Label label1;
        private TextBox inputPassword;
        private Panel panel3;
        private Label label3;
        private TextBox inputGroups;
        private Button buttonSend;
        private Panel panel4;
        private Label label4;
        private TextBox inputEmail;
        private Button buttonExit;
    }
}