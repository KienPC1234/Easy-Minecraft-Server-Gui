using Easy_Minecraft_Server_Gui;
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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Easy_Minecraft_Gui_WinUI3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayerPage : Page
    {
        public PlayerPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Disable the button and textbox
            connectButton.IsEnabled = false;
            inputTextBox.IsEnabled = false;

            // Show the progress ring
            progressRing.Visibility = Visibility.Visible;
            progressRing.IsActive = true;

            // Simulate a process (e.g., connecting to server)
            // After the process is done, you can re-enable the button and hide the progress ring
            // For now, let's just simulate a delay
            DispatcherQueue.TryEnqueue(async () =>
            {
                await Task.Delay(3000); // Simulate a 3-second delay
                // Hide the progress ring
                progressRing.Visibility = Visibility.Collapsed;
                progressRing.IsActive = false;

                // Re-enable the button and textbox
                connectButton.IsEnabled = true;
                inputTextBox.IsEnabled = true;


                await Share.ShowDialogAsync(Share.AP,base.XamlRoot);
            });

            
            
        }
    }
}
