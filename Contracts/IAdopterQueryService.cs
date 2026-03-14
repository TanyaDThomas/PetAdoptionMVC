using PetAdoptionMVC.Models;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Contracts
{
    public interface IAdopterQueryService
    {
        Task<IEnumerable<Adopter>> GetAllAsync();
        Task<Adopter?> GetByIdAsync(int id);
        Task<IEnumerable<Adopter>> SearchAsync(AdopterSearchFilter filter);

        //Task<IEnumerable<Adopter>> GetAdoptersWithReturnHistoryAsync();

    }
}
