
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Contracts
{
    public interface IAnimalQueryService
    {
        // Get all
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<IEnumerable<Animal>> GetAllAvailableAsync();
        Task<IEnumerable<Animal>> GetAllAdoptedAsync();

        // Get type
        Task<IEnumerable<Animal>> GetByTypeAsync(AnimalType type);
        Task<IEnumerable<Animal>> GetAvailableByTypeAsync(AnimalType type);

        Task<IEnumerable<Animal>> GetRecentlyAddedAsync(int count);
        Task<IEnumerable<Animal>> GetAnimalsByShelterId(int shelterId);
        Task<Animal?> GetByIdAsync(int id);

        // Search & filter
        Task<IEnumerable<Animal>> SearchAsync(AnimalSearchFilter filter);

        
    }
}
