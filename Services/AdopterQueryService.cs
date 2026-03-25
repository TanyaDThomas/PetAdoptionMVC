using Microsoft.EntityFrameworkCore;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Services
{
    public class AdopterQueryService : IAdopterQueryService
    {
        private readonly PetAdoptionDbContext _context;

        public AdopterQueryService(PetAdoptionDbContext context)
        {
            _context = context;
        }

        //READ: ADOPTION SEARCH 
        public async Task<IEnumerable<Adopter>> GetAllAsync()
        {
            return await _context.Adopters
                .AsNoTracking()
                 .Where(a => a.IsActive)
                 .ToListAsync();
        }

        public async Task<Adopter?> GetByIdAsync(int id)
        {
            return await _context.Adopters
            .FirstOrDefaultAsync(a => a.Id == id);

        }

        public async Task<IEnumerable<Adopter>> SearchAsync(AdopterSearchFilter filter)
        {
            var query = _context.Adopters
                .AsNoTracking()
                .Where(a => a.IsActive);

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(a => (a.FirstName + " " + a.LastName).Contains(filter.Name)
                                       || a.FirstName.Contains(filter.Name)
                                       || a.LastName.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.Phone))
                query = query.Where(a => a.PhoneNumber == filter.Phone);

            if (!string.IsNullOrWhiteSpace(filter.Email))
                query = query.Where(a => a.Email == filter.Email);

            if (!string.IsNullOrWhiteSpace(filter.City))
                query = query.Where(a => a.City == filter.City);

            if (!string.IsNullOrWhiteSpace(filter.State))
                query = query.Where(a => a.State == filter.State);

            if (filter.HasChildren.HasValue)
                query = query.Where(a => a.HasChildren == filter.HasChildren.Value);

            if (filter.HasOtherPets.HasValue)
                query = query.Where(a => a.HasOtherPets == filter.HasOtherPets.Value);

            return await query.ToListAsync();

        }
    }
}
