using System.Collections.Generic;
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
            return _context.Owners.Find(id);
        }
        
        public IEnumerable<Owner> CreateOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();

            return _context.Owners;
        }
        
        public IEnumerable<Owner> UpdateOwner(Owner owner)
        {
            Owner dbOwner = _context.Owners.Find(owner.Id);

            if (dbOwner != null)
            {
                dbOwner.FirstName = owner.FirstName;
                dbOwner.LastName = owner.LastName;
                dbOwner.PhoneNumber = owner.PhoneNumber;
                dbOwner.Apartments = dbOwner.Apartments;

                _context.SaveChanges();
            }

            return _context.Owners;
        }
        
        public IEnumerable<Owner> DeleteOwner(int id)
        {
            Owner dbOwner = _context.Owners.Find(id);

            if (dbOwner != null)
            {
                _context.Owners.Remove(dbOwner);
                _context.SaveChanges();
            }

            return _context.Owners;
        }
    }
}