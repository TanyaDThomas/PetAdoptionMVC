using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Models
{
    public class Payment
    {
      
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentType Type { get; set; }  
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public int? AdoptionId { get; set; }          // could be donation so null
        public int? AdopterId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? Notes { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        // Dropped subclasses and added this instead
        
        public string? LastFourDigits { get; set; }
        public string? Expiration { get; set; }
        public string? BankName { get; set; }
        public string? CheckNumber { get; set; }
        public string? PaypalEmail { get; set; }
    }
}
