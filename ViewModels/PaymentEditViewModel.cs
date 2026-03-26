using PetAdoptionMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMVC.ViewModels
{
    public class PaymentEditViewModel
    {
        public int Id { get; set; }


        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public PaymentType Type { get; set; }

        public int? AdoptionId { get; set; }
        public int? AdopterId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        public string? LastFourDigits { get; set; }

        [MaxLength(100)]
        public string? BankName { get; set; }
        public string? CheckNumber { get; set; }

        public string? PaypalEmail { get; set; }

        public string? Notes { get; set; }
    }
}
