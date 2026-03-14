namespace PetAdoptionMVC.Models
{
    public class SmallAnimal : Animal
    {
        public string Species { get; set; } = ""; // Rabbit, Guinea Pig, Hamster etc.
        public bool NeedsCompanion { get; set; } 
        public bool IsGoodWithChildren { get; set; }
        public bool IsGoodWithOtherPets { get; set; }
        public bool NeedsLargeEnclosure { get; set; }
        public bool IsHandleable { get; set; }
    }
}
