using CircuitCruisers.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CircuitCruisers.Controllers
{
   

    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            
            if (HttpContext.User.Identity != null!)
            {
                var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == HttpContext.User.Identity.Name);

                return View(appUser);
            }

           return RedirectToAction("index", "login");
        }
    }
}
