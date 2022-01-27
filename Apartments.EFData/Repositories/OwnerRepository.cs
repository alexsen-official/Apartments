using System.Collections.Generic;
using System.Threading.Tasks;
using EfData.Entities;
using EfData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfData.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly EfApartmentsContext _context;

        public OwnerRepository(EfApartmentsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Owner>> GetOwners()
        {
            var owners = await _context.Owners.ToListAsync();
            return owners;
        }

        public async Task<Owner> GetOwnerById(int id)
        {
            var owner = await _context.Owners.SingleOrDefaultAsync(o => o.Id == id);
            return owner;
        }
        
        public async Task CreateOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateOwner(Owner owner)
        {
            var dbOwner = await _context.Owners.SingleOrDefaultAsync(o => o.Id == owner.Id);

            if (dbOwner == null)
            {
                return;
            }
            
            dbOwner.FirstName = owner.FirstName;
            dbOwner.LastName = owner.LastName;
            dbOwner.PhoneNumber = owner.PhoneNumber;
            dbOwner.Apartments = dbOwner.Apartments;

            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteOwner(int id)
        {
            var dbOwner = await _context.Owners.SingleOrDefaultAsync(o => o.Id == id);

            if (dbOwner == null)
            {
                return;
            }
            
            _context.Owners.Remove(dbOwner);
            await _context.SaveChangesAsync();
        }
    }
}