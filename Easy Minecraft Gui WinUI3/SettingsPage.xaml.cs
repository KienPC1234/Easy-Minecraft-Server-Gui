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
using System.Linq;
using Easy_Minecraft_Server_Gui;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Diagnostics;
using System.Linq.Expressions;
using static Easy_Minecraft_Server_Gui.Settings;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Easy_Minecraft_Gui_WinUI3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
       
        public SettingsPage()
        {
            this.InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
             var settings = Settings.LoadSettings(); // Tải cài đặt từ nơi nào đó (tệp, cơ sở dữ liệu, v.v.)

            ZrokCodeV2.Text = settings.Zrokcode;
            ComboBox.SelectedIndex = (int)settings.Backdrop;
            ComboBoxLight.SelectedIndex = (int)settings.Theme;
        }
        private void RestartApplication()
        {
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            process.Start();
            Application.Current.Exit();
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            Save.IsEnabled = false;
            Loader.Visibility = Visibility.Visible;

            if (string.IsNullOrEmpty(ZrokCodeV2.Text))
            {
                await Share.ShowDialogAsync("Vui Lòng Nhập Đầy Đủ Thông Tin!", base.XamlRoot);
                Save.IsEnabled = true;
                Loader.Visibility = Visibility.Collapsed;
                return;
            }
            string zrokcodeV2 = ZrokCodeV2.Text;

            // Chạy lệnh CMD trong một luồng riêng biệt để tránh lag UI
            bool isSuccess = await Task.Run(() =>
            {
                try
                {
                    #region cmd
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
                        Share.iszrokrun = true;
                        if (inputWriter.BaseStream.CanWrite)
                        {
                            inputWriter.WriteLine("zrok.exe disable");
                            inputWriter.WriteLine($"zrok.exe enable {zrokcodeV2}");
                            inputWriter.WriteLine("exit");
                        }
                    }
                    string output = cmd.StandardOutput.ReadToEnd();
                    cmd.WaitForExit();
                    string logFilePath = Path.Combine(Share.AP, "CMD_LOG.txt");
                    File.WriteAllText(logFilePath, output);
                    Share.iszrokrun = false;
                    return output.Contains("the zrok environment was successfully enabled...");
                    #endregion
                }
                catch (Exception ex)
                {
                    // Ghi lại lỗi vào log nếu có
                    string errorLogPath = Path.Combine(Share.AP, "ErrorLog.txt");
                    File.WriteAllText(errorLogPath, ex.Message);
                    return false;
                }
            });

            Loader.Visibility = Visibility.Collapsed;
            Save.IsEnabled = true;

            if (isSuccess)
            {
                // Cập nhật cài đặt sau khi CMD thành công
                Settings.UpdateSetting(Settings.Field.Zrokcode, ZrokCodeV2.Text);
                var selectedTheme = (ThemeEnum)ComboBoxLight.SelectedIndex;
                Settings.UpdateSetting(Settings.Field.Theme, selectedTheme);

                var selectedBackdrop = (BackdropEnum)ComboBox.SelectedIndex;
                Settings.UpdateSetting(Settings.Field.Backdrop, selectedBackdrop);

                await Share.ShowDialogAsync("Lưu Thành Công!", base.XamlRoot);
                RestartApplication();
            }
            else
            {
                await Share.ShowDialogAsync("Vui Lòng Kiểm Tra Lại Mã Code Của Bạn!", base.XamlRoot);
                string logFilePath = Path.Combine(Share.AP, "CMD_LOG.txt");
                Process.Start(new ProcessStartInfo
                {
                    FileName = logFilePath,
                    UseShellExecute = true
                });
            }
        }


        private void OpenLink1_Click(object sender, RoutedEventArgs e) => Process.Start(new ProcessStartInfo("https://github.com/KienPC1234/Easy-Minecraft-Server-Gui/issues") { UseShellExecute = true });

        private void OpenLink2_Click(object sender, RoutedEventArgs e) => Process.Start(new ProcessStartInfo("https://github.com/KienPC1234") { UseShellExecute = true });

        private async void Copy_Click(object sender, RoutedEventArgs e)
        {
            // Text to copy
            var textToCopy = "git clone KienPC1234/Easy-Minecraft-Server-Gui";

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

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TeachingTip.Title = "Thông Báo";
            TeachingTip.Subtitle = "Vui Lòng Nhấn Save Để Lưu Cài Đặt";
            TeachingTip.IsOpen = true;
            await Task.Delay(2000);
            TeachingTip.IsOpen = false;
        }

        private async void ComboBoxLight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TeachingTip.Title = "Thông Báo";
            TeachingTip.Subtitle = "Vui Lòng Nhấn Save Để Lưu Cài Đặt";
            TeachingTip.IsOpen = true;
            await Task.Delay(2000);
            TeachingTip.IsOpen = false;
        }

    }
}
