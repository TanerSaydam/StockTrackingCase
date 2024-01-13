namespace StockTrackingCase.Entities.DTOs;
public sealed record AddStockUnitDto(
    string UnitCode,
    Guid StockId,
    string Type,
    decimal PurchasePrice,
    string PurchasePriceCurrency,
    decimal SellingPrice,
    string SellingPriceCurrency,
    int? PaperWeight,
    string? Description);
