using PetAdoptionMVC.Models;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Contracts
{
    public interface IAdopterService
    {

        Task<Adopter> CreateAsync(Adopter adopter);

        Task<bool> UpdateAsync(Adopter adopter);

        Task<bool> DeactivateAsync(int id);

    }
}
