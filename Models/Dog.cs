namespace PetAdoptionMVC.Models
{
    public class Dog : Animal
    {
        public string Breed { get; set; } = "";

        // Behavior & temperament
        public bool IsHouseTrained { get; set; }
        public bool IsGoodWithChildren { get; set; }
        public bool IsGoodWithOtherPets { get; set; }
        public bool IsFriendly { get; set; }
    }
}
