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
using System.Net.Http;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Microsoft.UI.Xaml.Documents;

namespace Easy_Minecraft_Server_Gui
{
    public static class Share
    { 
        public static bool iszrokrun = false;
        public static string AP = AppContext.BaseDirectory;

        public static string zrokcode()
        {
            var st = Settings.LoadSettings();
            return $"(Zrok Code: {st.Zrokcode})";
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
    public class NetworkChecker
    {
        public class LinkList
        {
            public List<string> Link { get; set; }
        }

        public static async Task<bool> IsConnectedToZrokApi()
        {
            string jsonUrl = "https://raw.githubusercontent.com/KienPC1234/Easy-Minecraft-Server-Gui/refs/heads/master/APICheckLink.json";

            using (HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(5) })
            {
                {
                    // Tải JSON từ URL
                    string json = await client.GetStringAsync(jsonUrl);

                    // Deserialize JSON thành đối tượng LinkList
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    LinkList linkList = JsonSerializer.Deserialize<LinkList>(json, options);

                    // Kiểm tra xem linkList có dữ liệu không và lấy link đầu tiên
                    if (linkList?.Link != null && linkList.Link.Count > 0)
                    {
                        string apiUrl = linkList.Link[0]; // Lấy link đầu tiên
                        HttpResponseMessage response = await client.GetAsync(apiUrl);
                        return response.IsSuccessStatusCode; // Trả về true nếu kết nối thành công
                    }
                }
                return false;
            }
        }
    }
    public class Settings
    {
        private static readonly string SettingPath = Path.Combine(Share.AP, "Settings.json");
        public enum Field
        {
            Zrokcode,
            ServerIP,
            ServerPort,
            IPMode,
            Theme,
            Backdrop
        }

        public enum IPModeEnum
        {
            Auto = 0,
            Custom = 1
        }

        public enum BackdropEnum
        {
            MicaAltBackdrop = 0,
            AcrylicBackdrop = 1,
            MicaBackdrop = 2
        }

        public enum ThemeEnum
        {
            Dark = 0,
            Light = 1,
            Auto = 2
        }

        public string Zrokcode { get; set; }
        public string ServerIP { get; set; }
        public string ServerPort { get; set; }
        public IPModeEnum IPMode { get; set; } = IPModeEnum.Auto;
        public ThemeEnum Theme { get; set; } = ThemeEnum.Dark;
        public BackdropEnum Backdrop { get; set; } = BackdropEnum.MicaAltBackdrop;

        // Hàm khởi tạo file cài đặt mặc định nếu file chưa tồn tại
        public static void InitializeSettingsFile()
        {
            string filePath = SettingPath;
            if (!File.Exists(filePath))
            {
                var defaultSettings = new Settings
                {
                    Zrokcode = "ixd88rZAdaue",
                    ServerIP =  "Auto",
                    ServerPort = "",
                    IPMode = IPModeEnum.Auto,
                    Theme = ThemeEnum.Dark,
                    Backdrop = BackdropEnum.MicaAltBackdrop
                };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string jsonContent = JsonSerializer.Serialize(defaultSettings, options);
                File.WriteAllText(filePath, jsonContent);

                Console.WriteLine("File cài đặt đã được tạo với các giá trị mặc định.");
            }
            else
            {
                Console.WriteLine("File cài đặt đã tồn tại.");
            }
        }

        public static Settings LoadSettings()
        {
            string filePath = SettingPath;
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Không tìm thấy file cài đặt.", filePath);
            }

            string jsonContent = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<Settings>(jsonContent, options) ?? new Settings();
        }

        public static void UpdateSetting(Field field, object value)
        {
            string filePath = SettingPath;
            var settings = File.Exists(filePath) ? LoadSettings() : new Settings();

            switch (field)
            {
                case Field.Zrokcode:
                    settings.Zrokcode = value as string;
                    break;
                case Field.ServerIP:
                    settings.ServerIP = value as string;
                    break;
                case Field.ServerPort:
                    settings.ServerPort = value as string;
                    break;
                case Field.IPMode:
                    settings.IPMode = value is IPModeEnum ipMode ? ipMode : settings.IPMode;
                    break;
                case Field.Theme:
                    settings.Theme = value is ThemeEnum theme ? theme : settings.Theme;
                    break;
                case Field.Backdrop:
                    settings.Backdrop = value is BackdropEnum backdrop ? backdrop : settings.Backdrop;
                    break;
                default:
                    throw new ArgumentException("Field không hợp lệ.");
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string jsonContent = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(filePath, jsonContent);
        }
    }

}

