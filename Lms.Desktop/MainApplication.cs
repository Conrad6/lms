using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using Lms.Desktop.Pages;

namespace Lms.Desktop
{
    public class MainApplication : Application
    {
        public MainApplication (
            NavigationWindow navigationWindow,
            LoginPage loginPage)
        {
            navigationWindow.ShowsNavigationUI = false;
            navigationWindow.SizeToContent = SizeToContent.WidthAndHeight;
            Navigated += OnNavigated;
            MainWindow = navigationWindow;

            navigationWindow.Navigate(loginPage);
        }

        private void OnNavigated (object sender, NavigationEventArgs e)
        {
            if (!(e.Navigator is Window window)) return;
            if (!(e.Content is Page page)) return;

            window.Title = string.IsNullOrEmpty(page.Title) ? "LMS" : $"{page.Title} - LMS";
        }
    }
}