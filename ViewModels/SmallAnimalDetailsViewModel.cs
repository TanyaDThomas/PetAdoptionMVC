using PetAdoptionMVC.Models;

namespace PetAdoptionMVC.ViewModels
{
    public class SmallAnimalDetailsViewModel : AnimalDetailsViewModel
    {
        public SmallAnimal SmallAnimal { get; set; } = null!;
    }
}
