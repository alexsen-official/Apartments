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
            ApartmentInfo? apartmentInfo = apartmentInfoRepository.GetInformationById(id);
            
            KindViewItem? kindViewItem = null;
            AddressViewItem? addressViewItem = null;
            OwnerViewItem? ownerViewItem = null;
            ProviderViewItem? providerViewItem = null;
            
            if (apartmentInfo == null)
            {
                return new ApartmentViewModel();
            }

            if (apartmentInfo.Kind != null)
            {
                kindViewItem = new()
                {
                    Id = apartmentInfo.Kind.Id,
                    Name = apartmentInfo.Kind.Name
                };
            }

            if (apartmentInfo.Address != null)
            {
                addressViewItem = new()
                {
                    Id = apartmentInfo.Address.Id,
                    StreetName = apartmentInfo.Address.StreetName,
                    HouseNumber = apartmentInfo.Address.HouseNumber,
                    FlatNumber = apartmentInfo.Address.FlatNumber
                };
            }

            if (apartmentInfo.Owner != null)
            {
                ownerViewItem = new()
                {
                    Id = apartmentInfo.Owner.Id,
                    FirstName = apartmentInfo.Owner.FirstName,
                    LastName = apartmentInfo.Owner.LastName,
                    PhoneNumber = apartmentInfo.Owner.PhoneNumber
                };
            }

            if (apartmentInfo.Provider != null)
            {
                providerViewItem = new()
                {
                    Id = apartmentInfo.Provider.Id,
                    Name = apartmentInfo.Provider.Name
                };
            }
            
            List<AmenityViewItem> amenityViewItems = new();

            foreach (Amenity amenity in apartmentInfo.Amenities)
            {
                AmenityViewItem item = new()
                {
                    Id = amenity.Id,
                    Name = amenity.Name
                };
                
                amenityViewItems.Add(item);
            }

            ApartmentViewModel apartmentViewModel = new()
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

            return apartmentViewModel;
        }
    }
}