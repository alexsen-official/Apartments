using Apartments.Data.Entities;
using Apartments.Data.Repositories;
using Apartments.Models.ViewModel;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Apartment.Business.Services
{
    public class ApartmentService
    {
        private readonly IConfiguration _config;

        public ApartmentService(IConfiguration config)
        {
            _config = config;
        }
        
        public ApartmentViewModel GetApartmentById(int id)
        {
            ApartmentInfoRepository apartmentInfoRepository = new(_config);
            ApartmentInfo apartmentInfo = apartmentInfoRepository.GetInformationById(id);
            
            KindViewItem kindViewItem = null;
            AddressViewItem addressViewItem = null;
            OwnerViewItem ownerViewItem = null;
            ProviderViewItem providerViewItem = null;
            
            List<AmenityViewItem> amenityViewItems = new();

            if (apartmentInfo == null)
            {
                return null;
            }
            
            if (apartmentInfo.Kind != null)
            {
                kindViewItem = new KindViewItem
                {
                    Id = apartmentInfo.Kind.Id,
                    Name = apartmentInfo.Kind.Name
                };
            }

            if (apartmentInfo.Address != null)
            {
                addressViewItem = new AddressViewItem
                {
                    Id = apartmentInfo.Address.Id,
                    StreetName = apartmentInfo.Address.StreetName,
                    HouseNumber = apartmentInfo.Address.HouseNumber,
                    FlatNumber = apartmentInfo.Address.FlatNumber
                };
            }

            if (apartmentInfo.Owner != null)
            {
                ownerViewItem = new OwnerViewItem
                {
                    Id = apartmentInfo.Owner.Id,
                    FirstName = apartmentInfo.Owner.FirstName,
                    LastName = apartmentInfo.Owner.LastName,
                    PhoneNumber = apartmentInfo.Owner.PhoneNumber
                };
            }

            if (apartmentInfo.Provider != null)
            {
                providerViewItem = new ProviderViewItem
                {
                    Id = apartmentInfo.Provider.Id,
                    Name = apartmentInfo.Provider.Name
                };
            }

            if (apartmentInfo.Amenities != null)
            {
                foreach (Amenity amenity in apartmentInfo.Amenities)
                {
                    amenityViewItems.Add(
                        new AmenityViewItem
                        {
                            Id = amenity.Id,
                            Name = amenity.Name
                        }
                    );
                }
            }

            return new ApartmentViewModel 
            {
                Id = apartmentInfo.Id,
                Kind = kindViewItem,
                Address = addressViewItem,
                Owner = ownerViewItem,
                Provider = providerViewItem,
                Amenities = amenityViewItems,
                PetsAllowed = apartmentInfo.PetsAllowed,
                Price = apartmentInfo.Price
            };
        }
    }
}