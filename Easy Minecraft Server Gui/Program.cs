using Krypton.Toolkit;
using System.Diagnostics;

namespace Easy_Minecraft_Server_Gui
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (File.Exists(Path.Combine(Share.AP,"Checker.tmp"))==false)
            {
                MessageBox.Show("Đây Là Lần Chạy Đầu Tiên Của Bạn, Vui Lòng Chờ Chúng Tôi Setup Cho Bạn...");
                var output = Share.Command([ "zrok.exe disable", "zrok.exe enable ixd88rZAdaue"]);

                if (!output.Contains("the zrok environment was successfully enabled"))
                {
                    MessageBox.Show("Lỗi, Vui Lòng Check File Log!");
                    Process.Start(Path.Combine(Share.AP, "CMD_LOG.txt"));
                    return;
                }
                File.Create(Path.Combine(Share.AP, "Checker.tmp"));
            }
            Application.Run(new Form1());
        }
    }
}