using Microsoft.AspNetCore.Mvc.Rendering;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.ViewModels
{
    public class AdoptionEditViewModel
    {
        public int Id { get; set; }
        public int AdopterId { get; set; }
        public int AnimalId { get; set; }
        public DateTime AdoptionDate { get; set; }
        public AdoptionStatus Status { get; set; }
        public decimal AdoptionFee { get; set; }
        public AnimalType AnimalType { get; set; }

        // For Display Only 
        public string? AdopterName { get; set; }
        public string? AnimalName { get; set; }

        // Status options for dropdown
        public IEnumerable<SelectListItem> StatusOptions =>
            Enum.GetValues<AdoptionStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString(),
                    Selected = s == Status
                });
    }
}
