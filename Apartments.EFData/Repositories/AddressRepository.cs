using System.Collections.Generic;
using System.Linq;
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
            return _context.Addresses.SingleOrDefault(a => a.Id == id);
        }

        public void CreateAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            Address dbAddress = _context.Addresses.SingleOrDefault(a => a.Id == address.Id);

            if (dbAddress == null)
            {
                return;
            }
            
            dbAddress.FlatNumber = address.FlatNumber;
            dbAddress.HouseNumber = address.HouseNumber;
            dbAddress.StreetName = address.StreetName;
            dbAddress.Apartment = address.Apartment;
                
            _context.SaveChanges();
        }
        
        public void DeleteAddress(int id)
        {
            Address dbAddress = _context.Addresses.SingleOrDefault(a => a.Id == id);

            if (dbAddress == null)
            {
                return;
            }
            
            _context.Addresses.Remove(dbAddress);
            _context.SaveChanges();
        }
    }
}