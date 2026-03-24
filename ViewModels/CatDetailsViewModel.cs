using PetAdoptionMVC.Models;

namespace PetAdoptionMVC.ViewModels
{
    public class CatDetailsViewModel : AnimalDetailsViewModel
    {
        public Cat Cat { get; set; } = null!;
    }
}
