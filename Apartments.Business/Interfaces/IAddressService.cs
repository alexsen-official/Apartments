using System.Collections.Generic;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IAddressService
    {
        public IEnumerable<AddressViewItem> GetAddresses();
        public AddressViewItem GetAddressById(int id);
    }
}