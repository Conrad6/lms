using Lms.Data;

namespace Lms.Services
{
    public class StockClientService : ClientServiceBase
    {
        public StockClientService(LmsContext dbContext) : base(dbContext)
        {
        }
    }
}