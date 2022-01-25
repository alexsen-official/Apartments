using System.Linq;
using System.Collections.Generic;
using EfData.Entities;
using EfData.Interfaces;

namespace EfData.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly EfApartmentsContext _context;

        public AddressRepository(EfApartmentsContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Address> GetAddresses()
        {
            return _context.Addresses;
        }

        public Address GetAddressById(int id)
        {
            return GetAddresses().FirstOrDefault(address => address.Id == id);
        }
    }
}