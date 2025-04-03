namespace App.ViewModel
{
    partial class DataBaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBaseForm));
            plane = new Panel();
            radioButtonEvents = new RadioButton();
            radioButtonUser = new RadioButton();
            dataGridUser = new DataGridView();
            buttonExit = new Button();
            radioButtonTheoreticalActive = new RadioButton();
            radioButtonTestActive = new RadioButton();
            buttonDelete = new Button();
            buttonAdd = new Button();
            dataGridViewEvents = new DataGridView();
            dataGridViewModule = new DataGridView();
            title = new Label();
            plane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEvents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewModule).BeginInit();
            SuspendLayout();
            // 
            // plane
            // 
            plane.BackColor = Color.Lavender;
            plane.BackgroundImage = Properties.Resources.фон;
            plane.BackgroundImageLayout = ImageLayout.Stretch;
            plane.Controls.Add(radioButtonEvents);
            plane.Controls.Add(radioButtonUser);
            plane.Controls.Add(dataGridUser);
            plane.Controls.Add(buttonExit);
            plane.Controls.Add(radioButtonTheoreticalActive);
            plane.Controls.Add(radioButtonTestActive);
            plane.Controls.Add(buttonDelete);
            plane.Controls.Add(buttonAdd);
            plane.Controls.Add(dataGridViewEvents);
            plane.Controls.Add(dataGridViewModule);
            plane.Controls.Add(title);
            plane.Location = new Point(0, 1);
            plane.Margin = new Padding(3, 4, 3, 4);
            plane.Name = "plane";
            plane.Size = new Size(875, 497);
            plane.TabIndex = 0;
            // 
            // radioButtonEvents
            // 
            radioButtonEvents.AutoSize = true;
            radioButtonEvents.BackColor = Color.Transparent;
            radioButtonEvents.Font = new Font("Georgia", 9F);
            radioButtonEvents.ForeColor = Color.DimGray;
            radioButtonEvents.Location = new Point(732, 27);
            radioButtonEvents.Margin = new Padding(3, 4, 3, 4);
            radioButtonEvents.Name = "radioButtonEvents";
            radioButtonEvents.Size = new Size(91, 22);
            radioButtonEvents.TabIndex = 19;
            radioButtonEvents.TabStop = true;
            radioButtonEvents.Text = "События";
            radioButtonEvents.UseVisualStyleBackColor = false;
            radioButtonEvents.CheckedChanged += radioButtonEvents_CheckedChanged;
            // 
            // radioButtonUser
            // 
            radioButtonUser.AutoSize = true;
            radioButtonUser.BackColor = Color.Transparent;
            radioButtonUser.Font = new Font("Georgia", 9F);
            radioButtonUser.ForeColor = Color.DimGray;
            radioButtonUser.Location = new Point(580, 27);
            radioButtonUser.Margin = new Padding(3, 4, 3, 4);
            radioButtonUser.Name = "radioButtonUser";
            radioButtonUser.Size = new Size(129, 22);
            radioButtonUser.TabIndex = 18;
            radioButtonUser.TabStop = true;
            radioButtonUser.Text = "Пользователи";
            radioButtonUser.UseVisualStyleBackColor = false;
            radioButtonUser.CheckedChanged += radioButtonUser_CheckedChanged;
            // 
            // dataGridUser
            // 
            dataGridUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridUser.Location = new Point(46, 100);
            dataGridUser.Margin = new Padding(3, 4, 3, 4);
            dataGridUser.Name = "dataGridUser";
            dataGridUser.RowHeadersWidth = 51;
            dataGridUser.Size = new Size(777, 297);
            dataGridUser.TabIndex = 17;
            dataGridUser.CellContentClick += dataGridUser_CellContentClick;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.White;
            buttonExit.BackgroundImage = (Image)resources.GetObject("buttonExit.BackgroundImage");
            buttonExit.BackgroundImageLayout = ImageLayout.Stretch;
            buttonExit.Location = new Point(3, 12);
            buttonExit.Margin = new Padding(3, 4, 3, 4);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(54, 51);
            buttonExit.TabIndex = 9;
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // radioButtonTheoreticalActive
            // 
            radioButtonTheoreticalActive.AutoSize = true;
            radioButtonTheoreticalActive.BackColor = Color.Transparent;
            radioButtonTheoreticalActive.Font = new Font("Georgia", 9F);
            radioButtonTheoreticalActive.ForeColor = Color.DimGray;
            radioButtonTheoreticalActive.Location = new Point(474, 27);
            radioButtonTheoreticalActive.Margin = new Padding(3, 4, 3, 4);
            radioButtonTheoreticalActive.Name = "radioButtonTheoreticalActive";
            radioButtonTheoreticalActive.Size = new Size(78, 22);
            radioButtonTheoreticalActive.TabIndex = 16;
            radioButtonTheoreticalActive.TabStop = true;
            radioButtonTheoreticalActive.Text = "Теория";
            radioButtonTheoreticalActive.UseVisualStyleBackColor = false;
            radioButtonTheoreticalActive.CheckedChanged += radioButtonTheoreticalActive_CheckedChanged;
            // 
            // radioButtonTestActive
            // 
            radioButtonTestActive.AutoSize = true;
            radioButtonTestActive.BackColor = Color.Transparent;
            radioButtonTestActive.Font = new Font("Georgia", 9F);
            radioButtonTestActive.ForeColor = Color.DimGray;
            radioButtonTestActive.Location = new Point(375, 27);
            radioButtonTestActive.Margin = new Padding(3, 4, 3, 4);
            radioButtonTestActive.Name = "radioButtonTestActive";
            radioButtonTestActive.Size = new Size(71, 22);
            radioButtonTestActive.TabIndex = 1;
            radioButtonTestActive.TabStop = true;
            radioButtonTestActive.Text = "Тесты";
            radioButtonTestActive.UseVisualStyleBackColor = false;
            radioButtonTestActive.CheckedChanged += radioButtonTestActive_CheckedChanged;
            // 
            // buttonDelete
            // 
            buttonDelete.BackgroundImage = Properties.Resources.оранжевый;
            buttonDelete.BackgroundImageLayout = ImageLayout.Stretch;
            buttonDelete.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(451, 429);
            buttonDelete.Margin = new Padding(3, 4, 3, 4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(158, 52);
            buttonDelete.TabIndex = 15;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.BackgroundImage = Properties.Resources.оранжевый;
            buttonAdd.BackgroundImageLayout = ImageLayout.Stretch;
            buttonAdd.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAdd.ForeColor = Color.White;
            buttonAdd.Location = new Point(235, 429);
            buttonAdd.Margin = new Padding(3, 4, 3, 4);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(158, 52);
            buttonAdd.TabIndex = 13;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // dataGridViewEvents
            // 
            dataGridViewEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEvents.Location = new Point(46, 100);
            dataGridViewEvents.Margin = new Padding(3, 4, 3, 4);
            dataGridViewEvents.Name = "dataGridViewEvents";
            dataGridViewEvents.RowHeadersWidth = 51;
            dataGridViewEvents.Size = new Size(777, 297);
            dataGridViewEvents.TabIndex = 12;
            // 
            // dataGridViewModule
            // 
            dataGridViewModule.AllowUserToAddRows = false;
            dataGridViewModule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewModule.Location = new Point(46, 100);
            dataGridViewModule.Margin = new Padding(3, 4, 3, 4);
            dataGridViewModule.Name = "dataGridViewModule";
            dataGridViewModule.RowHeadersWidth = 51;
            dataGridViewModule.Size = new Size(777, 297);
            dataGridViewModule.TabIndex = 6;
            // 
            // title
            // 
            title.AutoSize = true;
            title.BackColor = Color.Transparent;
            title.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            title.ForeColor = Color.Black;
            title.Location = new Point(86, 18);
            title.Name = "title";
            title.Size = new Size(220, 35);
            title.TabIndex = 5;
            title.Text = "База данных";
            // 
            // DataBaseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 495);
            Controls.Add(plane);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "DataBaseForm";
            Text = "DataBaseForm";
            Load += DataBaseForm_Load;
            plane.ResumeLayout(false);
            plane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEvents).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewModule).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel plane;
        private DataGridView dataGridViewModule;
        private Label title;
        private DataGridView dataGridViewEvents;
        private Button buttonDelete;
        private Button buttonAdd;
        private RadioButton radioButtonTestActive;
        private Button buttonExit;
        private RadioButton radioButtonUser;
        private DataGridView dataGridUser;
        private RadioButton radioButtonEvents;
        private RadioButton radioButtonTheoreticalActive;
    }
}