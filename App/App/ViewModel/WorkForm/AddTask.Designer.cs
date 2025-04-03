namespace App.ViewModel.WorkForm
{
    partial class AddTask
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
            labelQuantityFile = new Label();
            label4 = new Label();
            textBoxQuestion = new TextBox();
            buttonOk = new Button();
            buttonOpenFile = new Button();
            radioButtonCheck = new RadioButton();
            radioButtonRadio = new RadioButton();
            label3 = new Label();
            radioButtonText = new RadioButton();
            label2 = new Label();
            textBoxConfusing = new TextBox();
            label1 = new Label();
            textCorrect = new TextBox();
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
            plane.Controls.Add(labelQuantityFile);
            plane.Controls.Add(label4);
            plane.Controls.Add(textBoxQuestion);
            plane.Controls.Add(buttonOk);
            plane.Controls.Add(buttonOpenFile);
            plane.Controls.Add(radioButtonCheck);
            plane.Controls.Add(radioButtonRadio);
            plane.Controls.Add(label3);
            plane.Controls.Add(radioButtonText);
            plane.Controls.Add(label2);
            plane.Controls.Add(textBoxConfusing);
            plane.Controls.Add(label1);
            plane.Controls.Add(textCorrect);
            plane.Controls.Add(title);
            plane.Controls.Add(pictureBox1);
            plane.Location = new Point(0, 1);
            plane.Margin = new Padding(3, 4, 3, 4);
            plane.Name = "plane";
            plane.Size = new Size(877, 505);
            plane.TabIndex = 0;
            // 
            // labelQuantityFile
            // 
            labelQuantityFile.AutoSize = true;
            labelQuantityFile.BackColor = Color.FromArgb(241, 240, 227);
            labelQuantityFile.Font = new Font("Georgia", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelQuantityFile.ForeColor = Color.FromArgb(64, 64, 64);
            labelQuantityFile.Location = new Point(518, 352);
            labelQuantityFile.Name = "labelQuantityFile";
            labelQuantityFile.Size = new Size(196, 21);
            labelQuantityFile.TabIndex = 21;
            labelQuantityFile.Text = "Количество файлов: 0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(241, 240, 227);
            label4.Font = new Font("Georgia", 13.8F);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(159, 114);
            label4.Name = "label4";
            label4.Size = new Size(88, 27);
            label4.TabIndex = 20;
            label4.Text = "Вопрос";
            // 
            // textBoxQuestion
            // 
            textBoxQuestion.Location = new Point(273, 114);
            textBoxQuestion.Margin = new Padding(3, 4, 3, 4);
            textBoxQuestion.Name = "textBoxQuestion";
            textBoxQuestion.Size = new Size(441, 27);
            textBoxQuestion.TabIndex = 19;
            // 
            // buttonOk
            // 
            buttonOk.BackgroundImage = Properties.Resources.оранжевый;
            buttonOk.BackgroundImageLayout = ImageLayout.Stretch;
            buttonOk.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonOk.ForeColor = Color.White;
            buttonOk.Location = new Point(363, 421);
            buttonOk.Margin = new Padding(3, 4, 3, 4);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(173, 60);
            buttonOk.TabIndex = 18;
            buttonOk.Text = "Добавить";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonOpenFile
            // 
            buttonOpenFile.BackgroundImage = Properties.Resources.коричневый;
            buttonOpenFile.BackgroundImageLayout = ImageLayout.Stretch;
            buttonOpenFile.Font = new Font("Georgia", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonOpenFile.Location = new Point(518, 297);
            buttonOpenFile.Margin = new Padding(3, 4, 3, 4);
            buttonOpenFile.Name = "buttonOpenFile";
            buttonOpenFile.Size = new Size(196, 50);
            buttonOpenFile.TabIndex = 17;
            buttonOpenFile.Text = "Добавить файлы";
            buttonOpenFile.UseVisualStyleBackColor = true;
            buttonOpenFile.Click += buttonOpenFile_Click;
            // 
            // radioButtonCheck
            // 
            radioButtonCheck.AutoSize = true;
            radioButtonCheck.BackColor = Color.FromArgb(241, 240, 227);
            radioButtonCheck.Font = new Font("Georgia", 10.8F);
            radioButtonCheck.ForeColor = Color.FromArgb(64, 64, 64);
            radioButtonCheck.Location = new Point(351, 339);
            radioButtonCheck.Margin = new Padding(3, 4, 3, 4);
            radioButtonCheck.Name = "radioButtonCheck";
            radioButtonCheck.Size = new Size(101, 25);
            radioButtonCheck.TabIndex = 16;
            radioButtonCheck.TabStop = true;
            radioButtonCheck.Text = "Отметка";
            radioButtonCheck.UseVisualStyleBackColor = false;
            radioButtonCheck.CheckedChanged += radioButtonCheck_CheckedChanged;
            // 
            // radioButtonRadio
            // 
            radioButtonRadio.AutoSize = true;
            radioButtonRadio.BackColor = Color.FromArgb(241, 240, 227);
            radioButtonRadio.Font = new Font("Georgia", 10.8F);
            radioButtonRadio.ForeColor = Color.FromArgb(64, 64, 64);
            radioButtonRadio.Location = new Point(259, 339);
            radioButtonRadio.Margin = new Padding(3, 4, 3, 4);
            radioButtonRadio.Name = "radioButtonRadio";
            radioButtonRadio.Size = new Size(87, 25);
            radioButtonRadio.TabIndex = 15;
            radioButtonRadio.TabStop = true;
            radioButtonRadio.Text = "Выбор";
            radioButtonRadio.UseVisualStyleBackColor = false;
            radioButtonRadio.CheckedChanged += radioButtonRadio_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(241, 240, 227);
            label3.Font = new Font("Georgia", 13.8F);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(159, 297);
            label3.Name = "label3";
            label3.Size = new Size(121, 27);
            label3.TabIndex = 14;
            label3.Text = "Тип ввода";
            // 
            // radioButtonText
            // 
            radioButtonText.AutoSize = true;
            radioButtonText.BackColor = Color.FromArgb(241, 240, 227);
            radioButtonText.Font = new Font("Georgia", 10.8F);
            radioButtonText.ForeColor = Color.FromArgb(64, 64, 64);
            radioButtonText.Location = new Point(169, 339);
            radioButtonText.Margin = new Padding(3, 4, 3, 4);
            radioButtonText.Name = "radioButtonText";
            radioButtonText.Size = new Size(77, 25);
            radioButtonText.TabIndex = 13;
            radioButtonText.TabStop = true;
            radioButtonText.Text = "Текст";
            radioButtonText.UseVisualStyleBackColor = false;
            radioButtonText.CheckedChanged += radioButtonText_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(241, 240, 227);
            label2.Font = new Font("Georgia", 13.8F);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(159, 210);
            label2.Name = "label2";
            label2.Size = new Size(555, 27);
            label2.TabIndex = 12;
            label2.Text = "Перечислите неправильные ответы через запятую";
            // 
            // textBoxConfusing
            // 
            textBoxConfusing.Location = new Point(159, 251);
            textBoxConfusing.Margin = new Padding(3, 4, 3, 4);
            textBoxConfusing.Name = "textBoxConfusing";
            textBoxConfusing.Size = new Size(555, 27);
            textBoxConfusing.TabIndex = 11;
            textBoxConfusing.TextChanged += textBoxConfusing_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(241, 240, 227);
            label1.Font = new Font("Georgia", 13.8F);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(159, 161);
            label1.Name = "label1";
            label1.Size = new Size(214, 27);
            label1.TabIndex = 10;
            label1.Text = "Правильный ответ";
            // 
            // textCorrect
            // 
            textCorrect.Location = new Point(411, 161);
            textCorrect.Margin = new Padding(3, 4, 3, 4);
            textCorrect.Name = "textCorrect";
            textCorrect.Size = new Size(303, 27);
            textCorrect.TabIndex = 9;
            // 
            // title
            // 
            title.AutoSize = true;
            title.BackColor = Color.Transparent;
            title.Font = new Font("Georgia", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            title.ForeColor = Color.Black;
            title.Location = new Point(292, 33);
            title.Name = "title";
            title.Size = new Size(315, 31);
            title.TabIndex = 7;
            title.Text = "Добавление задания";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.светлый_текст;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(103, 72);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(675, 342);
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // AddTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 495);
            Controls.Add(plane);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "AddTask";
            Text = "AddAssigment";
            Load += AddAssigment_Load;
            plane.ResumeLayout(false);
            plane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel plane;
        private Label title;
        private Label label1;
        private TextBox textCorrect;
        private Label label2;
        private TextBox textBoxConfusing;
        private RadioButton radioButtonText;
        private RadioButton radioButtonCheck;
        private RadioButton radioButtonRadio;
        private Label label3;
        private Button buttonOpenFile;
        private Button buttonOk;
        private Label label4;
        private TextBox textBoxQuestion;
        private Label labelQuantityFile;
        private PictureBox pictureBox1;
    }
}