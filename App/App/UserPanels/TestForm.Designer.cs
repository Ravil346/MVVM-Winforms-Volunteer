namespace App.UserPanels
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            panel1 = new Panel();
            title = new Label();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            buttonExit = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(title);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(206, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(131, 120);
            panel1.TabIndex = 0;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            title.ForeColor = Color.Black;
            title.Location = new Point(26, 75);
            title.Name = "title";
            title.Size = new Size(75, 29);
            title.TabIndex = 5;
            title.Text = "Вход";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(15, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(343, 111);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 1;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.White;
            buttonExit.BackgroundImage = (Image)resources.GetObject("buttonExit.BackgroundImage");
            buttonExit.BackgroundImageLayout = ImageLayout.Stretch;
            buttonExit.Location = new Point(12, 2);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(40, 40);
            buttonExit.TabIndex = 10;
            buttonExit.UseVisualStyleBackColor = false;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 406);
            Controls.Add(buttonExit);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "TestForm";
            Text = "TestForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label title;
        private DataGridView dataGridView1;
        private Button buttonExit;
    }
}