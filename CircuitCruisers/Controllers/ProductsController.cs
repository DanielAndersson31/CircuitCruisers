using CircuitCruisers.Helpers.Repositories;
using CircuitCruisers.Helpers.Services;
using CircuitCruisers.Models.Entities;
using CircuitCruisers.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CircuitCruisers.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        public async Task<ActionResult> Index(string filter)
        {
          
            var viewModel = new ProductsViewModel
            {
                ProductsCollection = new CollectionViewModel
                {
                    Title = "Products Collection",
                    Items = await _productService.GetAllAsync()
                }
            };
        
            return View(viewModel);
        }
        public async Task<IActionResult> Details(string articleNumber)
        {
            var item = await _productService.GetAsync(articleNumber);
            return View(item);
        }
    }
}
