using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using System.Windows.Navigation;
using Lms.Desktop.Commands;
using Lms.Desktop.EventArgs;
using Lms.Desktop.Extensions;
using Lms.Services;

namespace Lms.Desktop.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly UserClientService _userClientService;
        private string _username;
        private string _password;

        public LoginViewModel(NavigationService navigationService,
            UserClientService userClientService) : base(navigationService)
        {
            _userClientService = userClientService;
            LoginCommand = new Command<LoginViewModel>(LoginUser, UserCanLogin);
            PropertyChanged += (o, a) => LoginCommand.CanExecute(this);
        }

        private static bool UserCanLogin(LoginViewModel arg)
        {
            return arg?.Error.IsNullOrEmpty() ?? false;
        }

        private static async void LoginUser(LoginViewModel vm)
        {
            if (vm is null) return;

            var result = await vm._userClientService.LoginUserAsync(vm._username, vm._password);

            if (result.Succeeded)
            {
                vm.OnLoginSucceeded();
                return;
            }

            FailReason? failReason = null;
            if (result.AccountDisabled) failReason = FailReason.AccountDisabled;
            if (result.AccountLocked) failReason = FailReason.AccountLocked;
            if (result.AccountNotFound) failReason = FailReason.NoAccount;

            vm.OnLoginFailed(failReason);
        }

        private void OnLoginFailed(FailReason? failReason = null) =>
            LoginFailed.Raise(this, new LoginEventArgs(false, NavigationService, failReason));

        private void OnLoginSucceeded()
        {
            AppDomain.CurrentDomain.SetData("username", _username);
            LoginSucceeded.Raise(this, new LoginEventArgs(true, NavigationService));
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        public string Username
        {
            get => _username;
            set
            {
                var temp = _username;
                _username = value;
                if (temp == _username) return;
                OnPropertyChanged();
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "Password can only have a length of {2}-{1} characters", MinimumLength = 6)]
        public string Password
        {
            get => _password;
            set
            {
                var temp = _password;
                _password = value;
                if (temp == _password) return;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public event EventHandler<LoginEventArgs> LoginFailed;
        public event EventHandler<LoginEventArgs> LoginSucceeded;
    }
}