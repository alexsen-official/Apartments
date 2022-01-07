using System.Linq;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class KindRepository
    {
        private readonly ApartmentsDbContext _dbContext;

        public KindRepository(ApartmentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Kind? GetKindById(int id)
        {
            return _dbContext.Kinds.FirstOrDefault(i => i.Id == id);
        }
    }
}