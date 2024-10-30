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
            //size
            if (contentFrame.Width < 700)
            {
                nvSample.PaneDisplayMode = NavigationViewPaneDisplayMode.LeftMinimal;
            }
            else
            {
                nvSample.PaneDisplayMode = NavigationViewPaneDisplayMode.Auto;
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

        private void contentFrame_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Scollbar.UpdateLayout();
        }

        private void Window_SizeChanged(object sender, WindowSizeChangedEventArgs args)
        {
            // Set the PaneDisplayMode based on window width
            if (args.Size.Width < 800)
            {
                nvSample.PaneDisplayMode = NavigationViewPaneDisplayMode.LeftMinimal;
            }
            else
            {
                nvSample.PaneDisplayMode = NavigationViewPaneDisplayMode.Auto;
            }

            // Define the target X offset for the TitleBar based on window width
            double targetOffsetX = args.Size.Width < 800 ? 40 : 0;

            // Create a storyboard for the animation
            Storyboard storyboard = new Storyboard();
            DoubleAnimation offsetAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromMilliseconds(150)), // Faster animation
                To = targetOffsetX,
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut } // Smooth easing
            };

            // Set the animation target to the TranslateTransform of TitleBar
            Storyboard.SetTarget(offsetAnimation, TitleBarTransform);
            Storyboard.SetTargetProperty(offsetAnimation, "X");

            // Clear any existing animations on TitleBarTransform and add the new one
            storyboard.Children.Clear();
            storyboard.Children.Add(offsetAnimation);
            storyboard.Begin();
        }
    }
}
