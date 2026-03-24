using PetAdoptionMVC.Models;

namespace PetAdoptionMVC.ViewModels
{
    public class DogDetailsViewModel : AnimalDetailsViewModel
    {
        public Dog Dog { get; set; } = null!;
    }
}
