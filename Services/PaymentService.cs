using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Services
{
    public class PaymentService : IPaymentQueryService, IPaymentService
    {
        private readonly PetAdoptionDbContext _context;
        public PaymentService(PetAdoptionDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Payment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetByAdopterIdAsync(int adopterId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetByAdoptionIdAsync(int adoptionId)
        {
            throw new NotImplementedException();
        }

        public Task<Payment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetByStatusAsync(PaymentStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetByTypeAsync(PaymentType type)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalByAdopterAsync(int adopterId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalByDateRangeAsync(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PartialRefundAsync(int paymentId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> ProcessPaymentAsync(Payment payment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RefundAsync(int paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> SearchAsync(PaymentSearchFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VoidPaymentAsync(int paymentId)
        {
            throw new NotImplementedException();
        }
    }
}










