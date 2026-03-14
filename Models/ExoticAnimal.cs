namespace PetAdoptionMVC.Models
{
    public class ExoticAnimal : Animal
    {
        public string Species { get; set; } = "";
        public string AnimalFamily { get; set; } = ""; // Arachnid, Insect, Rodent, etc.
                                                       
        // Handling
        public bool IsHandleable { get; set; }
        public bool IsGoodWithChildren { get; set; }
        public bool IsVenomous { get; set; }       
        public bool IsAggressive { get; set; }

        // Housing
        public bool NeedsSpecialEnclosure { get; set; }
        public bool NeedsHeatLamp { get; set; }
        public bool NeedsHumidityControl { get; set; }

        // Care
        public bool EatsLiveFood { get; set; }
    }
}
