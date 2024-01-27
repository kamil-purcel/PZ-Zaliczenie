using System.Diagnostics;
using DatePrinter.Web.Models.Classes;
using Microsoft.AspNetCore.Mvc;
using Test.Test.Models;

namespace DatePrinter.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(int categoryId = 1)
    {
        var modelTmp = new Tmp[]
        {
            new(1, "Pomidor", 1, "Kuchnia"),
            new(2, "Bulki", 1, "Kuchnia"),
            new(3, "Cebula", 1, "Kuchnia"),
            new(4, "Salata", 1, "Kuchnia"),
            new(5, "Bekon", 1, "Kuchnia"),
            new(6, "Prozona", 1, "Kuchnia"),
            new(7, "Rukola", 1, "Kuchnia"),
            new(8, "Ser", 1, "Kuchnia"),
            new(9, "Ketchup", 1, "Kuchnia"),
            new(10, "Musztarda", 1, "Kuchnia"),
            new(11, "Majonez", 1, "Kuchnia"),
            new(12, "Pikle", 1, "Kuchnia"),
            new(13, "Jalapenio", 1, "Kuchnia"),
            new(14, "Pomidor", 2, "Chłodnia"),
            new(15, "Cebula", 2, "Chłodnia"),
            new(16, "Bekon", 2, "Chłodnia"),
            new(17, "Pikle", 2, "Chłodnia"),
            new(18, "Majonez", 2, "Chłodnia"),
            new(19, "Jalapenio", 2, "Chłodnia"),
            new(20, "Chorizo", 2, "Chłodnia"),
            new(21, "Mieszanka", 2, "Chłodnia")
        };

        var categoryTmp = modelTmp
            .DistinctBy(p => p.CategoryId)
            .Select(p => new { p.CategoryId, CategoryName = p.Category })
            .ToArray();

        var model = modelTmp.Where(p => p.CategoryId == categoryId).ToArray();

        var category = new List<TmpCategory>();
        foreach (var cate in categoryTmp) category.Add(new TmpCategory(cate.CategoryId, cate.CategoryName));

        var viewModel = new MyViewModel
        {
            ModelData = model,
            CategoryData = category
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Details(int id)
    {
        var products = new Tmp[]
        {
            new(1, "Pomidor", 1, "Kuchnia"),
            new(2, "Bulki", 1, "Kuchnia"),
            new(3, "Cebula", 1, "Kuchnia"),
            new(4, "Salata", 1, "Kuchnia"),
            new(5, "Bekon", 1, "Kuchnia"),
            new(6, "Prozona", 1, "Kuchnia"),
            new(7, "Rukola", 1, "Kuchnia"),
            new(8, "Ser", 1, "Kuchnia"),
            new(9, "Ketchup", 1, "Kuchnia"),
            new(10, "Musztarda", 1, "Kuchnia"),
            new(11, "Majonez", 1, "Kuchnia"),
            new(12, "Pikle", 1, "Kuchnia"),
            new(13, "Jalapenio", 1, "Kuchnia"),
            new(14, "Pomidor", 2, "Chłodnia"),
            new(15, "Cebula", 2, "Chłodnia"),
            new(16, "Bekon", 2, "Chłodnia"),
            new(17, "Pikle", 2, "Chłodnia"),
            new(18, "Majonez", 2, "Chłodnia"),
            new(19, "Jalapenio", 2, "Chłodnia"),
            new(20, "Chorizo", 2, "Chłodnia"),
            new(21, "Mieszanka", 2, "Chłodnia")
        };

        var model = products.FirstOrDefault(p => p.Id == id);

        return View(model);
    }

    public IActionResult Print(int id, DateTime dateTime)
    {
        // DateTime dateTime = new DateTime();
        if (id is not 0)
        {
            var products = new Tmp[]
            {
                new(1, "Pomidor", 1, "Kuchnia"),
                new(2, "Bulki", 1, "Kuchnia"),
                new(3, "Cebula", 1, "Kuchnia"),
                new(4, "Salata", 1, "Kuchnia"),
                new(5, "Bekon", 1, "Kuchnia"),
                new(6, "Prozona", 1, "Kuchnia"),
                new(7, "Rukola", 1, "Kuchnia"),
                new(8, "Ser", 1, "Kuchnia"),
                new(9, "Ketchup", 1, "Kuchnia"),
                new(10, "Musztarda", 1, "Kuchnia"),
                new(11, "Majonez", 1, "Kuchnia"),
                new(12, "Pikle", 1, "Kuchnia"),
                new(13, "Jalapenio", 1, "Kuchnia"),
                new(14, "Pomidor", 2, "Chłodnia"),
                new(15, "Cebula", 2, "Chłodnia"),
                new(16, "Bekon", 2, "Chłodnia"),
                new(17, "Pikle", 2, "Chłodnia"),
                new(18, "Majonez", 2, "Chłodnia"),
                new(19, "Jalapenio", 2, "Chłodnia"),
                new(20, "Chorizo", 2, "Chłodnia"),
                new(21, "Mieszanka", 2, "Chłodnia")
            };

            var model = products.FirstOrDefault(p => p.Id == id);

            _logger.LogInformation("Print " + model.Name + " " + dateTime);
            return RedirectToAction("Index", new { categoryId = model.CategoryId });
        }

        return RedirectToAction("Index", new { categoryId = 1 });
    }
}