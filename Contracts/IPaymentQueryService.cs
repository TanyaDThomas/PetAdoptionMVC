using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Contracts
{
    public interface IPaymentQueryService
    {
        Task<Payment?> GetByIdAsync(int id);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<IEnumerable<Payment>> GetByAdopterIdAsync(int adopterId);
        Task<IEnumerable<Payment>> GetByAdoptionIdAsync(int adoptionId);
        Task<IEnumerable<Payment>> GetByStatusAsync(PaymentStatus status);
        Task<IEnumerable<Payment>> GetByTypeAsync(PaymentType type);
        Task<IEnumerable<Payment>> SearchAsync(PaymentSearchFilter filter);
        Task<decimal> GetTotalByAdopterAsync(int adopterId);
        Task<decimal> GetTotalByDateRangeAsync(DateTime from, DateTime to);
    }
}
