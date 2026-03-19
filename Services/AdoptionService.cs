using Microsoft.EntityFrameworkCore;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;



namespace PetAdoptionMVC.Services
{
    public class AdoptionService : IAdoptionQueryService, IAdoptionService
    {
        private readonly PetAdoptionDbContext _context;

        public AdoptionService(PetAdoptionDbContext context)
        {
            _context = context;
        }

        // READ OPERATIONS
        public async Task<IEnumerable<Adoption>> GetAllAsync()
        {
            return await _context.Adoptions
                .AsNoTracking()
                .Where(a => a.IsActive)
                .Include(a => a.Adopter)
                .OrderByDescending(a => a.AdoptionDate)
                .ToListAsync();
        }

        public async Task<Adoption?> GetByIdAsync(int id)
        {
            return await _context.Adoptions
                .Include(a => a.Adopter)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Adoption>> GetByAdopterIdAsync(int adopterId)
        {
            return await _context.Adoptions
                .Where(a => a.AdopterId == adopterId && a.IsActive)
                .OrderByDescending(a => a.AdoptionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Adoption>> GetByAnimalIdAsync(int animalId)
        {
            return await _context.Adoptions
                .Where(a => a.IsActive && a.AnimalId == animalId)
                .OrderByDescending(a => a.AdoptionDate)
                .ToListAsync();
        }

        public async Task<int> GetReturnCountByAnimalAsync(int animalId)
        {
            return await _context.Adoptions
                .AsNoTracking()
                .CountAsync(a => a.AnimalId == animalId &&
                    a.Status == AdoptionStatus.Returned);
        }

        public async Task<int> GetReturnCountByAdopterAsync(int adopterId)
        {
            return await _context.Adoptions
                .AsNoTracking()
                .CountAsync(a => a.AdopterId == adopterId &&
                    a.Status == AdoptionStatus.Returned);
        }

        public async Task<IEnumerable<Adoption>> SearchAsync(
            AdoptionSearchFilter filter)
        {
             IQueryable<Adoption> query = _context.Adoptions
                .AsNoTracking()
                .Where(a => a.IsActive)
                .Include(a => a.Adopter);

            if (!string.IsNullOrEmpty(filter.AdopterName))
                query = query.Where(a =>
                    a.Adopter.FirstName.Contains(filter.AdopterName) ||
                    a.Adopter.LastName.Contains(filter.AdopterName));

            if (filter.AdopterId.HasValue)
                query = query.Where(a => a.AdopterId == filter.AdopterId.Value);

            if (filter.AnimalId.HasValue)
                query = query.Where(a => a.AnimalId == filter.AnimalId.Value);

            if (filter.AnimalType.HasValue)
                query = query.Where(a => a.AnimalType == filter.AnimalType.Value);

            if (filter.Status.HasValue)
                query = query.Where(a => a.Status == filter.Status.Value);

            if (filter.AdoptionDateFrom.HasValue)
                query = query.Where(a =>
                    a.AdoptionDate >= filter.AdoptionDateFrom.Value);

            if (filter.AdoptionDateTo.HasValue)
                query = query.Where(a =>
                    a.AdoptionDate <= filter.AdoptionDateTo.Value);

            if (filter.ActiveOnly.HasValue)
                query = query.Where(a => a.IsActive == filter.ActiveOnly.Value);

            return await query
                .OrderByDescending(a => a.AdoptionDate)
                .ToListAsync();
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
