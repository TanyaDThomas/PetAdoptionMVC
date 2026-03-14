namespace PetAdoptionMVC.Models
{
    public class FarmAnimal : Animal
    {
        public string Species { get; set; } = ""; // Pig, Goat, Chicken, Duck
        public bool IsGoodWithChildren { get; set; }
        public bool IsGoodWithOtherAnimals { get; set; }
        public bool NeedsOutdoorSpace { get; set; }
        public bool IsHouseTrained { get; set; }  
        public bool NeedsCompanion { get; set; }   
    }
}
