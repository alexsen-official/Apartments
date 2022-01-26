using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IOwnerRepository
    {
        public IEnumerable<Owner> GetOwners();
        public Owner GetOwnerById(int id);
        public IEnumerable<Owner> CreateOwner(Owner owner);
        public IEnumerable<Owner> UpdateOwner(Owner owner);
        public IEnumerable<Owner> DeleteOwner(int id);
    }
}