using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.UI.Xaml.Media.Animation;
using System.Text.RegularExpressions;
using Windows.UI.Popups;
using Easy_Minecraft_Server_Gui;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using Microsoft.UI.Xaml.Documents;
using System.Text;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Easy_Minecraft_Gui_WinUI3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ServerPage : Page
    {
        private bool StopClick = false;
        private Process cmd;
        public  ServerPage()
        {
            this.InitializeComponent();
            LoadSetting();
            ZrokCode.Text = Share.zrokcode();
        } 

        private void LoadSetting()
        {
            var st = Settings.LoadSettings();
            ComboBoxIP.SelectedIndex = (int)st.IPMode;
            if (st.IPMode==Settings.IPModeEnum.Auto)
            {
                try
                {
                    IpTextBox.Text = Share.GetIPv4Address();
                }
                catch (Exception ex)
                {
                    Share.ShowNotification("Lỗi!", ex.Message);
                }
            }
            else
            {
                IpTextBox.Text = st.ServerIP;
            }
            PortText.Text = st.ServerPort;
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DispatcherQueue.TryEnqueue(async () =>
            {
                await Task.Delay(200);

                if (ComboBoxIP != null && ComboBoxIP.SelectedItem != null)
                {
                    string SelectItem = ComboBoxIP.SelectedItem.ToString();

                    if (SelectItem == "Thủ Công")
                    {
                        // Hiển thị IpBox và chạy hiệu ứng xuất hiện
                        IpBox.Visibility = Visibility.Visible;

                        var fadeInAnimation = new FadeInThemeAnimation();
                        Storyboard.SetTarget(fadeInAnimation, IpBox);

                        var storyboard = new Storyboard();
                        storyboard.Children.Add(fadeInAnimation);
                        storyboard.Begin();
                    }
                    else
                    {
                        // Ẩn IpBox với hiệu ứng mờ dần
                        var fadeOutAnimation = new FadeOutThemeAnimation();
                        Storyboard.SetTarget(fadeOutAnimation, IpBox);

                        var storyboard = new Storyboard();
                        storyboard.Children.Add(fadeOutAnimation);
                        storyboard.Completed += (s, _) => IpBox.Visibility = Visibility.Collapsed;
                        storyboard.Begin();
                    }
                }
            });
        }

        private void IpTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = IpTextBox.Text;
            string pattern = @"^(\d{1,3}\.){3}\d{1,3}$";

            if (Regex.IsMatch(input, pattern))
            {
                string[] parts = input.Split('.');
                bool isValid = true;

                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int num))
                    {
                        if (num < 0 || num > 255)
                        {
                            isValid = false;
                            break;
                        }
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }

                if (!isValid)
                {
                    IpTextBox.BorderBrush = new SolidColorBrush(Microsoft.UI.Colors.Red);
                }
                else
                {
                    IpTextBox.BorderBrush = new SolidColorBrush(Microsoft.UI.Colors.Green);
                }
            }
            else
            {
                IpTextBox.BorderBrush = new SolidColorBrush(Microsoft.UI.Colors.Red);
            }
        }

        private void PortTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = PortText.Text;

            // Kiểm tra nếu input là một số hợp lệ
            if (int.TryParse(input, out int port))
            {
                // Kiểm tra xem port có nằm trong khoảng 0-65535 không
                if (port >= 0 && port <= 65535)
                {
                    // Nếu hợp lệ, đổi màu viền thành xanh
                    PortText.BorderBrush = new SolidColorBrush(Microsoft.UI.Colors.Green);
                }
                else
                {
                    // Nếu không hợp lệ, đổi màu viền thành đỏ
                    PortText.BorderBrush = new SolidColorBrush(Microsoft.UI.Colors.Red);
                }
            }
            else
            {
                // Nếu không phải số, đổi màu viền thành đỏ
                PortText.BorderBrush = new SolidColorBrush(Microsoft.UI.Colors.Red);
            }
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            Run.IsEnabled = false;
            ComboBoxIP.IsEnabled = false;
            IpTextBox.IsEnabled = false;
            PortText.IsEnabled = false;
            Loader.Visibility = Visibility.Visible;
            // Kiểm tra IP có hợp lệ hay không
            string ipInput = IpTextBox.Text;
            string ipPattern = @"^(\d{1,3}\.){3}\d{1,3}$";
            bool isIpValid = Regex.IsMatch(ipInput, ipPattern) && ipInput.Split('.').All(part =>
            {
                return int.TryParse(part, out int num) && num >= 0 && num <= 255;
            });

            // Kiểm tra Port có hợp lệ hay không
            string portInput = PortText.Text;
            bool isPortValid = int.TryParse(portInput, out int port) && port >= 0 && port <= 65535;
            // Simulate a process (e.g., connecting to server)
            // After the process is done, you can re-enable the button and hide the progress ring
            // For now, let's just simulate a delay
            DispatcherQueue.TryEnqueue(async () =>
            {

                if (string.IsNullOrEmpty(IpTextBox.Text) || string.IsNullOrEmpty(PortText.Text))
                {
                    await Share.ShowDialogAsync("Vui Lòng Nhập Đầy Đủ Thông Tin", base.XamlRoot);
                }
                else if (isIpValid == false || isPortValid == false)
                {
                    await Share.ShowDialogAsync("Vui Lòng Nhập Đúng Định Dạng!", base.XamlRoot);
                }
                else
                {
                    var ipserver = IpTextBox.Text + ":" + PortText;
                    //Xuly
                    try
                    {
                        cmd = new Process();
                        cmd.StartInfo.FileName = Path.Combine(Share.AP, "zrok.exe");
                        cmd.StartInfo.Arguments = $"share private --backend-mode tcpTunnel {ipserver}";
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
                                    Match match = Regex.Match(outputBuilder.ToString(), @"access private (\w+)\[PRIVATE\]");
                                    string result = match.Groups[1].Value;
                                    myParagraph.Inlines.Clear();
                                    myParagraph.Inlines.Add(run);
                                    StatusCode.Text = $"Server Đang Mở, Mã Code: {result}";
                                    sv.Visibility = Visibility.Visible;
                                    ServerCode.Text = result;
                                });
                            }
                            Share.iszrokrun = true;
                            Stop.IsEnabled = true;
                        }

                        if (StopClick != true) // Kiểm tra nếu cmd đã thoát
                        {
                            await Share.ShowDialogAsync("Lỗi: Vui lòng kiểm tra lại Mã Của Bạn.", XamlRoot);
                        }

                        Stop.IsEnabled = false;
                        Loader.Visibility = Visibility.Collapsed;
                        Run.IsEnabled = true;
                        myParagraph.Inlines.Clear();
                        StatusCode.Text = "Đã Tắt";
                        StopClick = false;
                        sv.Visibility = Visibility.Collapsed;
                        ServerCode.Text = "XXXXXXXXXXXX";
                        Share.iszrokrun = false;
                    }
                    catch (Exception ex)
                    {
                        // Xử lý ngoại lệ nếu cần thiết
                        await Share.ShowDialogAsync("Đã xảy ra lỗi: " + ex.Message, XamlRoot);
                    }
                }

                Loader.Visibility = Visibility.Collapsed;
                Run.IsEnabled = true;
                ComboBoxIP.IsEnabled = true;
                IpTextBox.IsEnabled = true;
                PortText.IsEnabled = true;
            });
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxIP.IsEnabled = false;
            IpTextBox.IsEnabled = false;
            PortText.IsEnabled = false;
            Loader2.Visibility = Visibility.Visible;
            string ipInput = IpTextBox.Text;
            string ipPattern = @"^(\d{1,3}\.){3}\d{1,3}$";
            bool isIpValid = Regex.IsMatch(ipInput, ipPattern) && ipInput.Split('.').All(part =>
            {
                return int.TryParse(part, out int num) && num >= 0 && num <= 255;
            });

            // Kiểm tra Port có hợp lệ hay không
            string portInput = PortText.Text;
            bool isPortValid = int.TryParse(portInput, out int port) && port >= 0 && port <= 65535;
            // Simulate a process (e.g., connecting to server)
            // After the process is done, you can re-enable the button and hide the progress ring
            // For now, let's just simulate a delay
            DispatcherQueue.TryEnqueue(async () =>
            {
                if (string.IsNullOrEmpty(IpTextBox.Text)||string.IsNullOrEmpty(PortText.Text)) 
                {
                    await Share.ShowDialogAsync("Vui Lòng Nhập Đầy Đủ Thông Tin", base.XamlRoot);
                }
                else if (isIpValid==false || isPortValid==false)
                {
                    await Share.ShowDialogAsync("Vui Lòng Nhập Đúng Định Dạng!", base.XamlRoot);
                }
                else
                {
                    var ipmode = (Settings.IPModeEnum)ComboBoxIP.SelectedIndex;
                    Settings.UpdateSetting(Settings.Field.IPMode,ipmode);
                    Settings.UpdateSetting(Settings.Field.ServerPort, PortText.Text);
                    if (ipmode == Settings.IPModeEnum.Custom)
                    {
                        Settings.UpdateSetting(Settings.Field.ServerIP, IpTextBox.Text);
                    }
                    else
                    {
                        Settings.UpdateSetting(Settings.Field.ServerIP, "Auto");
                    }
                    await Share.ShowDialogAsync("Cài đặt đã được lưu thành công", base.XamlRoot);
                }
                // Hide the progress ring
                Loader2.Visibility = Visibility.Collapsed;
                ComboBoxIP.IsEnabled = true;
                IpTextBox.IsEnabled = true;
                PortText.IsEnabled = true;
            });
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Text to copy
            var textToCopy = ServerCode.Text;

            // Sao chép text vào clipboard
            var dataPackage = new Windows.ApplicationModel.DataTransfer.DataPackage();
            dataPackage.SetText(textToCopy);
            Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);

            // Hiển thị TeachingTip thông báo đã sao chép thành công
            CopyTeachingTip.IsOpen = true;

            // Ẩn TeachingTip sau 2 giây
            await Task.Delay(2000);
            CopyTeachingTip.IsOpen = false;
        }
    }
}
