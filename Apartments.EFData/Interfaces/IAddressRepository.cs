using System.Collections.Generic;
using System.Threading.Tasks;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IAddressRepository
    {
        public Task<IEnumerable<Address>> GetAddresses();
        public Task<Address> GetAddressById(int id);
        public Task CreateAddress(Address address);
        public Task UpdateAddress(Address address);
        public Task DeleteAddress(int id);
    }
}