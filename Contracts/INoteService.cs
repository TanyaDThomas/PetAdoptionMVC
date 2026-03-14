using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Contracts
{
    public interface INoteService
    {       
        Task<Note> CreateAsync(Note note);
        Task<bool> UpdateAsync(Note note);
        Task<bool> DeactivateAsync(int id);
   
    }
}
