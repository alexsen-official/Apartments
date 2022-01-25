using System.Linq;
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
            return GetOwners().FirstOrDefault(owner => owner.Id == id);
        }
    }
}