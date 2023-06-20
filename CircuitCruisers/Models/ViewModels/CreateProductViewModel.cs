using System.ComponentModel.DataAnnotations;

namespace CircuitCruisers.Models.ViewModels
{
    public class CreateProductViewModel
    {
        [Display(Name = "Articlenumber")]
        [Required(ErrorMessage = "Please provide a articlenumber")]
        public string? ArticleNumber { get; set; }
        [Display(Name = "Barcode")]
        public string? BarCode { get; set; }
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please provide a product name")]
        public string? ProductName { get; set; }
        [Display(Name = "Ingress")]
        [Required(ErrorMessage = "Please provide an ingress")]
        public string? Ingress { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please provide a description")]
        public string? Description { get; set; }
        [Display(Name = "Vendor Name")]
        [Required(ErrorMessage = "Please provide a vendor name")]
        public string? VendorName { get; set; }
    }
}
