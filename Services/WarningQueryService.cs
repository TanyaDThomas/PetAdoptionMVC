using Microsoft.EntityFrameworkCore;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;

namespace PetAdoptionMVC.Services
{
    public class WarningQueryService : IWarningQueryService
    {
        private readonly PetAdoptionDbContext _context;

        public WarningQueryService(PetAdoptionDbContext context)
        {
            _context = context;
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

        public Task<bool> AcknowledgeAsync(int warningId, string acknowledgedBy)
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
    }
}
