using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using Microsoft.UI.Windowing;
using WinRT.Interop;
using Windows.UI.ViewManagement;
using System.Linq;
using Microsoft.UI.Xaml.Media.Animation;

namespace Easy_Minecraft_Gui_WinUI3
{
    public sealed partial class MainWindow : Window
    {
        private AppWindow m_AppWindow;
        public MainWindow()
        {
            this.InitializeComponent();

            m_AppWindow = GetAppWindowForCurrentWindow();
            m_AppWindow.Title = "Easy Minecraft Gui WinUI3";
            m_AppWindow.SetIcon("server.ico");
            contentFrame.Navigate(typeof(HomePage));
            nvSample.SelectionChanged += NvSample_SelectionChanged;
            contentFrame.Navigated += OnNavigated;
            SetTitleBarColors();
        }
        private void SetTitleBarColors()
        {
            var uiSettings = new UISettings();
            var background = uiSettings.GetColorValue(UIColorType.Background);
            var foreground = uiSettings.GetColorValue(UIColorType.Foreground);
            if (AppWindowTitleBar.IsCustomizationSupported())
            {
                AppWindowTitleBar m_TitleBar = m_AppWindow.TitleBar;
                // Set title bar colors based on system theme
                m_TitleBar.BackgroundColor = background;
                m_TitleBar.ForegroundColor = foreground;
                m_TitleBar.ButtonBackgroundColor = background;
                m_TitleBar.ButtonForegroundColor = foreground;
                m_TitleBar.ButtonHoverBackgroundColor = Colors.Gray;
                m_TitleBar.ButtonHoverForegroundColor = Colors.White;
                m_TitleBar.ButtonPressedBackgroundColor = Colors.DarkGray;
                m_TitleBar.ButtonPressedForegroundColor = Colors.White;
                m_TitleBar.InactiveBackgroundColor = Colors.LightGray;
                m_TitleBar.InactiveForegroundColor = Colors.Gray;
                m_TitleBar.ButtonInactiveBackgroundColor = Colors.LightGray;
                m_TitleBar.ButtonInactiveForegroundColor = Colors.Gray;
            }
        }

        private AppWindow GetAppWindowForCurrentWindow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return AppWindow.GetFromWindowId(wndId);
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
                case "InfoPage":
                    pageType = typeof(InfoPage);
                    break;
                default:
                    pageType = typeof(HomePage);
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
    }
}
