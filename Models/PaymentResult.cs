using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Models
{
    public class PaymentResult
    {
        public bool Success { get; set; }

        public PaymentStatus Status { get; set; }

        // Transaction/token ID from processor
        public string? TransactionId { get; set; }

        // Optional: Message for debugging or display
        public string? Message { get; set; }
    }
}
