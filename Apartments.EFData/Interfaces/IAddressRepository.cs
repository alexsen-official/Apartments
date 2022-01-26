using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IAddressRepository
    {
        public IEnumerable<Address> GetAddresses();
        public Address GetAddressById(int id);
        public IEnumerable<Address> CreateAddress(Address address);
        public IEnumerable<Address> UpdateAddress(Address address);
        public IEnumerable<Address> DeleteAddress(int id);
    }
}