using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Contracts
{
    public interface IWarningService
    {
    
        Task<Warning> CreateAsync(Warning warning);                   
        Task<bool> UpdateAsync(Warning warning);
        Task<bool> DeactivateAsync(int id);
      
    }
}
