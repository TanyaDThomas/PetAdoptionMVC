namespace PetAdoptionMVC.Models.Enums
{
    public enum WarningType
    {
        AnimalReturnHistory,      // animal has been adopted & returned before
        AdopterReturnHistory,     // adopter has returned animals before
        PetCompatibility,         // dog bad with pets, adopter has pets
        ChildCompatibility,       // dog bad with children, adopter has children
        PaymentHistory,           // adopter has had prior payment issues
        SpecialCareRequirements,  // animal needs special care adopter may not handle
        AdopterBlacklisted,       // hard stop — most severe
        ShotsOverdue,             // needs up to date vaccinations
        VenomousAnimal,           // Critical Venomous 
    }
}
