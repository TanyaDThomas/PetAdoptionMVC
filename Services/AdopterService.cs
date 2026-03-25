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
    public class AdopterService : IAdopterService
    {
        private readonly PetAdoptionDbContext _context;
        public AdopterService(PetAdoptionDbContext context)
        {
            _context = context;
        }

        //WRITE: ADOPTER CRUD OPERATIONS
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

      
    }
}

