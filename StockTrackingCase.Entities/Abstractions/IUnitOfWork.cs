namespace StockTrackingCase.Entities.Abstractions;
public interface IUnitOfWork
{
    int SaveChanges();
}
