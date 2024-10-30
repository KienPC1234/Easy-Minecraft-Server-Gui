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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Easy_Minecraft_Gui_WinUI3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ServerPage : Page
    {
        public  ServerPage()
        {
            this.InitializeComponent();
            try
            {
                IpTextBox.Text = Share.GetIPv4Address();
            }
            catch(Exception ex)
            {
                Share.ShowNotification("Lỗi!", ex.Message);
            }
            ZrokCode.Text = Share.zrokcode();

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
            Run.IsEnabled = false;
            ComboBoxIP.IsEnabled = false;
            IpTextBox.IsEnabled = false;
            PortText.IsEnabled = false;
            Loader.Visibility = Visibility.Visible;

            // Simulate a process (e.g., connecting to server)
            // After the process is done, you can re-enable the button and hide the progress ring
            // For now, let's just simulate a delay
            DispatcherQueue.TryEnqueue(async () =>
            {
                await Task.Delay(3000); // Simulate a 3-second delay
                // Hide the progress ring
                Loader.Visibility = Visibility.Collapsed;
                Run.IsEnabled = true;
                ComboBoxIP.IsEnabled = true;
                IpTextBox.IsEnabled = true;
                PortText.IsEnabled = true;



                await Share.ShowDialogAsync(Share.AP, base.XamlRoot);
            });
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxIP.IsEnabled = false;
            IpTextBox.IsEnabled = false;
            PortText.IsEnabled = false;
            Loader2.Visibility = Visibility.Visible;

            // Simulate a process (e.g., connecting to server)
            // After the process is done, you can re-enable the button and hide the progress ring
            // For now, let's just simulate a delay
            DispatcherQueue.TryEnqueue(async () =>
            {
                await Task.Delay(3000); // Simulate a 3-second delay
                // Hide the progress ring
                Loader2.Visibility = Visibility.Collapsed;
                ComboBoxIP.IsEnabled = true;
                IpTextBox.IsEnabled = true;
                PortText.IsEnabled = true;
                await Share.ShowDialogAsync(Share.AP, base.XamlRoot);
            });
        }
    }
}
