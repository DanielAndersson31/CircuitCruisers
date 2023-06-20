using Microsoft.AspNetCore.Mvc;

namespace CircuitCruisers.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
