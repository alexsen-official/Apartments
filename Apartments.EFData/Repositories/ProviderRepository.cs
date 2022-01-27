using System.Collections.Generic;
using System.Linq;
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
            return _context.Providers.SingleOrDefault(p => p.Id == id);
        }
        
        public void CreateProvider(Provider provider)
        {
            _context.Providers.Add(provider);
            _context.SaveChanges();
        }
        
        public void UpdateProvider(Provider provider)
        {
            Provider dbProvider = _context.Providers.SingleOrDefault(p => p.Id == provider.Id);

            if (dbProvider == null)
            {
                return;
            }
            
            dbProvider.Name = provider.Name;
            dbProvider.Apartments = provider.Apartments;

            _context.SaveChanges();
        }
        
        public void DeleteProvider(int id)
        {
            Provider dbProvider = _context.Providers.SingleOrDefault(p => p.Id == id);

            if (dbProvider == null)
            {
                return;
            }
            
            _context.Providers.Remove(dbProvider);
            _context.SaveChanges();
        }
    }
}