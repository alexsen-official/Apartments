using System.Collections.Generic;
using System.Threading.Tasks;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IOwnerRepository
    {
        public Task<IEnumerable<Owner>> GetOwners();
        public Task<Owner> GetOwnerById(int id);
        public Task CreateOwner(Owner owner);
        public Task UpdateOwner(Owner owner);
        public Task DeleteOwner(int id);
    }
}