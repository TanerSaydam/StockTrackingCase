using Microsoft.EntityFrameworkCore;
using StockTrackingCase.Business.Services;
using StockTrackingCase.DataAccess.Context;
using StockTrackingCase.DataAccess.Repositories;
using StockTrackingCase.DataAccess.Services;
using StockTrackingCase.Entities.Abstractions;
using StockTrackingCase.Entities.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockUnitRepository, StockUnitRepository>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
