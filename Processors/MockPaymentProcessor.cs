using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Processors
{
    public class MockPaymentProcessor : IPaymentProcessor
    {
        public async Task<PaymentResult> ProcessAsync(PaymentRequest request)
        {
            await Task.Delay(500);

            var result = new PaymentResult
            {
                Success = true,
                Status = PaymentStatus.Completed,
                TransactionId = Guid.NewGuid().ToString(),
                Message = $"Mock payment of {request.Amount:C} has processed successfully."
            };

            if (request.Amount > 1000) result.Success = false;

            return result;
        }
    }
}
