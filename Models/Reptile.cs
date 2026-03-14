namespace PetAdoptionMVC.Models
{
    public class Reptile : Animal
    {
        public string Species { get; set; } = "";

        // Temperament & handling
        public bool IsHandleable { get; set; }
        public bool IsGoodWithChildren { get; set; }
        public bool IsGoodWithOtherPets { get; set; }

        // Housing & environment
        public bool NeedsHeatLamp { get; set; }
        public bool NeedsUVBLight { get; set; }
        public bool NeedsHumidityControl { get; set; }

        // Feeding
        public bool EatsLiveFood { get; set; }
        //public string? DietNotes { get; set; }


        // Safety
        public bool IsVenomous { get; set; }
    }
}
