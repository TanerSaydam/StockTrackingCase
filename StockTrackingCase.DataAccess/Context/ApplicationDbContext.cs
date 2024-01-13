using Microsoft.EntityFrameworkCore;
using StockTrackingCase.Entities.Abstractions;
using StockTrackingCase.Entities.Models;

namespace StockTrackingCase.DataAccess.Context;
public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<StockUnit> StockUnits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stock>().HasIndex(x => x.Type).IsUnique(true);

        modelBuilder.Entity<StockUnit>().HasIndex(x => x.UnitCode).IsUnique(true);
        modelBuilder.Entity<StockUnit>().Property(p => p.PurchasePrice).HasColumnType("money");
        modelBuilder.Entity<StockUnit>().Property(p => p.SellingPrice).HasColumnType("money");
    }    
}
