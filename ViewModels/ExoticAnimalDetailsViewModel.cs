using PetAdoptionMVC.Models;

namespace PetAdoptionMVC.ViewModels
{
    public class ExoticAnimalDetailsViewModel : AnimalDetailsViewModel
    {
        public ExoticAnimal ExoticAnimal { get; set; } = null!;
    }
}
