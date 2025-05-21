using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace PulcsiShop.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        [Display(Name = "Név")]
        [Required(ErrorMessage = "A név megadása kötelező!")]
        public string? CustomerName { get; set; }     

        [Display(Name = "Irányítószám")]
        [Required(ErrorMessage = "Az irányítószám megadása kötelező!")]
        public int? ZipCode { get; set; }

        [Display(Name = "Lakcím")]
        [Required(ErrorMessage = "A lakcím megadása kötelező!")]
        public string? Address { get; set; }

        [Display(Name = "Telefonszám")]
        [Required(ErrorMessage = "A telefonszám megadása kötelező!")]
        [Phone(ErrorMessage = "Érvényes telefonszámot adjon meg!")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Megjegyzés a futárnak")]
        public string? Note { get; set; }
        [Display(Name = "Végösszeg")]
        [BindNever]
        public int? TotalPrice { get; set; }

        public Order() { }
    }
}
