namespace PetAdoptionMVC.Models
{
    public class Fish : Animal
    {
        public string Species { get; set; } = "";


        // Tank requirements
        public bool NeedsSaltwater { get; set; }
        public double TankSizeInLiters { get; set; }
        public bool NeedsHeater { get; set; }
        public bool NeedsFilter { get; set; }

        // Social behavior
        public bool IsAggressive { get; set; }
        public bool IsCommunityFriendly { get; set; }

       
    }
}
