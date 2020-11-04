namespace Lms.Core
{
    public class LoginResult
    {
        public LoginResult(bool invalidCredentials = false, bool accountLocked = false, bool accountNotFound = false,
            bool accountDisabled = false)
        {
            Succeeded = invalidCredentials == false && accountLocked == false && accountNotFound == false &&
                        accountDisabled == false;
            InvalidCredentials = invalidCredentials;
            AccountLocked = accountLocked;
            AccountNotFound = accountNotFound;
            AccountDisabled = accountDisabled;
        }

        public bool Succeeded { get; }
        public bool InvalidCredentials { get; }
        public bool AccountLocked { get; }
        public bool AccountNotFound { get; }
        public bool AccountDisabled { get; }
    }
}