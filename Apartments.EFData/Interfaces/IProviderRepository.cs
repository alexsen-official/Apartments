using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IProviderRepository
    {
        public IEnumerable<Provider> GetProviders();
        public Provider GetProviderById(int id);
    }
}