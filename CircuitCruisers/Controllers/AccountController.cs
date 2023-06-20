using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CircuitCruisers.Controllers
{
   

    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var viewModel = new 

            return View();
        }
    }
}
