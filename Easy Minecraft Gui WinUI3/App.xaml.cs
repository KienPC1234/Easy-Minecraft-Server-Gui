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
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window m_window;
    }
}
