using Krypton.Toolkit;
using System;
using System.Diagnostics;
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



        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(kryptonTextBox2.Text))
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Mã!");
            }
            else
            {
                string tempPath = Path.GetTempPath();
                string tempFile = Path.Combine(tempPath, "codezrok.tmp");
                string batchFilePath = Path.Combine(Share.AP, "connect.bat");

                // Kiểm tra nếu file đã tồn tại
                if (File.Exists(tempFile))
                {
                    // Xóa nội dung file
                    File.WriteAllText(tempFile, string.Empty);
                }

                // Ghi nội dung từ kryptonTextBox2.Text vào file
                File.WriteAllText(tempFile, kryptonTextBox2.Text);

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
        }
    }
}
