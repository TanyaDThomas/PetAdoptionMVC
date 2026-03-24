using PetAdoptionMVC.Models;

namespace PetAdoptionMVC.ViewModels
{
    public class FarmAnimalDetailsViewModel : AnimalDetailsViewModel
    {
        public FarmAnimal FarmAnimal { get; set; } = null!;
    }
}
