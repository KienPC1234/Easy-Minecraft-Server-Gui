using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Easy_Minecraft_Server_Gui
{
    public static class Share
    {
        public static string AP = Directory.GetCurrentDirectory();

        public static string Command(string[] commands,bool NoShowCMD= true, string Logfile = "CMD_LOG.txt")
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
                MessageBox.Show(ex.Message);
                Application.Exit();
                return "";
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
    }
}
