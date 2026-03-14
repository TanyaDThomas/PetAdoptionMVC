using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.ViewModels
{
    public class AdoptionDetailsViewModel
    {
        // Adoption Info
        public int Id { get; set; }
        public DateTime AdoptionDate { get; set; }
        public AdoptionStatus Status { get; set; }
        public decimal AdoptionFee { get; set; }
        public AnimalType AnimalType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }

        // Diaplay Adopter Info
        public int AdopterId { get; set; }
        public string AdopterFirstName { get; set; } = "";
        public string AdopterLastName { get; set; } = "";
        public string AdopterPhone { get; set; } = "";
        public string AdopterEmail { get; set; } = "";
        public string AdopterCity { get; set; } = "";
        public string AdopterState { get; set; } = "";
        public string AdopterFullName =>
            $"{AdopterFirstName} {AdopterLastName}";

        // Display Animal Info 
        public int AnimalId { get; set; }
        public string AnimalName { get; set; } = "";
        public string? AnimalBreedOrSpecies { get; set; }
        public int AnimalAge { get; set; }
        public string AnimalColor { get; set; } = "";

        // Any warnings
        public List<Warning> Warnings { get; set; } = new();
        public bool HasWarnings => Warnings.Any();
    }
}
