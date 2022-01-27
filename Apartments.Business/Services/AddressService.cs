using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
using EfData.Entities;
using EfData.Interfaces;

namespace Apartment.Business.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        
        public async Task<IEnumerable<AddressViewItem>> GetAddresses()
        {
            var addresses = await _addressRepository.GetAddresses();

            return addresses.Select(address => 
                new AddressViewItem 
                {
                    Id = address.Id,
                    StreetName = address.StreetName,
                    HouseNumber = address.HouseNumber,
                    FlatNumber = address.FlatNumber
                });
        }

        public async Task<AddressViewItem> GetAddressById(int id)
        {
            var address = await _addressRepository.GetAddressById(id);
            
            return new AddressViewItem 
            {
                Id = address.Id,
                StreetName = address.StreetName,
                HouseNumber = address.HouseNumber,
                FlatNumber = address.FlatNumber
            };
        }

        public async Task<IEnumerable<AddressViewItem>> CreateAddress(AddressViewItem addressViewItem)
        {
            Address address = new()
            {
                Id = addressViewItem.Id,
                HouseNumber = addressViewItem.HouseNumber,
                FlatNumber = addressViewItem.FlatNumber,
                StreetName = addressViewItem.StreetName
            };
            
            await _addressRepository.CreateAddress(address);
            return await GetAddresses();
        }
        
        public async Task<IEnumerable<AddressViewItem>> UpdateAddress(AddressViewItem addressViewItem)
        {
            Address address = new()
            {
                Id = addressViewItem.Id,
                HouseNumber = addressViewItem.HouseNumber,
                FlatNumber = addressViewItem.FlatNumber,
                StreetName = addressViewItem.StreetName
            };
            
            await _addressRepository.UpdateAddress(address);
            return await GetAddresses();
        }
        
        public async Task<IEnumerable<AddressViewItem>> DeleteAddress(int id)
        {
            await _addressRepository.DeleteAddress(id);
            return await GetAddresses();
        }
    }
}