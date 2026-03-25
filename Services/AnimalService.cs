using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;
using Microsoft.EntityFrameworkCore;

namespace PetAdoptionMVC.Services
{
    public class AnimalService : IAnimalService
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


    }


}

