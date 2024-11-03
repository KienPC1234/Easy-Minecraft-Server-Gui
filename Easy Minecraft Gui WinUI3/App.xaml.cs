using Microsoft.UI.Windowing;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinRT.Interop;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Easy_Minecraft_Server_Gui;
using Windows.Foundation.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Easy_Minecraft_Gui_WinUI3
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            Current.UnhandledException += Current_UnhandledException;

        }


        private void Current_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            // Hiển thị thông báo
            Share.ShowNotification("Ứng Dụng Bị Lỗi (Vui Lòng Gửi Lỗi Cho Nhà Phát Triển)", e.Message + "\n" + "Mã Lỗi: " + e.Exception);

            Process.Start(new ProcessStartInfo("https://github.com/KienPC1234/Easy-Minecraft-Server-Gui/issues") { UseShellExecute = true });
            // Tạo file text để lưu thông tin lỗi
            string fileName = "ErrorLog.txt";
            string filePath = Path.Combine(Share.AP, fileName);

            // Nội dung sẽ được ghi vào file
            string content = $"Ứng Dụng Bị Lỗi\n{e.Message}\nMã Lỗi: {e.Exception}";

            // Ghi nội dung vào file
            File.WriteAllText(filePath, content);

            // Mở file sau khi ghi
            Process.Start(new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            });

            e.Handled = true; // Đánh dấu lỗi là đã được xử lý
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            Settings.InitializeSettingsFile();
            bool Isconnect = await NetworkChecker.IsConnectedToZrokApi();
            if (Isconnect != true)
            {
                Share.ShowNotification("Lỗi","Không Thể Kết Nối Với Server Zrok, Vui lòng Kiểm Tra Lại Mạng!");
                Current.Exit();
            }
            if (File.Exists(Path.Combine(Share.AP, "Checker.tmp")) == false)
            {
                Share.ShowNotification("Thông Báo","Đây Là Lần Chạy Đầu Tiên Của Bạn, Vui Lòng Chờ Vài Phút Để Chúng Tôi Setup Cho Bạn...");

                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.WorkingDirectory = Share.AP;

                cmd.Start();

                using (StreamWriter inputWriter = cmd.StandardInput)
                {
                    if (inputWriter.BaseStream.CanWrite)
                    {
                        inputWriter.WriteLine("zrok.exe disable");
                        inputWriter.WriteLine("zrok.exe enable ixd88rZAdaue");
                        inputWriter.WriteLine("exit");
                    }
                }
                string output = cmd.StandardOutput.ReadToEnd();
                cmd.WaitForExit();
                string logFilePath = Path.Combine(Share.AP, "CMD_LOG.txt");
                File.WriteAllText(logFilePath, output);
                if (!output.Contains("the zrok environment was successfully enabled"))
                {
                    Share.ShowNotification("Lỗi", "Vui Lòng Check File Log CMD_LOG.txt!\n \n" + output);
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = logFilePath,
                        UseShellExecute = true
                    });
                    Current.Exit();
                }
                File.Create(Path.Combine(Share.AP, "Checker.tmp"));
            }
            checkZrok();
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window m_window;
        private void checkZrok()
        {
            var setting = Settings.LoadSettings();
            string zrokcode = setting.Zrokcode;
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.WorkingDirectory = Share.AP;

            cmd.Start();

            using (StreamWriter inputWriter = cmd.StandardInput)
            {
                if (inputWriter.BaseStream.CanWrite)
                {
                    inputWriter.WriteLine($"zrok.exe enable {zrokcode}");
                    inputWriter.WriteLine("exit");
                }
            }
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();
        }

    }
}
