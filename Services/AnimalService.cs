using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;
using Microsoft.EntityFrameworkCore;

namespace PetAdoptionMVC.Services
{
    public class AnimalService : IAnimalQueryService, IAnimalService
    {
        private readonly PetAdoptionDbContext _context;
        public AnimalService(PetAdoptionDbContext context)
        {
            _context = context;
        }
         
        // WRITE OPERATIONS
        public async Task<Animal> CreateAnimalAsync(Animal animal)
        {
            animal.CreatedOn = DateTime.Now;
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
            return animal;
        }

        public async Task<bool> UpdateAsync(Animal animal)
        {
            animal.UpdatedOn = DateTime.Now;
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeactivateAsync(int id)
        {
            var animal = await _context.Animals
                .FirstOrDefaultAsync(a => a.Id == id);

            if (animal == null) return false;

            animal.IsActive = false;
            animal.UpdatedOn = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }


        // READ OPERATIONS
        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _context.Animals
                .AsNoTracking()
                .Where(a => a.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetAllAdoptedAsync()
        {
            return await _context.Animals
                .AsNoTracking()
                .Where(a => a.IsAdopted == true && a.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetAllAvailableAsync()
        {
            return await _context.Animals
                .AsNoTracking()
               .Where(a => a.IsAdopted == false && a.IsActive)
               .ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetAnimalsByShelterId(int shelterId)
        {
            return await _context.Animals
                .AsNoTracking()
                .Where(a => a.ShelterId == shelterId && a.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetAvailableByTypeAsync(AnimalType type)
        {
            return await _context.Animals
                .AsNoTracking()
                .Where(a => a.AnimalType == type && a.IsAdopted == false && a.IsActive)
                .ToListAsync();
        }

        public async Task<Animal?> GetByIdAsync(int id)
        {
            return await _context.Animals
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Animal>> GetByTypeAsync(AnimalType type)
        {
            return await _context.Animals
                .AsNoTracking()
                .Where(a => a.AnimalType == type && a.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetRecentlyAddedAsync(int count)
        {
            return await _context.Animals
                .AsNoTracking()
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.CreatedOn)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Animal>> SearchAsync(AnimalSearchFilter filter)
        {
            var query = _context.Animals
                .AsNoTracking()
                .Where(a => a.IsActive);

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(a => a.Name.Contains(filter.Name));

            if (filter.Type.HasValue)
                query = query.Where(a => a.AnimalType == filter.Type.Value);

            if (filter.IsAvailable.HasValue)
                query = query.Where(a => a.IsAdopted == !filter.IsAvailable.Value);

            if (filter.MinAge.HasValue)
                query = query.Where(a => a.Age >= filter.MinAge.Value);

            if (filter.MaxAge.HasValue)
                query = query.Where(a => a.Age <= filter.MaxAge.Value);

            if (filter.HasSpecialCareNeeds.HasValue)
                query = query.Where(a => a.HasSpecialCareNeeds == filter.HasSpecialCareNeeds.Value);

            if (!string.IsNullOrEmpty(filter.Species))
                query = query.Where(a => EF.Property<string>(a, "Species") == filter.Species);

            if (!string.IsNullOrEmpty(filter.Breed))
                query = query.Where(a => EF.Property<string>(a, "Breed") == filter.Breed);

            return await query.ToListAsync();
        }
    }


}

