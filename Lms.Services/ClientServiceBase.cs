using Lms.Data;

namespace Lms.Services
{
    public abstract class ClientServiceBase
    {
        protected readonly LmsContext DbContext;

        protected ClientServiceBase(LmsContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}