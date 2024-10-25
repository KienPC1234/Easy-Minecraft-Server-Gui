namespace Easy_Minecraft_Server_Gui
{
    partial class FormInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfo));
            kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            label1 = new Label();
            kryptonToolkitPoweredByControl1 = new Krypton.Toolkit.KryptonToolkitPoweredByControl();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            kryptonPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(kryptonLabel1);
            kryptonPanel1.Controls.Add(kryptonButton1);
            kryptonPanel1.Controls.Add(label1);
            kryptonPanel1.Controls.Add(kryptonToolkitPoweredByControl1);
            kryptonPanel1.Dock = DockStyle.Fill;
            kryptonPanel1.Location = new Point(0, 0);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(768, 332);
            kryptonPanel1.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            kryptonLabel1.Location = new Point(4, 259);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(637, 44);
            kryptonLabel1.TabIndex = 3;
            kryptonLabel1.Values.Text = "Phần mềm này sử dụng công nghệ từ Zrok để cung cấp khả năng mở server Minecraft \r\ntừ xa một cách dễ dàng. Để biết thêm thông tin, vui lòng truy cập Zrok.";
            kryptonLabel1.Click += kryptonLabel1_Click;
            // 
            // kryptonButton1
            // 
            kryptonButton1.Location = new Point(459, 212);
            kryptonButton1.Name = "kryptonButton1";
            kryptonButton1.Size = new Size(103, 31);
            kryptonButton1.TabIndex = 2;
            kryptonButton1.Values.Text = "Link Github";
            kryptonButton1.Click += kryptonButton1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 212);
            label1.Name = "label1";
            label1.Size = new Size(449, 31);
            label1.TabIndex = 1;
            label1.Text = "Phần Mềm Được Phát Triển Bởi KCD DEV";
            // 
            // kryptonToolkitPoweredByControl1
            // 
            kryptonToolkitPoweredByControl1.Location = new Point(4, 14);
            kryptonToolkitPoweredByControl1.Margin = new Padding(4);
            kryptonToolkitPoweredByControl1.Name = "kryptonToolkitPoweredByControl1";
            kryptonToolkitPoweredByControl1.Size = new Size(755, 182);
            kryptonToolkitPoweredByControl1.TabIndex = 0;
            kryptonToolkitPoweredByControl1.ToolkitType = Krypton.Toolkit.ToolkitType.Stable;
            // 
            // FormInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 332);
            Controls.Add(kryptonPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormInfo";
            Text = "Info";
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).EndInit();
            kryptonPanel1.ResumeLayout(false);
            kryptonPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Label label1;
        private Krypton.Toolkit.KryptonToolkitPoweredByControl kryptonToolkitPoweredByControl1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}