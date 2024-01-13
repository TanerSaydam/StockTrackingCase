using Microsoft.AspNetCore.Mvc;
using StockTrackingCase.Business.Services;
using StockTrackingCase.Entities.DTOs;
using StockTrackingCase.Entities.Models;

namespace StockTrackingCase.MVC.Controllers;
public class HomeController(IStockService stockService) : Controller
{
    public IActionResult Index()
    {
        List<Stock>? stock = stockService.GetAll().Data;
        return View(stock);
    }


    [HttpPost]
    public IActionResult Add(AddStockDto request)
    {
        var response = stockService.Add(request);

        if (!response.IsSuccess)
        {
            TempData["Error"] = response.ErrorMessage;            
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult RemoveById(Guid id)
    {
        var response = stockService.Remove(id);

        if (!response.IsSuccess)
        {
            TempData["Error"] = response.ErrorMessage;
        }

        return RedirectToAction("Index");
    }
}
