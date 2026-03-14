using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Services
{
    public class NoteService : INoteQueryService, INoteService
    {
        private readonly PetAdoptionDbContext _context;
        public NoteService(PetAdoptionDbContext context)
        {
            _context = context;
        }

        public Task<Note> CreateAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeactivateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetByAdopterIdAsync(int adopterId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetByAnimalIdAsync(int animalId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetByCategoryAsync(NoteCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetByEntityIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetByEntityTypeAsync(NoteEntityType entityType)
        {
            throw new NotImplementedException();
        }

        public Task<Note?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> SearchAsync(NoteSearchFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
