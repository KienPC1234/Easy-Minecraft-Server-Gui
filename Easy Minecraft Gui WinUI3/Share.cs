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

namespace Easy_Minecraft_Server_Gui
{
    public static class Share
    {
        public static string AP = AppContext.BaseDirectory;



        public static async Task<string> Command(string[] commands, bool NoShowCMD = true, string Logfile = "CMD_LOG.txt")
        {
            string output;
            try
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = NoShowCMD;
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.WorkingDirectory = AP;

                cmd.Start();

                using (StreamWriter inputWriter = cmd.StandardInput)
                {
                    if (inputWriter.BaseStream.CanWrite)
                    {
                        foreach (string command in commands)
                        {
                            inputWriter.WriteLine(command);
                        }
                        inputWriter.WriteLine("exit");
                    }
                }
                output = cmd.StandardOutput.ReadToEnd();
                cmd.WaitForExit();
                string logFilePath = Path.Combine(AP, Logfile);
                File.WriteAllText(logFilePath, output);
                return output;
            }
            catch (Exception ex)
            {
                App.Current.Exit();
                return string.Empty;
            }
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
    }
}
