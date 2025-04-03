namespace App.ViewModel.WorkForm
{
    partial class AddModuleForm
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
            labelQuantityTask = new Label();
            buttonOk = new Button();
            planeForTypeAttribute = new Panel();
            label1 = new Label();
            textName = new TextBox();
            title = new Label();
            plane.SuspendLayout();
            SuspendLayout();
            // 
            // plane
            // 
            plane.BackColor = Color.Lavender;
            plane.BackgroundImage = Properties.Resources.фон;
            plane.BackgroundImageLayout = ImageLayout.Stretch;
            plane.Controls.Add(labelQuantityTask);
            plane.Controls.Add(buttonOk);
            plane.Controls.Add(planeForTypeAttribute);
            plane.Controls.Add(label1);
            plane.Controls.Add(textName);
            plane.Controls.Add(title);
            plane.Location = new Point(0, 1);
            plane.Margin = new Padding(3, 4, 3, 4);
            plane.Name = "plane";
            plane.Size = new Size(876, 503);
            plane.TabIndex = 0;
            // 
            // labelQuantityTask
            // 
            labelQuantityTask.AutoSize = true;
            labelQuantityTask.BackColor = Color.Transparent;
            labelQuantityTask.Font = new Font("Georgia", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelQuantityTask.ForeColor = Color.Black;
            labelQuantityTask.Location = new Point(496, 91);
            labelQuantityTask.Name = "labelQuantityTask";
            labelQuantityTask.Size = new Size(259, 27);
            labelQuantityTask.TabIndex = 20;
            labelQuantityTask.Text = "Количество заданий: 0";
            // 
            // buttonOk
            // 
            buttonOk.BackgroundImage = Properties.Resources.оранжевый;
            buttonOk.BackgroundImageLayout = ImageLayout.Stretch;
            buttonOk.Font = new Font("Georgia", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonOk.ForeColor = Color.White;
            buttonOk.Location = new Point(352, 415);
            buttonOk.Margin = new Padding(3, 4, 3, 4);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(190, 54);
            buttonOk.TabIndex = 19;
            buttonOk.Text = "Добавить";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // planeForTypeAttribute
            // 
            planeForTypeAttribute.AutoScroll = true;
            planeForTypeAttribute.Location = new Point(129, 136);
            planeForTypeAttribute.Margin = new Padding(3, 4, 3, 4);
            planeForTypeAttribute.Name = "planeForTypeAttribute";
            planeForTypeAttribute.Size = new Size(626, 271);
            planeForTypeAttribute.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Georgia", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(129, 91);
            label1.Name = "label1";
            label1.Size = new Size(117, 27);
            label1.TabIndex = 8;
            label1.Text = "Название";
            // 
            // textName
            // 
            textName.Location = new Point(262, 91);
            textName.Margin = new Padding(3, 4, 3, 4);
            textName.Name = "textName";
            textName.Size = new Size(203, 27);
            textName.TabIndex = 7;
            // 
            // title
            // 
            title.AutoSize = true;
            title.BackColor = Color.Transparent;
            title.Font = new Font("Georgia", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title.ForeColor = Color.Black;
            title.Location = new Point(277, 27);
            title.Name = "title";
            title.Size = new Size(313, 32);
            title.TabIndex = 6;
            title.Text = "Добавление модуля";
            // 
            // AddModuleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 495);
            Controls.Add(plane);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "AddModuleForm";
            Text = "AddModuleForm";
            Load += AddModuleForm_Load;
            plane.ResumeLayout(false);
            plane.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel plane;
        private Label label1;
        private TextBox textName;
        private Label title;
        private Panel planeForTypeAttribute;
        private Button buttonOk;
        private Label labelQuantityTask;
    }
}