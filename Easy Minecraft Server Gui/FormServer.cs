using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Easy_Minecraft_Server_Gui
{
    public partial class FormServer : Form
    {
        private string port = "";
        private string ip = "Auto";
        private string mode = "Auto";

        public FormServer(string zrokcode)
        {
            string filePath = Path.Combine(Share.AP, "Data.json");
            InitializeComponent();
            if (!File.Exists(filePath))
            {
                CreateJsonFile(filePath);
            }
            else
            {
                // Read the file content
                string jsonContent = File.ReadAllText(filePath);
                JObject jsonData = JObject.Parse(jsonContent);

                // Check for existing variables
                if (!jsonData.ContainsKey("ServerPort") ||
                    !jsonData.ContainsKey("Mode") ||
                    !jsonData.ContainsKey("ipServer"))
                {
                    // Update file if any variable is missing
                    UpdateJsonFile(filePath);
                }
                else
                {
                    // Load existing settings
                    mode = jsonData["Mode"]?.ToString();
                    ip = jsonData["ipServer"]?.ToString();
                    port = jsonData["ServerPort"]?.ToString();

                    selectItem(mode);

                    if (mode != "Auto")
                    {
                        kryptonTextBox1.Text = ip;
                    }
                    kryptonTextBox2.Text = port;
                }
            }
            if (zrokcode == "ixd88rZAdaue")
            {
                kryptonLabel4.Text = zrokcode + " (Đây Là Mã Công Cộng, Lưu ý Khi Sử Dụng!)";
            }
            else
            {
                kryptonLabel4.Text = zrokcode;
            }
            // Automatically set IPv4 address if mode is Auto
            if (kryptonComboBox1.Text == "Auto")
            {
                kryptonTextBox1.Enabled = false;
                SetIPv4Address();
            }
        }

        private void SetIPv4Address()
        {
            string ipv4Address = Share.GetIPv4Address();
            if (ipv4Address != null)
            {
                kryptonTextBox1.Text = ipv4Address;
            }
            else
            {
                MessageBox.Show("Không tìm thấy địa chỉ IPv4.");
            }
        }

        void selectItem(string mode)
        {
            if (kryptonComboBox1.Items.Contains(mode))
            {
                kryptonComboBox1.SelectedItem = mode;
            }
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text != "Auto")
            {
                kryptonTextBox1.Enabled = true;
            }
            else
            {
                kryptonTextBox1.Enabled = false;
                SetIPv4Address();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (kryptonCheckBox1.Checked)
            {
                if (!string.IsNullOrEmpty(kryptonTextBox1.Text) && !string.IsNullOrEmpty(kryptonTextBox2.Text))
                {
                    string filePath = Path.Combine(Share.AP, "Data.json");
                    mode = kryptonComboBox1.Text;
                    port = kryptonTextBox2.Text;
                    ip = mode == "Auto" ? "Auto" : kryptonTextBox1.Text;

                    // Update the JSON file
                    UpdateJsonFile(filePath);
                    OpenServer();
                }
                else
                {
                    MessageBox.Show("Lỗi: Vùi Lòng Nhập Đầy Đủ IP và Port!");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(kryptonTextBox1.Text) && !string.IsNullOrEmpty(kryptonTextBox2.Text))
                {
                    OpenServer();
                }
                else
                {
                    MessageBox.Show("Lỗi: Vùi Lòng Nhập Đầy Đủ IP và Port!");
                }
            }
            
        }

        void OpenServer()
        {
            string tempPath = Path.GetTempPath();
            string tempFile = Path.Combine(tempPath, "serverIP.tmp");
            string batchFilePath = Path.Combine(Share.AP, "serverOpen.bat");

            // Kiểm tra nếu file đã tồn tại
            if (File.Exists(tempFile))
            {
                // Xóa nội dung file
                File.WriteAllText(tempFile, string.Empty);
            }

            // Ghi nội dung từ kryptonTextBox2.Text vào file
            File.WriteAllText(tempFile, kryptonTextBox1.Text+":"+kryptonTextBox2.Text);

            // Kiểm tra nếu file batch tồn tại trước khi chạy
            if (File.Exists(batchFilePath))
            {
                Process.Start(batchFilePath);
            }
            else
            {
                MessageBox.Show("File connect.bat Lỗi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }
        void CreateJsonFile(string filePath)
        {
            var jsonData = new JObject
            {
                { "ServerPort", port },
                { "Mode", mode },
                { "ipServer", ip }
            };

            File.WriteAllText(filePath, jsonData.ToString(Newtonsoft.Json.Formatting.Indented));
        }

        void UpdateJsonFile(string filePath)
        {
            // Read file content
            string json = File.ReadAllText(filePath);
            var jsonObject = JObject.Parse(json);

            // Update variables
            jsonObject["ServerPort"] = port;
            jsonObject["Mode"] = mode;
            jsonObject["ipServer"] = ip;

            // Write back to the file
            File.WriteAllText(filePath, jsonObject.ToString(Newtonsoft.Json.Formatting.Indented));
        }
    }
}
