using System.Linq;
using System;
using System.Threading.Tasks;
using Lms.Core;
using Lms.Data;
using Microsoft.EntityFrameworkCore;

namespace Lms.Services
{
    public class UserClientService : ClientServiceBase
    {
        private readonly PasswordEncoder _passwordEncoder;

        public UserClientService(LmsContext dbContext, PasswordEncoder passwordEncoder) : base(dbContext)
        {
            _passwordEncoder = passwordEncoder;
        }

        public async Task<LoginResult> LoginUserAsync(string username, string password)
        {
            if (username is null) throw new ArgumentNullException(nameof(username));
            if (password is null) throw new ArgumentNullException(nameof(password));

            var user = await DbContext.Users.SingleAsync(u => u.Username == username);
            if (user is null) return new LoginResult(accountNotFound: true);

            var passwordsMatch = _passwordEncoder.VerifyPassword(user.Password, password);
            if (!passwordsMatch)
                return new LoginResult(true); 
            
            AppDomain.CurrentDomain.SetData(AppConstants.AuthenticatedUserUsernameKey, username);
            return new LoginResult();
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            var query = from user in DbContext.Users where user.Username == username select user;
            return await query.SingleAsync();
        }
    }
}