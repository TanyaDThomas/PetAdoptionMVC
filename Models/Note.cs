using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Models
{
    public class Note
    {
        public int Id { get; set; }
        // "Adopter" or "Animal"
        public NoteEntityType EntityType { get; set; }

        // ID of associated entity
        public int EntityId { get; set; }

        public NoteCategory Category { get; set; }

        public string Content { get; set; } = "";

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }

        public bool IsInternal { get; set; } = false;

        // Optional: helper property for display
        public string DisplayTitle => $"{Category} Note ({CreatedOn:MM/dd/yyyy})";


        // Staff member accountability
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
