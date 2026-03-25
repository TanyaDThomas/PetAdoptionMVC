using PetAdoptionMVC.Models;

namespace PetAdoptionMVC.Contracts
{
    public interface IPaymentProcessor
    {
        /// <summary>
        /// Processes a payment request and returns the result.
        /// </summary>
        /// <param name="request">The payment request containing amount, type, token, etc.</param>
        /// <returns>PaymentResult indicating success, status, and transaction ID.</returns>
        Task<PaymentResult> ProcessAsync(PaymentRequest request);
    }
}
