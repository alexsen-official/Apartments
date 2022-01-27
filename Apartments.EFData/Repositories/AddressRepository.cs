using System.Collections.Generic;
using System.Threading.Tasks;
using EfData.Entities;
using EfData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfData.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly EfApartmentsContext _context;

        public AddressRepository(EfApartmentsContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Address>> GetAddresses()
        {
            IEnumerable<Address> addresses = await _context.Addresses.ToListAsync();
            return addresses;
        }

        public async Task<Address> GetAddressById(int id)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(a => a.Id == id);
            return address;
        }

        public async Task CreateAddress(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAddress(Address address)
        {
            var dbAddress = await _context.Addresses.SingleOrDefaultAsync(a => a.Id == address.Id);

            if (dbAddress == null)
            {
                return;
            }
            
            dbAddress.FlatNumber = address.FlatNumber;
            dbAddress.HouseNumber = address.HouseNumber;
            dbAddress.StreetName = address.StreetName;
            dbAddress.Apartment = address.Apartment;
                
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteAddress(int id)
        {
            var dbAddress = await _context.Addresses.SingleOrDefaultAsync(a => a.Id == id);

            if (dbAddress == null)
            {
                return;
            }
            
            _context.Addresses.Remove(dbAddress);
            await _context.SaveChangesAsync();
        }
    }
}