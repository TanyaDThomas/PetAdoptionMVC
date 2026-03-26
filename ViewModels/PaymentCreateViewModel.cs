using Microsoft.AspNetCore.Mvc.Rendering;
using PetAdoptionMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMVC.ViewModels
{
    public class PaymentCreateViewModel
    {
        
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public PaymentType Type { get; set; }

        // Adoption-related (optional for donations/services)
        public int? AdoptionId { get; set; }   
        public int? AdopterId { get; set; }   

        // Donor info (required for donations/services without adoption)
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }

        
        [MaxLength(4)]
        [Display(Name = "Last 4 digits of card")]
        public string? LastFourDigits { get; set; }

        [MaxLength(100)]
        public string? BankName { get; set; }

        [Display(Name = "Check Number")]
        public string? CheckNumber { get; set; }

        [EmailAddress]
        [Display(Name = "PayPal Email")]
        public string? PaypalEmail { get; set; }

        // Optional notes
        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}