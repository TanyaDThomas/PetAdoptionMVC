using Microsoft.AspNetCore.Mvc.Rendering;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.ViewModels
{
    public class AdoptionCreateViewModel
    {
        // Adoption info
        public int? AdopterId { get; set; }
        public int? AnimalId { get; set; }
        public DateTime AdoptionDate { get; set; } = DateTime.Now;
        public AdoptionStatus Status { get; set; } = AdoptionStatus.Pending;
        public decimal AdoptionFee { get; set; }
        public AnimalType? AnimalType { get; set; }


        // Display info 
        public string? AdopterName { get; set; }
        public string? AnimalName { get; set; }

        // Sselected and ready to submit 
        public bool AdopterSelected => AdopterId.HasValue;
        public bool AnimalSelected => AnimalId.HasValue;
        public bool ReadyToSubmit => AdopterSelected && AnimalSelected;

        // Dropdown Search List
        public SelectList? AdopterList { get; set; }
        public SelectList? AnimalList { get; set; }
        public SelectList? AnimalTypeList {  get; set; }
    }
}
