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
            return GetAddresses().FirstOrDefault();
        }
    }
}