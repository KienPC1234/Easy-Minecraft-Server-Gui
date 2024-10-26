namespace Easy_Minecraft_Server_Gui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            kryptonHeader2 = new Krypton.Toolkit.KryptonHeader();
            kryptonHeader1 = new Krypton.Toolkit.KryptonHeader();
            label1 = new Label();
            kryptonToolStrip1 = new Krypton.Toolkit.KryptonToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            exitToolStripMenuItem = new ToolStripMenuItem();
            infoToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton1 = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            kryptonPanel1.SuspendLayout();
            kryptonToolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(kryptonButton2);
            kryptonPanel1.Controls.Add(kryptonButton1);
            kryptonPanel1.Controls.Add(kryptonHeader2);
            kryptonPanel1.Controls.Add(kryptonHeader1);
            kryptonPanel1.Controls.Add(label1);
            kryptonPanel1.Controls.Add(kryptonToolStrip1);
            kryptonPanel1.Dock = DockStyle.Fill;
            kryptonPanel1.Location = new Point(0, 0);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(580, 303);
            kryptonPanel1.TabIndex = 0;
            // 
            // kryptonButton2
            // 
            kryptonButton2.Location = new Point(388, 172);
            kryptonButton2.Name = "kryptonButton2";
            kryptonButton2.Size = new Size(36, 38);
            kryptonButton2.TabIndex = 5;
            kryptonButton2.Values.Image = Properties.Resources.question;
            kryptonButton2.Values.Text = "kryptonButton2";
            kryptonButton2.Click += kryptonButton2_Click;
            // 
            // kryptonButton1
            // 
            kryptonButton1.Location = new Point(454, 115);
            kryptonButton1.Name = "kryptonButton1";
            kryptonButton1.Size = new Size(36, 38);
            kryptonButton1.TabIndex = 4;
            kryptonButton1.Values.Image = Properties.Resources.question;
            kryptonButton1.Values.Text = "kryptonButton1";
            kryptonButton1.Click += kryptonButton1_Click;
            // 
            // kryptonHeader2
            // 
            kryptonHeader2.Location = new Point(143, 172);
            kryptonHeader2.Name = "kryptonHeader2";
            kryptonHeader2.Size = new Size(239, 37);
            kryptonHeader2.TabIndex = 3;
            kryptonHeader2.Values.Description = "";
            kryptonHeader2.Values.Heading = "Người Tạo Server";
            kryptonHeader2.Values.Image = Properties.Resources.cloud_server;
            kryptonHeader2.Click += kryptonHeader2_Click;
            // 
            // kryptonHeader1
            // 
            kryptonHeader1.Location = new Point(82, 115);
            kryptonHeader1.Name = "kryptonHeader1";
            kryptonHeader1.Size = new Size(366, 37);
            kryptonHeader1.TabIndex = 2;
            kryptonHeader1.Values.Description = "";
            kryptonHeader1.Values.Heading = "Người Chơi Muốn Vào Server";
            kryptonHeader1.Values.Image = Properties.Resources.joystick1;
            kryptonHeader1.Click += kryptonHeader1_Click;
            kryptonHeader1.Paint += kryptonHeader1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 28.1454544F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(200, 40);
            label1.Name = "label1";
            label1.Size = new Size(185, 62);
            label1.TabIndex = 1;
            label1.Text = "Bạn Là:";
            // 
            // kryptonToolStrip1
            // 
            kryptonToolStrip1.Font = new Font("Segoe UI", 9F);
            kryptonToolStrip1.ImageScalingSize = new Size(18, 18);
            kryptonToolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripButton1 });
            kryptonToolStrip1.Location = new Point(0, 0);
            kryptonToolStrip1.Name = "kryptonToolStrip1";
            kryptonToolStrip1.Size = new Size(580, 27);
            kryptonToolStrip1.TabIndex = 0;
            kryptonToolStrip1.Text = "kryptonToolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem, infoToolStripMenuItem });
            toolStripDropDownButton1.Image = Properties.Resources.folder;
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(64, 24);
            toolStripDropDownButton1.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = Properties.Resources.logout;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(118, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // infoToolStripMenuItem
            // 
            infoToolStripMenuItem.Image = Properties.Resources.info;
            infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            infoToolStripMenuItem.Size = new Size(118, 26);
            infoToolStripMenuItem.Text = "Info";
            infoToolStripMenuItem.Click += infoToolStripMenuItem_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = Properties.Resources.cogwheel;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(78, 24);
            toolStripButton1.Text = "Setting";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 303);
            Controls.Add(kryptonPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Easy Minecraft Server";
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).EndInit();
            kryptonPanel1.ResumeLayout(false);
            kryptonPanel1.PerformLayout();
            kryptonToolStrip1.ResumeLayout(false);
            kryptonToolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonToolStrip kryptonToolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private ToolStripMenuItem infoToolStripMenuItem;
        private Label label1;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonHeader kryptonHeader2;
        private Krypton.Toolkit.KryptonHeader kryptonHeader1;
    }
}
