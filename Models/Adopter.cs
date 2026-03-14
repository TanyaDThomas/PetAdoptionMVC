using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMVC.Models
{
    public class Adopter
    {
        public int ShelterId { get; set; } = 1;
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required]
        public string Address { get; set; } = "";
        [Required]
        public string City { get; set; } = "";
        [Required]
        public string State { get; set; } = "";
        public string PostalCode { get; set; } = "";
        [Phone]
        public string PhoneNumber { get; set; } = "";
        [EmailAddress]
        public string Email { get; set; } = "";

        //Household Information
        public bool HasOtherPets { get; set; }
        public bool HasChildren { get; set; }
        public bool HasYard { get; set; }

        // For reporting and audit trails
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }

        // Curently Active - (no deletion of record)
        public bool IsActive { get; set; } = true;

        // Staff member accountability
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        //public ICollection<Adoption> Adoptions { get; set; } = new List<Adoption>();
    }
}
