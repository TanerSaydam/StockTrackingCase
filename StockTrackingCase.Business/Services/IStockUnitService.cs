using StockTrackingCase.Entities.DTOs;
using StockTrackingCase.Entities.Models;
using StockTrackingCase.Entities.Utilities;

namespace StockTrackingCase.Business.Services;
public interface IStockUnitService
{
    Response<StockUnit> Add(AddStockUnitDto request);
    Response<StockUnit> RemoveById(Guid id);
    Response<List<StockUnit>> GetAll();
}
