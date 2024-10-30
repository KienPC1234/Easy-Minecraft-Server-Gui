using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Easy_Minecraft_Gui_WinUI3;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.Windows.AppNotifications.Builder;
using Microsoft.Windows.AppNotifications;
using Windows.Security.Cryptography.Core;

namespace Easy_Minecraft_Server_Gui
{
    public static class Share
    {
        public static string AP = AppContext.BaseDirectory;

        public static string zrokcode()
        {
            string code = "XXXXX";
            return $"(Zrok Code: {code})";
        }
        public static string GetIPv4Address()
        {
            // Lấy tất cả các địa chỉ IP của máy tính
            var host = Dns.GetHostEntry(Dns.GetHostName());

            // Lọc ra địa chỉ IPv4 duy nhất
            var ipv4Address = host.AddressList
                .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork) // Chọn địa chỉ IPv4
                .Select(ip => ip.ToString()) // Chuyển đổi địa chỉ IP thành chuỗi
                .Distinct() // Lọc ra các địa chỉ duy nhất
                .FirstOrDefault(); // Lấy địa chỉ đầu tiên nếu có

            return ipv4Address; // Trả về địa chỉ IPv4 dưới dạng chuỗi
        }

        public static async Task ShowDialogAsync(string message, XamlRoot xamlRoot, string Title = "Thông Báo")
        {
            var dialog = new ContentDialog
            {
                Title = Title,
                Content = message,
                CloseButtonText = "OK",
                XamlRoot = xamlRoot // Sử dụng tham số xamlRoot được truyền vào
            };

            await dialog.ShowAsync();
        }
        public static void ShowNotification(string Title, string content)
        {
            // Khởi tạo AppNotificationBuilder
            var notificationBuilder = new AppNotificationBuilder()
                .AddText(Title)
                .AddText(content);

            // Tạo AppNotification
            var notification = notificationBuilder.BuildNotification();

            // Hiển thị thông báo
            AppNotificationManager.Default.Show(notification);
        }
    }
}
