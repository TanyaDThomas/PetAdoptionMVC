using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Contracts
{
    public interface INoteQueryService
    {
        Task<Note?> GetByIdAsync(int id);
        Task<IEnumerable<Note>> GetByEntityIdAsync(int entityId);
        Task<IEnumerable<Note>> GetByEntityTypeAsync(NoteEntityType entityType);
        Task<IEnumerable<Note>> GetByCategoryAsync(NoteCategory category);
        Task<IEnumerable<Note>> GetByAdopterIdAsync(int adopterId);
        Task<IEnumerable<Note>> GetByAnimalIdAsync(int animalId);
        Task<IEnumerable<Note>> SearchAsync(NoteSearchFilter filter);

    }
}
