using Microsoft.EntityFrameworkCore;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Services
{
    public class PaymentQueryService : IPaymentQueryService
    {
        private readonly PetAdoptionDbContext _context;

        public PaymentQueryService(PetAdoptionDbContext context)
        {
            _context = context;
        }

        //PAYMENT SEARCH INFORMATION
        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments
                 .AsNoTracking()
                   .Where(p => p.IsActive)
                   .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetByAdopterIdAsync(int adopterId)
        {
            return await _context.Payments
               .Where(a => a.AdopterId == adopterId && a.IsActive)
               .OrderByDescending(a => a.PaymentDate)
               .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetByAdoptionIdAsync(int adoptionId)
        {
            return await _context.Payments
             .Where(a => a.AdoptionId == adoptionId && a.IsActive)
             .OrderByDescending(a => a.PaymentDate)
             .ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _context.Payments
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Payment>> GetByStatusAsync(PaymentStatus status)
        {
            return await _context.Payments
              .Where(a => a.Status == status && a.IsActive)
              .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetByTypeAsync(PaymentType type)
        {
            return await _context.Payments
               .AsNoTracking()
               .Where(a => a.Type == type)
               .ToListAsync();
        }

        public async Task<decimal> GetTotalByAdopterAsync(int adopterId)
        {
            return await _context.Payments
               .Where(p => p.AdopterId == adopterId && p.IsActive && p.Status == PaymentStatus.Completed)
               .SumAsync(p => p.Amount);
        }

        public async Task<decimal> GetTotalByDateRangeAsync(DateTime from, DateTime to)
        {
            return await _context.Payments
                 .Where(p => p.PaymentDate >= from && p.PaymentDate <= to
                             && p.IsActive && p.Status == PaymentStatus.Completed)
                 .SumAsync(p => p.Amount);
        }

        public async Task<IEnumerable<Payment>> SearchAsync(PaymentSearchFilter filter)
        {
            IQueryable<Payment> query = _context.Payments
                .AsNoTracking()
                .Where(p => p.IsActive);



            if (filter.AdoptionId.HasValue)
            {
                query = query.Where(p => p.AdoptionId == filter.AdoptionId.Value);
            }

            if (filter.AdopterId.HasValue)
            {
                query = query.Where(p => p.AdopterId == filter.AdopterId.Value);
            }

            if (filter.PaymentType.HasValue)
            {
                query = query.Where(p => p.Type == filter.PaymentType.Value);
            }

            if (filter.Status.HasValue)
            {
                query = query.Where(p => p.Status == filter.Status.Value);
            }

            if (filter.AmountMin.HasValue)
            {
                query = query.Where(p => p.Amount >= filter.AmountMin.Value);
            }

            if (filter.AmountMax.HasValue)
            {
                query = query.Where(p => p.Amount <= filter.AmountMax.Value);
            }

            if (filter.PaymentDateTo.HasValue)
            {
                query = query.Where(p => p.CreatedOn <= filter.PaymentDateTo.Value);
            }

            if (filter.PaymentDateFrom.HasValue)
            {
                query = query.Where(p => p.PaymentDate >= filter.PaymentDateFrom.Value);
            }


            if (filter.CreatedFrom.HasValue)
            {
                query = query.Where(p => p.CreatedOn >= filter.CreatedFrom.Value);
            }

            if (filter.CreatedTo.HasValue)
            {
                query = query.Where(p => p.CreatedOn <= filter.CreatedTo.Value);
            }

            return await query
                 .OrderByDescending(p => p.UpdatedOn ?? p.CreatedOn)
                .ToListAsync();
        }

    }
}
