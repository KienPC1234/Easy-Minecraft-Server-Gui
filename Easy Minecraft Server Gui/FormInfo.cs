using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Easy_Minecraft_Server_Gui
{
    public partial class FormInfo : Form
    {
        public FormInfo()
        {

            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/KienPC1234") { UseShellExecute = true });
        }

        private void kryptonLabel1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://zrok.io/") { UseShellExecute = true });
        }
    }
}
