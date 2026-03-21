using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //WRITE
        public async Task<Note> CreateAsync(Note note)
        {
            note.CreatedOn = DateTime.Now;
            note.CreatedBy = "System";
            note.IsActive = true;
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<bool> DeactivateAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return false;
            note.UpdatedOn = DateTime.Now;
            note.UpdatedBy = "System";
            note.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Note note)
        {
            try
            {
                note.UpdatedOn = DateTime.Now;
                note.UpdatedBy = "System";
                _context.Entry(note).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateConcurrencyException)
            {
                return false;
            }

        }


       

        //READ 
        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _context.Notes
                .AsNoTracking()
                  .Where(n => n.IsActive)
                  .ToListAsync();
        }

        public async Task<Note?> GetByIdAsync(int id)
        {
            return await _context.Notes
                .FindAsync(id);
        }

        public async Task<IEnumerable<Note>> GetByEntityAsync(NoteEntityType entityType, int entityId)
        {
            return await _context.Notes
                .AsNoTracking()
                .Where(e => e.EntityId == entityId && e.EntityType == entityType)
                .OrderByDescending(e => e.UpdatedOn ??  e.CreatedOn)
                .ToListAsync();
        }
        public async Task<IEnumerable<Note>> GetRecentByEntityAsync(NoteEntityType entityType, int entityId, int count = 3)
        {
            return await _context.Notes
                .AsNoTracking()
                .Where(e => e.EntityType == entityType && e.EntityId == entityId)
                .OrderByDescending(e => e.UpdatedOn ?? e.CreatedOn)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Note>> SearchAsync(NoteSearchFilter filter)
        {

            IQueryable<Note> query = _context.Notes
                .AsNoTracking()
                .Where(n => n.IsActive); 

            if (filter.EntityId.HasValue)
            {
                query = query.Where(n => n.EntityId == filter.EntityId.Value);
            }

            if(filter.IsInternal.HasValue)
            {
                query = query.Where(n => n.IsInternal == filter.IsInternal.Value);
            }

            if(filter.Category.HasValue)
            {
                query = query.Where(n => n.Category == filter.Category.Value);
            }

            if (filter.EntityType.HasValue)
            {
                query = query.Where(n => n.EntityType == filter.EntityType.Value);
            }
            
            if(filter.CreatedFrom.HasValue)
            {
                query = query.Where(n => n.CreatedOn >= filter.CreatedFrom.Value);
            }

            if(filter.CreatedTo.HasValue)
            {
                query = query.Where(n => n.CreatedOn <= filter.CreatedTo.Value);
            }

            if (filter.UpdatedFrom.HasValue)
            {
                query = query.Where(n => n.UpdatedOn >= filter.UpdatedFrom.Value);
            }

            if(filter.UpdatedTo.HasValue)
            {
                query = query.Where(n => n.UpdatedOn <= filter.UpdatedTo.Value);
            }

            if(filter.ActiveOnly.HasValue)
            {
                query = query.Where(n => n.IsActive == filter.ActiveOnly.Value);
            }


            if(!string.IsNullOrEmpty(filter.CreatedBy))
            {
                query = query.Where(n => n.CreatedBy == filter.CreatedBy);
            }

            if(!string.IsNullOrEmpty(filter.UpdatedBy))
            {
                query = query.Where(n => n.UpdatedBy == filter.UpdatedBy);
            }

            return await query
                .OrderByDescending(n => n.UpdatedOn ?? n.CreatedOn)
                .ToListAsync();
        }


    }
}
