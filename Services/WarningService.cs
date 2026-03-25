using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Services
{
    public class WarningService : IWarningService
    {
        private readonly PetAdoptionDbContext _context;
        public WarningService(PetAdoptionDbContext context)
        {
            _context = context;
        }

        public Task<Warning> CreateAsync(Warning warning)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeactivateAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<bool> UpdateAsync(Warning warning)
        {
            throw new NotImplementedException();
        }
    }
}
