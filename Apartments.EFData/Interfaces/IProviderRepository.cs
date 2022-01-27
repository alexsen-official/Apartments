using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IProviderRepository
    {
        public IEnumerable<Provider> GetProviders();
        public Provider GetProviderById(int id);
        public void CreateProvider(Provider provider);
        public void UpdateProvider(Provider provider);
        public void DeleteProvider(int id);
    }
}