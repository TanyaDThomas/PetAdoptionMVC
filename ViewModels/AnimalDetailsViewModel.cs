using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.ViewModels
{
    public class AnimalDetailsViewModel
    {
        public IEnumerable<Note> RecentNotes { get; set; } = new List<Note>();
        public string? ReturnUrl { get; set; }
        public NoteEntityType EntityType { get; set; } = NoteEntityType.Animal;
    }
}
