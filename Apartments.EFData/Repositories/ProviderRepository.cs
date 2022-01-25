using System.Linq;
using System.Collections.Generic;
using EfData.Entities;
using EfData.Interfaces;

namespace EfData.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly EfApartmentsContext _context;

        public ProviderRepository(EfApartmentsContext context)
        {
            _context = context;
        }
        public IEnumerable<Provider> GetProviders()
        {
            return _context.Providers;
        }

        public Provider GetProviderById(int id)
        {
            return GetProviders().FirstOrDefault(provider => provider.Id == id);
        }
    }
}