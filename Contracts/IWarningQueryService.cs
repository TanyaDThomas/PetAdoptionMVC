using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Contracts
{
    public interface IWarningQueryService
    {
        Task<IEnumerable<Warning>> GetAllAsync();
        Task<Warning?> GetByIdAsync(int id);
        Task<IEnumerable<Warning>> GetByAnimalIdAsync(int animalId);
        Task<IEnumerable<Warning>> GetByAdopterIdAsync(int adopterId);
        Task<IEnumerable<Warning>> GetByAdoptionIdAsync(int adoptionId);

        Task<IEnumerable<Warning>> GetByTypeAsync(WarningType type);
        Task<IEnumerable<Warning>> GetBySeverityAsync(WarningSeverity severity);
        Task<IEnumerable<Warning>> GetActiveOnlyAsync();
        Task<bool> AcknowledgeAsync(int warningId, string acknowledgedBy);

        Task<List<Warning>> EvaluateAnimalInquiryAsync(Animal animal,
            bool adopterHasChildren, bool adopterHasOtherPets);
        Task<List<Warning>> EvaluateAdoptionAsync(Animal animal,
            Adopter adopter, int? adoptionId = null);
    }
}
