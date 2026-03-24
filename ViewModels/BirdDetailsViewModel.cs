using PetAdoptionMVC.Models;

namespace PetAdoptionMVC.ViewModels
{
    public class BirdDetailsViewModel : AnimalDetailsViewModel
    {
        public Bird Bird { get; set; } = null!;
    }
}
