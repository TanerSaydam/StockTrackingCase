using Microsoft.AspNetCore.Mvc;
using StockTrackingCase.Business.Services;
using StockTrackingCase.Entities.DTOs;
using StockTrackingCase.Entities.Models;

namespace StockTrackingCase.MVC.Controllers;
public class StockUnitsController(
    IStockUnitService stockUnitService,
    IStockService stockService) : Controller
{
    public IActionResult Index()
    {
        List<StockUnit>? stockUnits = stockUnitService.GetAll().Data;
        List<Stock>? stocks = stockService.GetAll().Data;

        StockUnitIndexDto response = new()
        {
            Stocks = stocks ?? new(),
            StockUnits = stockUnits ?? new()
        };

        return View(response);
    }

    [HttpPost]
    public IActionResult Add(AddStockUnitDto request)
    {
        var response = stockUnitService.Add(request);

        if (!response.IsSuccess)
        {
            TempData["Error"] = response.ErrorMessage;
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult RemoveById(Guid id)
    {
        var response = stockUnitService.RemoveById(id);

        if (!response.IsSuccess)
        {
            TempData["Error"] = response.ErrorMessage;
        }

        return RedirectToAction("Index");
    }
}
