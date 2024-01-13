using Microsoft.EntityFrameworkCore;
using StockTrackingCase.Business.Services;
using StockTrackingCase.Entities.Abstractions;
using StockTrackingCase.Entities.DTOs;
using StockTrackingCase.Entities.Models;
using StockTrackingCase.Entities.Repositories;
using StockTrackingCase.Entities.Utilities;

namespace StockTrackingCase.DataAccess.Services;
public sealed class StokUnitService(
    IStockUnitRepository stockUnitRepository,
    IUnitOfWork unitOfWork) : IStockUnitService
{
    public Response<StockUnit> Add(AddStockUnitDto request)
    {
        StockUnit? stockUnit = stockUnitRepository.GetByExpession(p => p.UnitCode == request.UnitCode);
        if(stockUnit is not null)
        {
            return new("Bu birim kodu daha önce kullanılmış!");
        }

        stockUnit = new()
        {
            UnitCode = request.UnitCode,
            Description = request.Description,
            PaperWeight = request.PaperWeight,
            PurchasePrice = request.PurchasePrice,
            PurchasePriceCurrency = request.PurchasePriceCurrency,
            SellingPrice = request.SellingPrice,
            SellingPriceCurrency = request.SellingPriceCurrency,
            StockId = request.StockId,
            Type = request.Type
        };

        stockUnitRepository.Add(stockUnit);
        unitOfWork.SaveChanges();

        return new(stockUnit);
    }

    public Response<List<StockUnit>> GetAll()
    {
        return new(stockUnitRepository.GetAll().Include(p=> p.Stock).ToList());
    }

    public Response<StockUnit> RemoveById(Guid id)
    {
        StockUnit? stockUnit = stockUnitRepository.GetByExpession(p => p.Id == id);
        if(stockUnit is null)
        {
            return new("Sotk Birimi bulunamadı!");
        }

        stockUnitRepository.Remove(stockUnit);
        unitOfWork.SaveChanges();

        return new(stockUnit);
    }
}
