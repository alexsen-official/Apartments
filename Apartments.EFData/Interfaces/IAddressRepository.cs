using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IAddressRepository
    {
        public IEnumerable<Address> GetAddresses();
        public Address GetAddressById(int id);
        public void CreateAddress(Address address);
        public void UpdateAddress(Address address);
        public void DeleteAddress(int id);
    }
}