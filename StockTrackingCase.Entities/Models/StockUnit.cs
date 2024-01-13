using System.ComponentModel.DataAnnotations.Schema;

namespace StockTrackingCase.Entities.Models;

public sealed class StockUnit
{
    public StockUnit()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }

    [ForeignKey("Stock")]
    public Guid StockId { get; set; }
    public Stock? Stock { get; set; }

    public string UnitCode { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal PurchasePrice { get; set; }
    public string PurchasePriceType { get; set; } = string.Empty;
    public decimal SellingPrice { get; set; }
    public string SellingPriceType { get; set; } = string.Empty;
    public int? PaperWeight { get; set; }
    public bool IsActive { get; set; } = true;

}