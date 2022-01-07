using System.Linq;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class AddressRepository
    {
        private readonly ApartmentsDbContext _dbContext;

        public AddressRepository(ApartmentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Address? GetAddressById(int id)
        {
            return _dbContext.Addresses.FirstOrDefault(i => i.Id == id);
        }
    }
}