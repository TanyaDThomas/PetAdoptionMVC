using PetAdoptionMVC.Models;

namespace PetAdoptionMVC.Contracts
{
    public interface IPaymentService
    {
        Task<Payment> ProcessPaymentAsync(PaymentRequest request);
        Task<bool> RefundAsync(int paymentId);
        Task<bool> VoidPaymentAsync(int paymentId);
        Task<bool> PartialRefundAsync(int paymentId, decimal amount);
    }
}
