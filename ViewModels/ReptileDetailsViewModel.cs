using PetAdoptionMVC.Models;

namespace PetAdoptionMVC.ViewModels
{
    public class ReptileDetailsViewModel : AnimalDetailsViewModel
    {
        public Reptile Reptile { get; set; } = null!;
    }
}
