using System.ComponentModel.DataAnnotations;

namespace CircuitCruisers.Models.ViewModels
{
    public class ContactFormViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "You must provide a name")]
        public string Name { get; set; } = null!;
        [Display(Name = "Email")]
        [Required(ErrorMessage = "You must provide an Email address")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Display(Name = "Description")]
        [Required(ErrorMessage = "You must provide a description")]
        public string Message { get; set; } = null!; 
    }
}
