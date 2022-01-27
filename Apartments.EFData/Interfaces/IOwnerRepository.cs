using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IOwnerRepository
    {
        public IEnumerable<Owner> GetOwners();
        public Owner GetOwnerById(int id);
        public void CreateOwner(Owner owner);
        public void UpdateOwner(Owner owner);
        public void DeleteOwner(int id);
    }
}