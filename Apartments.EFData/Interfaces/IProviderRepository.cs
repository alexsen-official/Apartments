using System.Collections.Generic;
using System.Threading.Tasks;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IProviderRepository
    {
        public Task<IEnumerable<Provider>> GetProviders();
        public Task<Provider> GetProviderById(int id);
        public Task CreateProvider(Provider provider);
        public Task UpdateProvider(Provider provider);
        public Task DeleteProvider(int id);
    }
}