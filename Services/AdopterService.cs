using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PetAdoptionsMVC.Service
{
    public class AdopterService : IAdopterQueryService, IAdopterService
    {
        private readonly PetAdoptionDbContext _context;
        public AdopterService(PetAdoptionDbContext context)
        {
            _context = context;
        }

        //WRITE 
        public async Task<Adopter> CreateAsync(Adopter adopter)
        {
            adopter.CreatedOn = DateTime.Now;
            _context.Adopters.Add(adopter);
            await _context.SaveChangesAsync();
            return adopter;
        }

        public async Task<bool> DeactivateAsync(int id)
        {
            var adopter = await _context.Adopters
                .FirstOrDefaultAsync(a => a.Id == id);

            if (adopter == null) return false;

            adopter.IsActive = false;
            adopter.UpdatedOn = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Adopter adopter)
        {
            adopter.UpdatedOn = DateTime.Now;
             _context.Adopters.Update(adopter);
            await _context.SaveChangesAsync();
            return true;
        }

        //READ

        //public async Task<IEnumerable<Adopter>> GetAdoptersWithReturnHistoryAsync()
        //{
        //    return await _context.Adopters
        //        .Where(a => a.IsActive)
        //        .Include(a => a.Adoptions)
        //        .Where(a => a.Adoptions.Any(r => r.Status == AdoptionStatus.Returned))
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<Adopter>> GetAllAsync()
        {
            return await _context.Adopters
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

