using StockTrackingCase.DataAccess.Context;
using StockTrackingCase.Entities.Models;
using StockTrackingCase.Entities.Repositories;

namespace StockTrackingCase.DataAccess.Repositories;
public sealed class StockRepository : Repository<Stock>, IStockRepository
{
    public StockRepository(ApplicationDbContext context) : base(context)
    {
    }
}

