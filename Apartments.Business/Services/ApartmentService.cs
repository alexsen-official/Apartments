using Apartments.Data;
using Apartments.Data.Entities;
using Apartments.Data.Repositories;
using Apartments.Models.ViewModel;
using System.Collections.Generic;

namespace Apartment.Business.Services
{
    public class ApartmentService
    {
        private readonly ApartmentsDbContext _dbContext;

        public ApartmentService(ApartmentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public ApartmentViewModel? GetApartmentById(int id)
        {
            InformationRepository informationRepository = new(_dbContext);
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
                Id = information.Apartment.Id,
                Kind = kindViewItem,
                Address = addressViewItem,
                Owner = ownerViewItem,
                Provider = providerViewItem,
                Amenities = amenityViewItems,
                PetsAllowed = information.Apartment.PetsAllowed,
                Price = information.Apartment.Price
            };

            return apartmentViewModel;
        }
    }
}