namespace PetAdoptionMVC.ViewModels
{
    public class PaymentListViewModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime PaymentDate { get; set; }  
        public int? AdopterId { get; set; }
        public string? ReceiptNumber { get; set; }
    }
}
