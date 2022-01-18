using System.Linq;
using EFData.Entities;

namespace EFData.Repositories
{
    public class ApartmentRepository
    {
        private readonly ApartmentsDbContext _dbContext;

        public ApartmentRepository(ApartmentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Apartment GetApartmentById(int id)
        {
            return _dbContext.Apartments.FirstOrDefault(i => i.Id == id);
        }
    }
}