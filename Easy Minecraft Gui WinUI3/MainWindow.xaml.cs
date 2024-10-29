using Easy_Minecraft_Server_Gui;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Linq;
using Windows.UI.ApplicationSettings;
using WinRT.Interop;

namespace Easy_Minecraft_Gui_WinUI3
{
    public sealed partial class MainWindow : Window
    {
        private AppWindow m_AppWindow;
        public MainWindow()
        {
            this.InitializeComponent();
            m_AppWindow = this.AppWindow;
            m_AppWindow.SetIcon("server.ico");
            contentFrame.Navigate(typeof(HomePage));
            nvSample.SelectionChanged += NvSample_SelectionChanged;
            contentFrame.Navigated += OnNavigated;
            SetTitleBarColors();
            if (this.Content is FrameworkElement frameworkElement)
            {
                frameworkElement.RequestedTheme = ElementTheme.Dark;
            }
        }


        bool TrySetMicaBackdrop(bool useMicaAlt)
        {
            if (Microsoft.UI.Composition.SystemBackdrops.MicaController.IsSupported())
            {
                Microsoft.UI.Xaml.Media.MicaBackdrop micaBackdrop = new Microsoft.UI.Xaml.Media.MicaBackdrop();
                micaBackdrop.Kind = useMicaAlt ? Microsoft.UI.Composition.SystemBackdrops.MicaKind.BaseAlt : Microsoft.UI.Composition.SystemBackdrops.MicaKind.Base;
                this.SystemBackdrop = micaBackdrop;

                return true; // Succeeded.
            }

            return false; // Mica is not supported on this system.
        }
        private void SetTitleBarColors()
        {
            if (AppWindowTitleBar.IsCustomizationSupported())
            {
                AppWindowTitleBar m_TitleBar = m_AppWindow.TitleBar;
                m_TitleBar.ExtendsContentIntoTitleBar = true;
                m_TitleBar.BackgroundColor = Colors.Transparent; // Màu nền trong suốt
                m_TitleBar.ButtonBackgroundColor = Colors.Transparent; // Nền nút trong suốt
                m_TitleBar.ButtonForegroundColor = Colors.White; // Màu nút

            }
        }


        private void NvSample_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItemContainer != null)
            {
                var selectedItem = args.SelectedItemContainer as NavigationViewItem;
                if (selectedItem != null)
                {
                    var pageTag = selectedItem.Tag.ToString();
                    NavigateToPage(pageTag);
                }
            }
        }

        private void NvSample_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            OnBackRequested();
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            nvSample.IsBackEnabled = contentFrame.CanGoBack;
            if (contentFrame.SourcePageType != null)
            {
                var selectedItem = nvSample.MenuItems
                    .OfType<NavigationViewItem>()
                    .FirstOrDefault(n => n.Tag.ToString() == contentFrame.SourcePageType.Name);

                if (selectedItem != null)
                {
                    nvSample.SelectedItem = selectedItem;
                }
            }
        }

        private void NavigateToPage(string pageTag)
        {
            Type pageType = null;
            switch (pageTag)
            {
                case "HomePage":
                    pageType = typeof(HomePage);
                    break;
                case "PlayerPage":
                    pageType = typeof(PlayerPage);
                    break;
                case "ServerPage":
                    pageType = typeof(ServerPage);
                    break;
                default:
                    pageType = typeof(SettingsPage);
                    break;
            }
            if (pageType != null && contentFrame.CurrentSourcePageType != pageType)
            {
                contentFrame.Navigate(pageType, null, new DrillInNavigationTransitionInfo());
            }
        }

        private bool OnBackRequested()
        {
            if (contentFrame.CanGoBack)
            {
                contentFrame.GoBack();
                return true;
            }
            return false;
        }

        private void nvSample_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Kiểm tra nếu chiều rộng cửa sổ nhỏ hơn một ngưỡng xác định
            if (e.NewSize.Width < 900)
            {
                if (nvSample.PaneDisplayMode != NavigationViewPaneDisplayMode.LeftCompact)
                {
                    nvSample.PaneDisplayMode = NavigationViewPaneDisplayMode.LeftCompact;
                }
            }
            else
            {
                nvSample.PaneDisplayMode = NavigationViewPaneDisplayMode.Left;
            }
        }

        private void contentFrame_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Scollbar.UpdateLayout();
        }
    }
}
