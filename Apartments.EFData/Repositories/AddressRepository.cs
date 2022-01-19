using System.Linq;
using EFData.Entities;
using System.Collections.Generic;

namespace EFData.Repositories
{
    public class AddressRepository
    {
        private readonly EFApartmentsContext _context;

        public AddressRepository(EFApartmentsContext context)
        {
            _context = context;
        }
        
        public List<Address> GetAddresses()
        {
            return _context.Addresses.ToList();
        }

        public Address GetAddressById(int id)
        {
            return _context.Addresses.FirstOrDefault(address => address.Id == id);
        }
        
        public Address GetAddressByApartmentId(int apartmentId)
        {
            return _context.Addresses.FirstOrDefault(address => address.ApartmentId == apartmentId);
        }
    }
}