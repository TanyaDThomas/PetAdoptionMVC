using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.SearchFilters
{
    public class AdoptionSearchFilter
    {
  
        public string? AdopterName { get; set; }
        public int? AdopterId { get; set; }
        public int? AnimalId { get; set; }   
        public AnimalType? AnimalType { get; set; }

        // Search by date
        public DateTime? AdoptionDateFrom { get; set; }
        public DateTime? AdoptionDateTo { get; set; }

        // Search by status
        public AdoptionStatus? Status { get; set; }

        // Active / inactive
        public bool? ActiveOnly { get; set; } = true;

        // Created / updated info
        public string? CreatedBy { get; set; }
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }

        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedFrom { get; set; }
        public DateTime? UpdatedTo { get; set; }


    }
}
