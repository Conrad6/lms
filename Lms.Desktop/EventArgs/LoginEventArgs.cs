using System.Windows.Navigation;

namespace Lms.Desktop.EventArgs
{
    public class LoginEventArgs : System.EventArgs
    {
        public LoginEventArgs(bool succeeded, NavigationService navigationService, FailReason? failReason = null)
        {
            FailReason = failReason;
            Succeeded = succeeded;
            NavigationService = navigationService;
        }

        public bool Succeeded { get; }
        public FailReason? FailReason { get; }
        public NavigationService NavigationService { get; }
    }

    public enum FailReason
    {
        NoAccount,
        InvalidCredentials,
        AccountLocked,
        AccountDisabled
    }
}