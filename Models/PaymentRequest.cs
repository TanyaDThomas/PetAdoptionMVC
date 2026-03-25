using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Models
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }

        public PaymentType Type { get; set; }

        public int? AdoptionId { get; set; }
        public int? AdopterId { get; set; }

        // Token returned from card processor or mock
        public string? PaymentToken { get; set; }

        // May change to Note System in future
        public string? Notes { get; set; }
    }
}
