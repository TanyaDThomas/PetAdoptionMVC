namespace PetAdoptionMVC.Models
{
    public class Cat : Animal
    {
        public string Breed { get; set; } = "";

        // Behavior & temperament
        public bool IsLitterTrained { get; set; }
        public bool IsGoodWithChildren { get; set; }
        public bool IsGoodWithOtherPets { get; set; }
        public bool IsIndoorOnly { get; set; } 
        public bool IsFriendly { get; set; }    

        
    }
}
