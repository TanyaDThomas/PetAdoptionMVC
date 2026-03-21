using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Contracts
{
    public interface INoteQueryService
    {
        Task<IEnumerable<Note>> GetAllAsync();
        Task<Note?> GetByIdAsync(int id);
        Task<IEnumerable<Note>> GetByEntityAsync(NoteEntityType entityType, int entityId);
        Task<IEnumerable<Note>> GetRecentByEntityAsync(NoteEntityType entityType, int entityId, int count = 3);
        Task<IEnumerable<Note>> SearchAsync(NoteSearchFilter filter);

    }
}
