using System.Collections.Generic;
using System.Linq;
using EfData.Entities;
using EfData.Interfaces;

namespace EfData.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly EfApartmentsContext _context;

        public OwnerRepository(EfApartmentsContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _context.Owners;
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.SingleOrDefault(o => o.Id == id);
        }
        
        public void CreateOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }
        
        public void UpdateOwner(Owner owner)
        {
            Owner dbOwner = _context.Owners.SingleOrDefault(o => o.Id == owner.Id);

            if (dbOwner == null)
            {
                return;
            }
            
            dbOwner.FirstName = owner.FirstName;
            dbOwner.LastName = owner.LastName;
            dbOwner.PhoneNumber = owner.PhoneNumber;
            dbOwner.Apartments = dbOwner.Apartments;

            _context.SaveChanges();
        }
        
        public void DeleteOwner(int id)
        {
            Owner dbOwner =_context.Owners.SingleOrDefault(o => o.Id == id);

            if (dbOwner == null)
            {
                return;
            }
            
            _context.Owners.Remove(dbOwner);
            _context.SaveChanges();
        }
    }
}