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
            return _context.Providers.Find(id);
        }
        
        public IEnumerable<Provider> CreateProvider(Provider provider)
        {
            _context.Providers.Add(provider);
            _context.SaveChanges();

            return _context.Providers;
        }
        
        public IEnumerable<Provider> UpdateProvider(Provider provider)
        {
            Provider dbProvider = _context.Providers.Find(provider.Id);

            if (dbProvider != null)
            {
                dbProvider.Name = provider.Name;
                dbProvider.Apartments = provider.Apartments;

                _context.SaveChanges();
            }

            return _context.Providers;
        }
        
        public IEnumerable<Provider> DeleteProvider(int id)
        {
            Provider dbProvider = _context.Providers.Find(id);

            if (dbProvider != null)
            {
                _context.Providers.Remove(dbProvider);
                _context.SaveChanges();
            }

            return _context.Providers;
        }
    }
}