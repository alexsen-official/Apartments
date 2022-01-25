using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IAddressRepository
    {
        public IEnumerable<Address> GetAddresses();
        public Address GetAddressById(int id);
    }
}