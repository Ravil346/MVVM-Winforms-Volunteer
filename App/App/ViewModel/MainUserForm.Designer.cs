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
            plane = new System.Windows.Forms.Panel();
            WorkPanel = new System.Windows.Forms.Panel();
            ActionBarPanel = new System.Windows.Forms.Panel();
            buttonDataBase = new System.Windows.Forms.Button();
            buttonIncidents = new System.Windows.Forms.Button();
            buttonEducation = new System.Windows.Forms.Button();
            buttonProfile = new System.Windows.Forms.Button();
            panelForImage = new System.Windows.Forms.Panel();
            plane.SuspendLayout();
            ActionBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // plane
            // 
            plane.BackColor = System.Drawing.Color.Lavender;
            plane.BackgroundImage = global::App.Properties.Resources.фон;
            plane.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            plane.Controls.Add(WorkPanel);
            plane.Controls.Add(ActionBarPanel);
            plane.Font = new System.Drawing.Font("Georgia", 12F);
            plane.Location = new System.Drawing.Point(0, 0);
            plane.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            plane.Name = "plane";
            plane.Size = new System.Drawing.Size(868, 497);
            plane.TabIndex = 0;
            // 
            // WorkPanel
            // 
            WorkPanel.BackgroundImage = ((System.Drawing.Image)resources.GetObject("WorkPanel.BackgroundImage"));
            WorkPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            WorkPanel.Font = new System.Drawing.Font("Georgia", 12F);
            WorkPanel.Location = new System.Drawing.Point(204, 4);
            WorkPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            WorkPanel.Name = "WorkPanel";
            WorkPanel.Size = new System.Drawing.Size(673, 499);
            WorkPanel.TabIndex = 1;
            WorkPanel.Paint += WorkPanel_Paint;
            // 
            // ActionBarPanel
            // 
            ActionBarPanel.BackColor = System.Drawing.Color.AliceBlue;
            ActionBarPanel.BackgroundImage = ((System.Drawing.Image)resources.GetObject("ActionBarPanel.BackgroundImage"));
            ActionBarPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ActionBarPanel.Controls.Add(buttonDataBase);
            ActionBarPanel.Controls.Add(buttonIncidents);
            ActionBarPanel.Controls.Add(buttonEducation);
            ActionBarPanel.Controls.Add(buttonProfile);
            ActionBarPanel.Controls.Add(panelForImage);
            ActionBarPanel.Font = new System.Drawing.Font("Georgia", 12F);
            ActionBarPanel.Location = new System.Drawing.Point(-8, 4);
            ActionBarPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ActionBarPanel.Name = "ActionBarPanel";
            ActionBarPanel.Size = new System.Drawing.Size(219, 495);
            ActionBarPanel.TabIndex = 0;
            // 
            // buttonDataBase
            // 
            buttonDataBase.BackgroundImage = global::App.Properties.Resources.коричневый2;
            buttonDataBase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            buttonDataBase.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Bold);
            buttonDataBase.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
            buttonDataBase.Location = new System.Drawing.Point(11, 280);
            buttonDataBase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonDataBase.Name = "buttonDataBase";
            buttonDataBase.Size = new System.Drawing.Size(195, 50);
            buttonDataBase.TabIndex = 5;
            buttonDataBase.Text = "База данных";
            buttonDataBase.UseVisualStyleBackColor = true;
            buttonDataBase.Click += buttonDataBase_Click;
            // 
            // buttonIncidents
            // 
            buttonIncidents.BackgroundImage = global::App.Properties.Resources.коричневый2;
            buttonIncidents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            buttonIncidents.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Bold);
            buttonIncidents.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
            buttonIncidents.Location = new System.Drawing.Point(11, 232);
            buttonIncidents.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonIncidents.Name = "buttonIncidents";
            buttonIncidents.Size = new System.Drawing.Size(195, 50);
            buttonIncidents.TabIndex = 4;
            buttonIncidents.Text = "Мероприятия";
            buttonIncidents.UseVisualStyleBackColor = true;
            buttonIncidents.Click += buttonIncidents_Click;
            // 
            // buttonEducation
            // 
            buttonEducation.BackgroundImage = global::App.Properties.Resources.коричневый2;
            buttonEducation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            buttonEducation.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Bold);
            buttonEducation.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
            buttonEducation.Location = new System.Drawing.Point(11, 184);
            buttonEducation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonEducation.Name = "buttonEducation";
            buttonEducation.Size = new System.Drawing.Size(195, 50);
            buttonEducation.TabIndex = 3;
            buttonEducation.Text = "Обучение";
            buttonEducation.UseVisualStyleBackColor = true;
            buttonEducation.Click += buttonEducation_Click;
            // 
            // buttonProfile
            // 
            buttonProfile.BackgroundImage = global::App.Properties.Resources.коричневый2;
            buttonProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            buttonProfile.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Bold);
            buttonProfile.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
            buttonProfile.Location = new System.Drawing.Point(11, 136);
            buttonProfile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonProfile.Name = "buttonProfile";
            buttonProfile.Size = new System.Drawing.Size(195, 50);
            buttonProfile.TabIndex = 2;
            buttonProfile.Text = "Профиль";
            buttonProfile.UseVisualStyleBackColor = true;
            buttonProfile.Click += buttonProfile_Click;
            // 
            // panelForImage
            // 
            panelForImage.BackgroundImage = ((System.Drawing.Image)resources.GetObject("panelForImage.BackgroundImage"));
            panelForImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelForImage.Font = new System.Drawing.Font("Georgia", 12F);
            panelForImage.Location = new System.Drawing.Point(20, 8);
            panelForImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelForImage.Name = "panelForImage";
            panelForImage.Size = new System.Drawing.Size(83, 74);
            panelForImage.TabIndex = 0;
            panelForImage.Paint += panelForImage_Paint;
            // 
            // MainUserForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(869, 495);
            Controls.Add(plane);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.Panel WorkPanel;
    }
}