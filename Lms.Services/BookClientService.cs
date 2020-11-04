using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lms.Core;
using Lms.Data;
using Microsoft.EntityFrameworkCore;

namespace Lms.Services
{
    public class BookClientService : ClientServiceBase
    {
        public BookClientService(LmsContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Book>> GetBooksByStockOwnerId(string ownerId)
        {
            if (ownerId is null) throw new ArgumentNullException(nameof(ownerId));

            var query =  from stock in DbContext.Stocks
                where stock.OwnerId == ownerId
                from stockDelivery in stock.StockDeliveries
                from deliveryItem in stockDelivery.StockDeliveryItems
                orderby deliveryItem.Book.DateAdded descending 
                select deliveryItem.Book;
            
            return await query.ToListAsync();
        }
    }
}