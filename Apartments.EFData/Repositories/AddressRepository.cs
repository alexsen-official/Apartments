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
            return _context.Addresses.Find(id);
        }

        public IEnumerable<Address> CreateAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();

            return _context.Addresses;
        }

        public IEnumerable<Address> UpdateAddress(Address address)
        {
            Address dbAddress = _context.Addresses.Find(address.Id);

            if (dbAddress != null)
            {
                dbAddress.FlatNumber = address.FlatNumber;
                dbAddress.HouseNumber = address.HouseNumber;
                dbAddress.StreetName = address.StreetName;
                dbAddress.Apartment = address.Apartment;
                
                _context.SaveChanges();
            }

            return _context.Addresses;
        }
        
        public IEnumerable<Address> DeleteAddress(int id)
        {
            Address dbAddress = _context.Addresses.Find(id);

            if (dbAddress != null)
            {
                _context.Addresses.Remove(dbAddress);
                _context.SaveChanges();
            }

            return _context.Addresses;
        }
    }
}