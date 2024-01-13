using Azure.Core;
using StockTrackingCase.Business.Services;
using StockTrackingCase.Entities.Abstractions;
using StockTrackingCase.Entities.DTOs;
using StockTrackingCase.Entities.Models;
using StockTrackingCase.Entities.Repositories;
using StockTrackingCase.Entities.Utilities;

namespace StockTrackingCase.DataAccess.Services;
public sealed class StockService(
    IStockRepository stockRepository,
    IUnitOfWork unitOfWork) : IStockService
{    
    public Response<Stock> Add(AddStockDto request)
    {
        Stock? stock = stockRepository.GetByExpession(p => p.Type == request.Type);
        if(stock is not null)
        {
            return new("Bu stok türü daha önce kaydedilmiş!");
        }

        stock = new()
        {
            Type = request.Type
        };

        stockRepository.Add(stock);
        unitOfWork.SaveChanges();

        return new(stock);
    }

    public Response<List<Stock>> GetAll()
    {
        return new(stockRepository.GetAll().OrderBy(p=> p.Type).ToList());
    }

    public Response<Stock> Remove(Guid id)
    {
        Stock? stock = stockRepository.GetByExpession(p => p.Id == id);
        if (stock is null)
        {
            return new("Stok türü bulunamadı!");
        }

        stockRepository.Remove(stock);
        unitOfWork.SaveChanges();

        return new(stock);
    }
}
