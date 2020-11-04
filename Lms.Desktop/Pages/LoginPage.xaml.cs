using System.Windows;
using Lms.Desktop.EventArgs;
using Lms.Desktop.ViewModels;

namespace Lms.Desktop.Pages
{
    public partial class LoginPage
    {
        private readonly BooksPage _booksPage;
        public LoginViewModel ViewModel { get; }

        public LoginPage(LoginViewModel viewModel, BooksPage booksPage)
        {
            _booksPage = booksPage;
            ViewModel = viewModel;
            InitializeComponent();
        }

        private void LoginPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel.LoginFailed += ViewModelOnLoginFailed;
            ViewModel.LoginSucceeded += ViewModelOnLoginSucceeded;
        }

        private void ViewModelOnLoginSucceeded(object sender, LoginEventArgs e)
        {
            e.NavigationService.Navigate(_booksPage);
        }

        private void ViewModelOnLoginFailed(object sender, LoginEventArgs e)
        {
            var message = e.FailReason switch
            {
                FailReason.AccountDisabled => "Your account has been disabled",
                FailReason.AccountLocked => "Your account has been locked",
                FailReason.NoAccount => "Account not found for provided username",
                FailReason.InvalidCredentials => "Invalid username or password",
                _ => "An unknown error occured"
            };

            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }
    }
}