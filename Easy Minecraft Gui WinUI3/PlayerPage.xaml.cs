using Easy_Minecraft_Server_Gui;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Easy_Minecraft_Gui_WinUI3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayerPage : Page
    {
        private Process cmd;
        private bool StopClick = false;
        public PlayerPage()
        {
            this.InitializeComponent();
            ZrokCode.Text = Share.zrokcode();
        }


        private async void Run_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ServerCode.Text))
            {
                int count = 0;
                Run.IsEnabled = false;
                ServerCode.IsEnabled = false;
                Loader.Visibility = Visibility.Visible;

                string serverCode = ServerCode.Text; // Lưu giá trị vào biến

                try
                {
                    cmd = new Process();
                    cmd.StartInfo.FileName = Path.Combine(Share.AP, "zrok.exe");
                    cmd.StartInfo.Arguments = $"access private {serverCode}";
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.StartInfo.WorkingDirectory = Share.AP;
                    cmd.StartInfo.StandardOutputEncoding = Encoding.UTF8;

                    cmd.Start();

                    StringBuilder outputBuilder = new StringBuilder();

                    // Đọc đầu ra dòng một cách liên tục
                    while (cmd != null && !cmd.HasExited) // Kiểm tra xem cmd có khác null và chưa thoát
                    {
                        string line = await cmd.StandardOutput.ReadLineAsync(); // Đọc dòng đầu ra

                        if (line != null)
                        {
                            // Lọc bỏ các ký tự không phải ASCII
                            string filteredLine = Regex.Replace(line, @"[^\u0000-\u007F]", string.Empty);
                            count++;
                            if (count > 2)
                            {
                                outputBuilder.AppendLine(filteredLine);
                            }
                            // Cập nhật giao diện người dùng
                            var run = new Run { Text = outputBuilder.ToString() };
                            DispatcherQueue.TryEnqueue(() =>
                            {
                                myParagraph.Inlines.Clear();
                                myParagraph.Inlines.Add(run);
                            });
                        }
                        Stop.IsEnabled = true;
                        StatusCode.Text = "Đang Chạy (IP Server: 127.0.0.1:9191)";
                        Share.iszrokrun = true;
                    }

                    if (StopClick!=true) // Kiểm tra nếu cmd đã thoát
                    {
                        await Share.ShowDialogAsync("Lỗi: Vui lòng kiểm tra lại Mã Của Bạn.", XamlRoot);
                    }

                    Stop.IsEnabled = false;
                    Loader.Visibility = Visibility.Collapsed;
                    ServerCode.IsEnabled = true;
                    Run.IsEnabled = true;
                    myParagraph.Inlines.Clear();
                    StatusCode.Text = "Đã Tắt";
                    StopClick = false;
                    Share.iszrokrun = false;
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu cần thiết
                    await Share.ShowDialogAsync("Đã xảy ra lỗi: " + ex.Message, XamlRoot);
                }
            }
            else
            {
                await Share.ShowDialogAsync("Vui Lòng Nhập Đầy Đủ Thông Tin", XamlRoot);
            }
        }


        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            StopClick = true;
            if (cmd != null) // Kiểm tra xem cmd có khác null không
            {
                if (!cmd.HasExited) // Kiểm tra xem quy trình có đang chạy không
                {
                    cmd.Kill(); // Tắt quy trình
                }

                cmd.Dispose(); // Giải phóng tài nguyên
                cmd = null; // Đặt cmd về null để tránh lỗi sau này
                StatusCode.Text = "Đã Tắt"; // Cập nhật trạng thái
            }
        }
    }
}
