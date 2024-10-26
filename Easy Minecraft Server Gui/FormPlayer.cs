using Krypton.Toolkit;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Easy_Minecraft_Server_Gui
{
    public partial class FormPlayer : Form
    {
        public FormPlayer(string zrokcode)
        {
            InitializeComponent();
            if (zrokcode == "ixd88rZAdaue")
            {
                kryptonLabel2.Text = zrokcode + " (Đây Là Mã Công Cộng, Lưu ý Khi Sử Dụng!)";
            }
            else
            {
                kryptonLabel2.Text = zrokcode;
            }
        }



        private async void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(kryptonTextBox2.Text))
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Mã!");
            }
            else
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(Share.AP, "zrok.exe"),
                    Arguments = $"access private {kryptonTextBox2.Text}",
                    UseShellExecute = true
                };

                // Ẩn form
                this.Hide();

                // Khởi chạy tiến trình
                using (Process process = Process.Start(processInfo))
                {
                    if (process != null)
                    {
                        // Chờ tiến trình zrok.exe kết thúc
                        await Task.Run(() => process.WaitForExit());

                        // Kiểm tra ExitCode
                        int exitCode = process.ExitCode;
                        if (exitCode == 1)
                        {
                            MessageBox.Show($"Mã Bị Sai Vui Lòng Xem Lại, ExitCode: {exitCode}");
                            this.Show(); // Hiện lại form
                            return; // Kết thúc hàm nếu có lỗi
                        }
                    }
                }

                // Nếu không có lỗi, hiện lại form
                this.Show();
            }
        }
    }
}
