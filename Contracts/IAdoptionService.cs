using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Contracts
{
    public interface IAdoptionService
    {
     
        Task<Adoption> CreateAsync(Adoption adoption);
        Task<bool> UpdateAsync(Adoption adoption);
        Task<bool> UpdateStatusAsync(int adoptionId, AdoptionStatus status);
        Task<bool> DeactivateAsync(int id);
       
    }
}
