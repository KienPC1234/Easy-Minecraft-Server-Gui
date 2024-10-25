using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Easy_Minecraft_Server_Gui
{
    public partial class FormSetting : Form
    {
        private string jsonFilePath;

        public FormSetting(string theme = "")
        {
            InitializeComponent();
            jsonFilePath = Path.Combine(Share.AP, "Data.json");
            LoadSettings(theme);
        }

        private void LoadSettings(string theme)
        {
            // Load existing settings from the JSON file if it exists
            if (File.Exists(jsonFilePath))
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                JObject jsonData = JObject.Parse(jsonContent);

                // Set the theme if it exists in the JSON
                kryptonThemeComboBox1.SelectedItem = jsonData["theme"]?.ToString();

                // Set the zrokcode if it exists in the JSON
                kryptonTextBox1.Text = jsonData["zrokcode"]?.ToString();
            }
            else
            {
                // If the file doesn't exist, initialize it with default values
                CreateJsonFile();
            }

            // Set the selected theme from the parameter
            foreach (var item in kryptonThemeComboBox1.Items)
            {
                if (item.ToString() == theme)
                {
                    kryptonThemeComboBox1.SelectedItem = item;
                    break;
                }
            }
        }

        private void CreateJsonFile()
        {
            var jsonData = new JObject
            {
                { "theme", "Microsoft 365 - Blue" }, // Set a default theme
                { "zrokcode", "ixd88rZAdaue" } // Initialize with an empty zrokcode
            };

            File.WriteAllText(jsonFilePath, jsonData.ToString(Formatting.Indented));
        }

        private void UpdateJsonFile()
        {
            // Check if the file exists before updating
            if (File.Exists(jsonFilePath))
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                var jsonData = JObject.Parse(jsonContent);

                // Update the JSON object with new values
                jsonData["theme"] = kryptonThemeComboBox1.Text;
                jsonData["zrokcode"] = kryptonTextBox1.Text;

                // Write the updated JSON back to the file
                File.WriteAllText(jsonFilePath, jsonData.ToString(Formatting.Indented));
            }
            else
            {
                MessageBox.Show("File không tồn tại để cập nhật!");
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            var output = Share.Command(new[] { "zrok.exe disable", $"zrok.exe enable {kryptonTextBox1.Text}" });

            if (!output.Contains("the zrok environment was successfully enabled"))
            {
                MessageBox.Show("Lỗi, Vui Lòng Kiểm Tra Lại Code Của Bạn!");
                return;
            }

            UpdateJsonFile(); // Call the update method to save settings

            MessageBox.Show("Đã Lưu Thành Công");
            this.Close();
        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://myzrok.io/") { UseShellExecute = true });
        }

        private void kryptonLinkLabel2_LinkClicked(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://api.zrok.io/") { UseShellExecute = true });
        }

        private void kryptonButton2_Click(object sender, EventArgs e) => new FormImage(Path.Combine(Share.AP, "help1.png")).ShowDialog();
    }
}
