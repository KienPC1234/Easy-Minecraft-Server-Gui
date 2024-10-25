using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Easy_Minecraft_Server_Gui
{
    public partial class FormImage : Form
    {
        public FormImage(string imgpath)
        {
            InitializeComponent();
            try
            {
                this.BackgroundImage = Image.FromFile(imgpath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
    }
}
