using StockTrackingCase.Entities.DTOs;
using StockTrackingCase.Entities.Models;
using StockTrackingCase.Entities.Utilities;

namespace StockTrackingCase.Business.Services;
public interface IStockService
{
    Response<Stock> Add(AddStockDto request);
    Response<Stock> Remove(Guid id);
    Response<List<Stock>> GetAll();
}
