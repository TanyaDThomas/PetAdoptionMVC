using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Models
{
    public class Adoption
    {
        public int ShelterId { get; set; } = 1;
        public int Id { get; set; }

        public int AdopterId { get; set; }
        public Adopter Adopter { get; set; } = null!;

        public int AnimalId { get; set; }

        public AnimalType AnimalType { get; set; }

        public DateTime AdoptionDate { get; set; }

        public AdoptionStatus Status { get; set; }
        public decimal AdoptionFee { get; set; }

        // For reporting and audit trails
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; } = DateTime.UtcNow;

        // Curently Active - (no deletion of record)
        public bool IsActive { get; set; } = true;

        // Staff member accountability
        public string? CreatedBy { get; set; }   
        public string? UpdatedBy { get; set; }   
    }
}
