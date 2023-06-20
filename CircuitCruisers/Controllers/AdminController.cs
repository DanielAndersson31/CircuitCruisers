using CircuitCruisers.Contexts;
using CircuitCruisers.Helpers.Services;
using CircuitCruisers.Models.Dtos;
using CircuitCruisers.Models.Identity;
using CircuitCruisers.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CircuitCruisers.Controllers
{
    [Authorize(Roles = "admin")]

    public class AdminController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ProductService _productService;

        public AdminController(UserManager<AppUser> userManager, ProductService productService)
        {
            _userManager = userManager;
            _productService = productService;
        }


        public async Task<IActionResult> Index()
        {
            var viewModel = new UsersViewModel
            {
                Users = await _userManager.GetUsersInRoleAsync("user"),
                Administrators = await _userManager.GetUsersInRoleAsync("admin")
            };



            return View(viewModel);
        }

        public async Task<IActionResult> Products() 
        {
            var viewModel = new ProductsViewModel
            {
                ProductsCollection = new CollectionViewModel
                {                 
                    Items = await _productService.GetAllAsync()
                }
            };

            return View(viewModel);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
      

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _productService.CreateProductAsync(viewModel);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
      
    }
}
