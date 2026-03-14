using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMVC.Models
{
    public class Bird : Animal
    {
        public string Species { get; set; } = "";

        // Care & behavior
        public bool CanFly { get; set; }
        public bool IsHandTamed { get; set; }
        public bool IsGoodWithOtherBirds { get; set; }
        public bool IsGoodWithChildren { get; set; }
        public bool IsGoodWithOtherPets { get; set; }

        // Housing
        public bool NeedsLargeCage { get; set; }

      
       

    }
}
