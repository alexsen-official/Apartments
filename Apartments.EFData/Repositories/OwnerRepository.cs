using System.Linq;
using EFData.Entities;
using System.Collections.Generic;

namespace EFData.Repositories
{
    public class OwnerRepository
    {
        private readonly EFApartmentsContext _context;

        public OwnerRepository(EFApartmentsContext context)
        {
            _context = context;
        }

        public List<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.FirstOrDefault(owner => owner.Id == id);
        }
    }
}