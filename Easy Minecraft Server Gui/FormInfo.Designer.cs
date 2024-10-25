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
            kryptonToolkitPoweredByControl1 = new Krypton.Toolkit.KryptonToolkitPoweredByControl();
            label1 = new Label();
            kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            kryptonPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(kryptonButton1);
            kryptonPanel1.Controls.Add(label1);
            kryptonPanel1.Controls.Add(kryptonToolkitPoweredByControl1);
            kryptonPanel1.Dock = DockStyle.Fill;
            kryptonPanel1.Location = new Point(0, 0);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(768, 435);
            kryptonPanel1.TabIndex = 0;
            // 
            // kryptonToolkitPoweredByControl1
            // 
            kryptonToolkitPoweredByControl1.Location = new Point(4, 13);
            kryptonToolkitPoweredByControl1.Margin = new Padding(4, 4, 4, 4);
            kryptonToolkitPoweredByControl1.Name = "kryptonToolkitPoweredByControl1";
            kryptonToolkitPoweredByControl1.Size = new Size(755, 173);
            kryptonToolkitPoweredByControl1.TabIndex = 0;
            kryptonToolkitPoweredByControl1.ToolkitType = Krypton.Toolkit.ToolkitType.Stable;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 204);
            label1.Name = "label1";
            label1.Size = new Size(413, 30);
            label1.TabIndex = 1;
            label1.Text = "Phần Mềm Được Phát Triển Bởi KCD DEV";
            // 
            // kryptonButton1
            // 
            kryptonButton1.Location = new Point(447, 205);
            kryptonButton1.Name = "kryptonButton1";
            kryptonButton1.Size = new Size(103, 29);
            kryptonButton1.TabIndex = 2;
            kryptonButton1.Values.Text = "Link Github";
            kryptonButton1.Click += kryptonButton1_Click;
            // 
            // FormInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 435);
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
    }
}