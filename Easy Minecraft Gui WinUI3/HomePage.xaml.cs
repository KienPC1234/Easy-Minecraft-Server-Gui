using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Easy_Minecraft_Gui_WinUI3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        bool isLoaded = true;
        public HomePage()
        {
            this.InitializeComponent();
            isLoaded = true;
            double newWidth = Width - 275; // Trừ đi một khoảng trống

            // Cập nhật chiều rộng tối đa cho TextBlock
            if (newWidth > 0)
            {
                TextBlock.MaxWidth = newWidth; // Thiết lập chiều rộng tối đa
                TextBlock.UpdateLayout(); // Cập nhật bố cục
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (isLoaded == true)
            {
                // Đảm bảo không có độ trễ không cần thiết, cập nhật ngay lập tức
                double newWidth = e.NewSize.Width - 275; // Trừ đi một khoảng trống

                // Cập nhật chiều rộng tối đa cho TextBlock
                if (newWidth > 0)
                {
                    TextBlock.MaxWidth = newWidth; // Thiết lập chiều rộng tối đa
                    TextBlock.UpdateLayout(); // Cập nhật bố cục
                }
            } 
        }

        private void TextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

        }

        private async void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            // Text to copy
            var textToCopy = "kienpc872009@gmail.com";

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

        private async void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            // Text to copy
            var textToCopy = "127.0.0.1:9191";

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
