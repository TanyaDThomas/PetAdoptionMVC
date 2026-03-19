using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Contracts
{
    public interface IAdoptionQueryService
    {
        Task<IEnumerable<Adoption>> GetAllAsync();
        Task<Adoption?> GetByIdAsync(int id);
        Task<IEnumerable<Adoption>> SearchAsync(AdoptionSearchFilter filter);

        // Needed for warning service
        Task<int> GetReturnCountByAnimalAsync(int animalId);
        Task<int> GetReturnCountByAdopterAsync(int adopterId);
        Task<IEnumerable<Adoption>> GetByAdopterIdAsync(int adopterId);
        Task<IEnumerable<Adoption>> GetByAnimalIdAsync(int animalId);

    }
}
