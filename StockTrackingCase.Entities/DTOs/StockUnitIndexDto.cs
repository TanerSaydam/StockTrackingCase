using StockTrackingCase.Entities.Models;

namespace StockTrackingCase.Entities.DTOs;
public sealed class StockUnitIndexDto
{
    public List<StockUnit> StockUnits { get; set; } = new();
    public List<Stock> Stocks { get; set; } = new();
}
