using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Models
{ 
        public class PaymentRequest
        {
            public decimal Amount { get; set; }
            public PaymentType Type { get; set; }
            public int? AdoptionId { get; set; }
            public int? AdopterId { get; set; }

            
            public string? FirstName { get; set; }
            public string? LastName { get; set; }

            
            public string? LastFourDigits { get; set; }
            public string? BankName { get; set; }
            public string? CheckNumber { get; set; }
            public string? PaypalEmail { get; set; }

   

        // Token returned from card processor or mock
        public string? PaymentToken { get; set; }


        // May add to Note System in future
        public string? Notes { get; set; }
    }
}
