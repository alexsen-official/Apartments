using System.Collections.Generic;
using System.Threading.Tasks;
using EfData.Entities;
using EfData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfData.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly EfApartmentsContext _context;

        public ProviderRepository(EfApartmentsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Provider>> GetProviders()
        {
            var providers = await _context.Providers.ToListAsync();
            return providers;
        }

        public async Task<Provider> GetProviderById(int id)
        {
            var provider = await _context.Providers.SingleOrDefaultAsync(p => p.Id == id);
            return provider;
        }
        
        public async Task CreateProvider(Provider provider)
        {
            _context.Providers.Add(provider);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateProvider(Provider provider)
        {
            var dbProvider = await _context.Providers.SingleOrDefaultAsync(p => p.Id == provider.Id);

            if (dbProvider == null)
            {
                return;
            }
            
            dbProvider.Name = provider.Name;
            dbProvider.Apartments = provider.Apartments;

            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteProvider(int id)
        {
            var dbProvider = await _context.Providers.SingleOrDefaultAsync(p => p.Id == id);

            if (dbProvider == null)
            {
                return;
            }
            
            _context.Providers.Remove(dbProvider);
            await _context.SaveChangesAsync();
        }
    }
}