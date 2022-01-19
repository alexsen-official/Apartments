using System.Linq;
using EFData.Entities;
using System.Collections.Generic;

namespace EFData.Repositories
{
    public class ProviderRepository
    {
        private readonly EFApartmentsContext _context;

        public ProviderRepository(EFApartmentsContext context)
        {
            _context = context;
        }
        public List<Provider> GetProviders()
        {
            return _context.Providers.ToList();
        }

        public Provider GetProviderById(int id)
        {
            return _context.Providers.FirstOrDefault(provider => provider.Id == id);
        }
        
        public Provider GetProviderByApartmentId(int apartmentId)
        {
            return _context.Providers.FirstOrDefault(provider => provider.ApartmentId == apartmentId);
        }
    }
}