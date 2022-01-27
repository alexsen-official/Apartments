using System.Collections.Generic;
using System.Threading.Tasks;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IAddressService
    {
        public Task<IEnumerable<AddressViewItem>> GetAddresses();
        public Task<AddressViewItem> GetAddressById(int id);
        public Task<IEnumerable<AddressViewItem>> CreateAddress(AddressViewItem addressViewItem);
        public Task<IEnumerable<AddressViewItem>> UpdateAddress(AddressViewItem addressViewItem);
        public Task<IEnumerable<AddressViewItem>> DeleteAddress(int id);
    }
}