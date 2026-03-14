using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Contracts
{
    public interface IAnimalService
    {

   
        Task<bool> UpdateAsync(Animal animal);
        Task<bool> DeactivateAsync(int id); // soft delete

        Task<Animal> CreateAnimalAsync(Animal animal);

      
    }
}
