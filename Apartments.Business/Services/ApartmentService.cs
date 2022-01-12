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
        
        public ApartmentViewModel? GetApartmentById(int id)
        {
            InformationRepository informationRepository = new(_config);
            Information? information = informationRepository.GetInformationById(id);
            
            KindViewItem? kindViewItem = null;
            AddressViewItem? addressViewItem = null;
            OwnerViewItem? ownerViewItem = null;
            ProviderViewItem? providerViewItem = null;
            
            if (information == null)
            {
                return null;
            }

            if (information.Kind != null)
            {
                kindViewItem = new()
                {
                    Id = information.Kind.Id,
                    Name = information.Kind.Name
                };
            }

            if (information.Address != null)
            {
                addressViewItem = new()
                {
                    Id = information.Address.Id,
                    StreetName = information.Address.StreetName,
                    HouseNumber = information.Address.HouseNumber,
                    FlatNumber = information.Address.FlatNumber
                };
            }

            if (information.Owner != null)
            {
                ownerViewItem = new()
                {
                    Id = information.Owner.Id,
                    FirstName = information.Owner.FirstName,
                    LastName = information.Owner.LastName,
                    PhoneNumber = information.Owner.PhoneNumber
                };
            }

            if (information.Provider != null)
            {
                providerViewItem = new()
                {
                    Id = information.Provider.Id,
                    Name = information.Provider.Name
                };
            }
            
            List<AmenityViewItem> amenityViewItems = new();

            foreach (Amenity amenity in information.Amenities)
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
                Id = information.Id,
                Kind = kindViewItem,
                Address = addressViewItem,
                Owner = ownerViewItem,
                Provider = providerViewItem,
                Amenities = amenityViewItems,
                PetsAllowed = information.PetsAllowed,
                Price = information.Price
            };

            return apartmentViewModel;
        }
    }
}