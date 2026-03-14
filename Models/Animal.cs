using PetAdoptionMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMVC.Models
{
    public abstract class Animal
    {
        public int ShelterId { get; set; } = 1;
        public int Id { get; set; }
        public AnimalType AnimalType { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string Color { get; set; } = "";
        public bool IsVaccinated { get; set; }
        public decimal AdoptionFee { get; set; }
        public bool IsAdopted { get; set; }
        public bool HasSpecialCareNeeds { get; set; }

        public bool HasSpecialDiet { get; set; }

        // For reporting and audit trails
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }

        // Curently Active - (no deletion of record)
        public bool IsActive { get; set; } = true;

        // Staff member accountability
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
