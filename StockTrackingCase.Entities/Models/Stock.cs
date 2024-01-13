namespace StockTrackingCase.Entities.Models;
public sealed class Stock
{
    public Stock()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
