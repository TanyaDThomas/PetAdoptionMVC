using Microsoft.EntityFrameworkCore;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;



namespace PetAdoptionMVC.Services
{
    public class AdoptionService : IAdoptionService
    {
        private readonly PetAdoptionDbContext _context;

        public AdoptionService(PetAdoptionDbContext context)
        {
            _context = context;
        }

   

        // WRITE OPERATIONS
        public async Task<Adoption> CreateAsync(Adoption adoption)
        {
            adoption.CreatedOn = DateTime.Now;
            adoption.CreatedBy = "System";
            adoption.IsActive = true;
            adoption.Status = AdoptionStatus.Pending;
            _context.Adoptions.Add(adoption);
            await _context.SaveChangesAsync();
            return adoption;
        }

        public async Task<bool> UpdateAsync(Adoption adoption)
        {
            try
            {
                adoption.UpdatedOn = DateTime.Now;
                adoption.UpdatedBy = "System";
                _context.Entry(adoption).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> UpdateStatusAsync(int adoptionId,
            AdoptionStatus status)
        {
            var adoption = await _context.Adoptions
                .FirstOrDefaultAsync(a => a.Id == adoptionId);
            if (adoption == null) return false;
            adoption.Status = status;
            adoption.UpdatedOn = DateTime.Now;
            adoption.UpdatedBy = "System";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeactivateAsync(int id)
        {
            var adoption = await _context.Adoptions
                .FirstOrDefaultAsync(a => a.Id == id);
            if (adoption == null) return false;
            adoption.IsActive = false;
            adoption.UpdatedOn = DateTime.Now;
            adoption.UpdatedBy = "System";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
