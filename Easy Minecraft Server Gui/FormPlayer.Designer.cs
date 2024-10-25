namespace Easy_Minecraft_Server_Gui
{
    partial class FormPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlayer));
            label1 = new Label();
            kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            kryptonTextBox2 = new Krypton.Toolkit.KryptonTextBox();
            kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            kryptonPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 22.2545452F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(624, 46);
            label1.TabIndex = 2;
            label1.Text = "Nhập Mã Mà Chủ Server Gửi Cho Bạn:";
            // 
            // kryptonButton1
            // 
            kryptonButton1.Location = new Point(209, 190);
            kryptonButton1.Name = "kryptonButton1";
            kryptonButton1.Size = new Size(243, 42);
            kryptonButton1.TabIndex = 3;
            kryptonButton1.Values.Text = "Kết Nối!";
            kryptonButton1.Click += kryptonButton1_Click;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            kryptonLabel1.Location = new Point(12, 276);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(129, 23);
            kryptonLabel1.TabIndex = 4;
            kryptonLabel1.Values.Text = "Mã Zrok Của Bạn:";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            kryptonLabel2.Location = new Point(137, 276);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(36, 23);
            kryptonLabel2.TabIndex = 5;
            kryptonLabel2.TabStop = false;
            kryptonLabel2.Values.Text = "Lỗi!";
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(95, 152);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(464, 23);
            kryptonLabel4.TabIndex = 10;
            kryptonLabel4.Values.Text = "Lưu Ý: Máy Của Người Chơi Và Máy Chủ Phải Cùng Code Mới Chơi Được";
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(kryptonTextBox2);
            kryptonPanel1.Controls.Add(kryptonLabel4);
            kryptonPanel1.Controls.Add(kryptonLabel2);
            kryptonPanel1.Controls.Add(kryptonLabel1);
            kryptonPanel1.Controls.Add(kryptonButton1);
            kryptonPanel1.Controls.Add(label1);
            kryptonPanel1.Dock = DockStyle.Fill;
            kryptonPanel1.Location = new Point(0, 0);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(651, 307);
            kryptonPanel1.TabIndex = 0;
            // 
            // kryptonTextBox2
            // 
            kryptonTextBox2.Location = new Point(95, 102);
            kryptonTextBox2.Name = "kryptonTextBox2";
            kryptonTextBox2.Size = new Size(465, 26);
            kryptonTextBox2.TabIndex = 11;
            // 
            // kryptonTextBox1
            // 
            kryptonTextBox1.Location = new Point(99, 91);
            kryptonTextBox1.Name = "kryptonTextBox1";
            kryptonTextBox1.Size = new Size(465, 26);
            kryptonTextBox1.TabIndex = 0;
            // 
            // FormPlayer
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 307);
            Controls.Add(kryptonPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormPlayer";
            Text = "Player";
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).EndInit();
            kryptonPanel1.ResumeLayout(false);
            kryptonPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
    }
}