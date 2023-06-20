using CircuitCruisers.Helpers.Repositories;
using CircuitCruisers.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CircuitCruisers.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactFormRepository _contactFormRepo;

        public ContactsController(ContactFormRepository contactFormRepo)
        {
            _contactFormRepo = contactFormRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                await _contactFormRepo.AddAsync(new Models.Entities.ContactFormEntity
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Message = viewModel.Message,
                });

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}
