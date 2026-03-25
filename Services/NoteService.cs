using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Services
{
    public class NoteService : INoteService
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

    }
}
