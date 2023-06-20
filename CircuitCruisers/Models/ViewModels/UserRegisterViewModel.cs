using CircuitCruisers.Models.Entities;
using CircuitCruisers.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace CircuitCruisers.Models.ViewModels
{
    public class UserRegisterViewModel
    {

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You must provide a first name.")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You must provide a last name.")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Street Name")]
        [Required(ErrorMessage = "You must provide a street name.")]
        public string StreetName { get; set; } = null!;

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "You must provide a postal code.")]
        public string PostalCode { get; set; } = null!;

        [Display(Name = "City")]
        [Required(ErrorMessage = "You must provide a city name.")]
        public string City { get; set; } = null!;

        [Display(Name = "Mobile")]
        public string? Mobile { get; set; }

        [Display(Name = "Company")]
        public string? Company { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must provide a e-mail address.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must provide a valid E-mail address")]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must provide a password.")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must confirm your password.")]

        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Upload Profile Image")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }
    
        [Display(Name = "I have read an accepts the terms and conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms and conditions.")]
        public bool TermsAndAgreement { get; set; } = false;


        public static implicit operator AppUser(UserRegisterViewModel viewModel)
        {
            return new AppUser
            {
                UserName = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                PhoneNumber = viewModel.Mobile,
                CompanyName = viewModel.Company,
            };
        }

        public static implicit operator AddressEntity(UserRegisterViewModel viewModel)
        {
            return new AddressEntity
            {
                StreetName = viewModel.StreetName,
                City = viewModel.City,
                PostalCode = viewModel.PostalCode,

            };
        }

    }
}
