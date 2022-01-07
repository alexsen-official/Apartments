using System.Linq;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class OwnerRepository
    {
        private readonly ApartmentsDbContext _dbContext;

        public OwnerRepository(ApartmentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Owner? GetOwnerById(int id)
        {
            return _dbContext.Owners.FirstOrDefault(i => i.Id == id);
        }
    }
}