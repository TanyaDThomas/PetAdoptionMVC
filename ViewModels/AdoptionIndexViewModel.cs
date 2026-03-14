using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.ViewModels
{
    public class AdoptionIndexViewModel
    {
        public int Id { get; set; }
        public string AdopterFullName { get; set; } = "";
        public string AnimalName { get; set; } = "";
        public AnimalType AnimalType { get; set; }
        public DateTime AdoptionDate { get; set; }
        public AdoptionStatus Status { get; set; }
        public decimal AdoptionFee { get; set; }
        public bool HasWarnings { get; set; }
    }
}
