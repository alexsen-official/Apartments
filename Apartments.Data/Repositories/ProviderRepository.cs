using System.Linq;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class ProviderRepository
    {
        private readonly ApartmentsDbContext _dbContext;

        public ProviderRepository(ApartmentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Provider? GetProviderById(int id)
        {
            return _dbContext.Providers.FirstOrDefault(i => i.Id == id);
        }
    }
}