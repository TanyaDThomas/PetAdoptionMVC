using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Services
{
    public class WarningService : IWarningQueryServices, IWarningService
    {
        private readonly PetAdoptionDbContext _context;
        public WarningService(PetAdoptionDbContext context)
        {
            _context = context;
        }

        public Task<bool> AcknowledgeAsync(int warningId, string acknowledgedBy)
        {
            throw new NotImplementedException();
        }

        public Task<Warning> CreateAsync(Warning warning)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeactivateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Warning>> EvaluateAdoptionAsync(Animal animal, Adopter adopter, int? adoptionId = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<Warning>> EvaluateAnimalInquiryAsync(Animal animal, bool adopterHasChildren, bool adopterHasOtherPets)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Warning>> GetActiveOnlyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Warning>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Warning>> GetByAdopterIdAsync(int adopterId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Warning>> GetByAdoptionIdAsync(int adoptionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Warning>> GetByAnimalIdAsync(int animalId)
        {
            throw new NotImplementedException();
        }

        public Task<Warning?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Warning>> GetBySeverityAsync(WarningSeverity severity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Warning>> GetByTypeAsync(WarningType type)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Warning warning)
        {
            throw new NotImplementedException();
        }
    }
}
