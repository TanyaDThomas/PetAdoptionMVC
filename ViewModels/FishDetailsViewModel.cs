using PetAdoptionMVC.Models;

namespace PetAdoptionMVC.ViewModels
{
    public class FishDetailsViewModel : AnimalDetailsViewModel
    {
        public Fish Fish { get; set; } = null!;
    }
}
