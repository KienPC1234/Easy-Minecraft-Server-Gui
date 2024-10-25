using Newtonsoft.Json.Linq;

namespace Easy_Minecraft_Server_Gui
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            #region CheckJson
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data.json");

            if (File.Exists(jsonFilePath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(jsonFilePath);

                    JObject jsonData = JObject.Parse(jsonContent);

                    theme = jsonData["theme"]?.ToString();
                    zrokcode = jsonData["zrokcode"]?.ToString();
                    foreach (var item in new FormSetting().kryptonThemeComboBox1.Items)
                    {
                        if (item.ToString() == theme)
                        {
                            new FormSetting().kryptonThemeComboBox1.SelectedItem = item;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi khi đọc JSON: " + ex.Message);
                }
            }
            #endregion
            InitializeComponent();
        }

        public string zrokcode;
        public string theme;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void toolStripButton1_Click(object sender, EventArgs e) => new FormSetting(theme).ShowDialog();

        private void infoToolStripMenuItem_Click(object sender, EventArgs e) => new FormInfo().ShowDialog();


        private void kryptonHeader1_Click(object sender, EventArgs e) => new FormPlayer(zrokcode).ShowDialog();

        private void kryptonHeader1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonHeader2_Click(object sender, EventArgs e) => new FormServer(zrokcode).ShowDialog();

        private void kryptonButton1_Click(object sender, EventArgs e) => new FormImage(Path.Combine(Share.AP, "help2.png")).ShowDialog();

        private void kryptonButton2_Click(object sender, EventArgs e) => new FormImage(Path.Combine(Share.AP, "help3.png")).ShowDialog();
    }
}
