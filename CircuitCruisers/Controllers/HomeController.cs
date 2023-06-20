using CircuitCruisers.Helpers.Services;
using CircuitCruisers.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CircuitCruisers.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index(string filter)
    {
        if (filter.IsNullOrEmpty())
        {
            filter = "featured";
        }
        
        var viewModel = new HomeViewModel
        {

            BestCollection = new CollectionViewModel
            { 
                Title = "Best Collection",
                Items = await _productService.GetAllByTagNameAsync(filter)
            }

        };

       return View(viewModel);
    }

    public IActionResult About() 
    {
        return View();
    }
}
