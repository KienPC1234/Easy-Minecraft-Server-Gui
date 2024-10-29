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
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Save.IsEnabled = false;

            Loader.Visibility = Visibility.Visible;

            // Simulate a process (e.g., connecting to server)
            // After the process is done, you can re-enable the button and hide the progress ring
            // For now, let's just simulate a delay
            DispatcherQueue.TryEnqueue(async () =>
            {
                await Task.Delay(3000); // Simulate a 3-second delay
                // Hide the progress ring
                Loader.Visibility = Visibility.Collapsed;
                Save.IsEnabled = true;
                


                await Share.ShowDialogAsync(Share.AP, base.XamlRoot);
            });

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
