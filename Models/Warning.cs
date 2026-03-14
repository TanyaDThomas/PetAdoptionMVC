using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Models
{
    public class Warning
    {
        public int Id { get; set; }

        // Optional — null if warning is pre-adoption
        public int? AdoptionId { get; set; }
        public Adoption? Adoption { get; set; }

        // Who/what the warning is about
        public int? AdopterId { get; set; }
        public int? AnimalId { get; set; }

        //Warning Info
        public WarningType Type { get; set; }
        public WarningSeverity Severity { get; set; }
        public string Message { get; set; } = "";
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
  
        public bool IsAcknowledged { get; set; }
        public string? AcknowledgedBy { get; set; }
        public DateTime? AcknowledgedOn { get; set; }


        // Curently Active - (no deletion of record)
        public bool IsActive { get; set; } = true;


        // Staff member accountability
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
