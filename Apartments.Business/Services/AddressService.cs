using System.Linq;
using System.Collections.Generic;
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
        
        public IEnumerable<AddressViewItem> GetAddresses()
        {
            IEnumerable<Address> addresses = _addressRepository.GetAddresses();

            return addresses.Select(address => 
                new AddressViewItem 
                {
                    Id = address.Id,
                    StreetName = address.StreetName,
                    HouseNumber = address.HouseNumber,
                    FlatNumber = address.FlatNumber
                });
        }

        public AddressViewItem GetAddressById(int id)
        {
            Address address = _addressRepository.GetAddressById(id);
            
            return new AddressViewItem 
            {
                Id = address.Id,
                StreetName = address.StreetName,
                HouseNumber = address.HouseNumber,
                FlatNumber = address.FlatNumber
            };
        }

        public IEnumerable<AddressViewItem> CreateAddress(AddressViewItem addressViewItem)
        {
            Address address = new()
            {
                Id = addressViewItem.Id,
                HouseNumber = addressViewItem.HouseNumber,
                FlatNumber = addressViewItem.FlatNumber,
                StreetName = addressViewItem.StreetName
            };
            
            _addressRepository.CreateAddress(address);
            return GetAddresses();
        }
        
        public IEnumerable<AddressViewItem> UpdateAddress(AddressViewItem addressViewItem)
        {
            Address address = new()
            {
                Id = addressViewItem.Id,
                HouseNumber = addressViewItem.HouseNumber,
                FlatNumber = addressViewItem.FlatNumber,
                StreetName = addressViewItem.StreetName
            };
            
            _addressRepository.UpdateAddress(address);
            return GetAddresses();
        }
        
        public IEnumerable<AddressViewItem> DeleteAddress(int id)
        {
            _addressRepository.DeleteAddress(id);
            return GetAddresses();
        }
    }
}