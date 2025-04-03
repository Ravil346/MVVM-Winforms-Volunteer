namespace App.ViewModel
{
    partial class MainUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUserForm));
            plane = new Panel();
            WorkPanel = new Panel();
            ActionBarPanel = new Panel();
            buttonDataBase = new Button();
            buttonIncidents = new Button();
            buttonEducation = new Button();
            buttonProfile = new Button();
            panelForImage = new Panel();
            plane.SuspendLayout();
            ActionBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // plane
            // 
            plane.BackColor = Color.Lavender;
            plane.BackgroundImage = Properties.Resources.фон;
            plane.BackgroundImageLayout = ImageLayout.Stretch;
            plane.Controls.Add(WorkPanel);
            plane.Controls.Add(ActionBarPanel);
            plane.Font = new Font("Georgia", 12F);
            plane.Location = new Point(0, 0);
            plane.Margin = new Padding(3, 4, 3, 4);
            plane.Name = "plane";
            plane.Size = new Size(868, 497);
            plane.TabIndex = 0;
            // 
            // WorkPanel
            // 
            WorkPanel.BackgroundImage = (Image)resources.GetObject("WorkPanel.BackgroundImage");
            WorkPanel.BackgroundImageLayout = ImageLayout.Stretch;
            WorkPanel.Font = new Font("Georgia", 12F);
            WorkPanel.Location = new Point(204, 4);
            WorkPanel.Margin = new Padding(3, 4, 3, 4);
            WorkPanel.Name = "WorkPanel";
            WorkPanel.Size = new Size(673, 499);
            WorkPanel.TabIndex = 1;
            // 
            // ActionBarPanel
            // 
            ActionBarPanel.BackColor = Color.AliceBlue;
            ActionBarPanel.BackgroundImage = (Image)resources.GetObject("ActionBarPanel.BackgroundImage");
            ActionBarPanel.BackgroundImageLayout = ImageLayout.Stretch;
            ActionBarPanel.Controls.Add(buttonDataBase);
            ActionBarPanel.Controls.Add(buttonIncidents);
            ActionBarPanel.Controls.Add(buttonEducation);
            ActionBarPanel.Controls.Add(buttonProfile);
            ActionBarPanel.Controls.Add(panelForImage);
            ActionBarPanel.Font = new Font("Georgia", 12F);
            ActionBarPanel.Location = new Point(-8, 4);
            ActionBarPanel.Margin = new Padding(3, 4, 3, 4);
            ActionBarPanel.Name = "ActionBarPanel";
            ActionBarPanel.Size = new Size(219, 495);
            ActionBarPanel.TabIndex = 0;
            // 
            // buttonDataBase
            // 
            buttonDataBase.BackgroundImage = Properties.Resources.коричневый2;
            buttonDataBase.BackgroundImageLayout = ImageLayout.Stretch;
            buttonDataBase.Font = new Font("Georgia", 10.8F, FontStyle.Bold);
            buttonDataBase.ForeColor = Color.FromArgb(64, 64, 64);
            buttonDataBase.Location = new Point(11, 280);
            buttonDataBase.Margin = new Padding(3, 4, 3, 4);
            buttonDataBase.Name = "buttonDataBase";
            buttonDataBase.Size = new Size(195, 50);
            buttonDataBase.TabIndex = 5;
            buttonDataBase.Text = "База данных";
            buttonDataBase.UseVisualStyleBackColor = true;
            buttonDataBase.Click += buttonDataBase_Click;
            // 
            // buttonIncidents
            // 
            buttonIncidents.BackgroundImage = Properties.Resources.коричневый2;
            buttonIncidents.BackgroundImageLayout = ImageLayout.Stretch;
            buttonIncidents.Font = new Font("Georgia", 10.8F, FontStyle.Bold);
            buttonIncidents.ForeColor = Color.FromArgb(64, 64, 64);
            buttonIncidents.Location = new Point(11, 232);
            buttonIncidents.Margin = new Padding(3, 4, 3, 4);
            buttonIncidents.Name = "buttonIncidents";
            buttonIncidents.Size = new Size(195, 50);
            buttonIncidents.TabIndex = 4;
            buttonIncidents.Text = "Мероприятия";
            buttonIncidents.UseVisualStyleBackColor = true;
            buttonIncidents.Click += buttonIncidents_Click;
            // 
            // buttonEducation
            // 
            buttonEducation.BackgroundImage = Properties.Resources.коричневый2;
            buttonEducation.BackgroundImageLayout = ImageLayout.Stretch;
            buttonEducation.Font = new Font("Georgia", 10.8F, FontStyle.Bold);
            buttonEducation.ForeColor = Color.FromArgb(64, 64, 64);
            buttonEducation.Location = new Point(11, 184);
            buttonEducation.Margin = new Padding(3, 4, 3, 4);
            buttonEducation.Name = "buttonEducation";
            buttonEducation.Size = new Size(195, 50);
            buttonEducation.TabIndex = 3;
            buttonEducation.Text = "Обучение";
            buttonEducation.UseVisualStyleBackColor = true;
            buttonEducation.Click += buttonEducation_Click;
            // 
            // buttonProfile
            // 
            buttonProfile.BackgroundImage = Properties.Resources.коричневый2;
            buttonProfile.BackgroundImageLayout = ImageLayout.Stretch;
            buttonProfile.Font = new Font("Georgia", 10.8F, FontStyle.Bold);
            buttonProfile.ForeColor = Color.FromArgb(64, 64, 64);
            buttonProfile.Location = new Point(11, 136);
            buttonProfile.Margin = new Padding(3, 4, 3, 4);
            buttonProfile.Name = "buttonProfile";
            buttonProfile.Size = new Size(195, 50);
            buttonProfile.TabIndex = 2;
            buttonProfile.Text = "Профиль";
            buttonProfile.UseVisualStyleBackColor = true;
            buttonProfile.Click += buttonProfile_Click;
            // 
            // panelForImage
            // 
            panelForImage.BackgroundImage = (Image)resources.GetObject("panelForImage.BackgroundImage");
            panelForImage.BackgroundImageLayout = ImageLayout.Stretch;
            panelForImage.Font = new Font("Georgia", 12F);
            panelForImage.Location = new Point(20, 8);
            panelForImage.Margin = new Padding(3, 4, 3, 4);
            panelForImage.Name = "panelForImage";
            panelForImage.Size = new Size(83, 74);
            panelForImage.TabIndex = 0;
            panelForImage.Paint += panelForImage_Paint;
            // 
            // MainUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 495);
            Controls.Add(plane);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainUserForm";
            Text = "MainUserForm";
            Load += MainUserForm_Load;
            plane.ResumeLayout(false);
            ActionBarPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel plane;
        private Panel ActionBarPanel;
        private Panel panelForImage;
        private Button buttonIncidents;
        private Button buttonEducation;
        private Button buttonProfile;
        private Button buttonDataBase;
        private Panel WorkPanel;
    }
}