using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.SearchFilters
{
    public class WarningSearchFilter
    {
        public int? AdoptionId { get; set; }
   
        public int? AnimalId { get; set; }      
        public int? AdopterId { get; set; }     
        public WarningType? Type { get; set; }  
        public WarningSeverity? Severity { get; set; }
        public bool? IsAcknowledged { get; set; }  
        public string? AcknowledgedBy { get; set; }
        public DateTime? AcknowledgedOn { get; set; }
        public bool? ActiveOnly { get; set; } = true;
        public string? CreatedBy { get; set; }
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedFrom { get; set; }
        public DateTime? UpdatedTo { get; set; }
    }
}
