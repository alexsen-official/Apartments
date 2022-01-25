using EFData;
using EFData.Entities;
using EFData.Repositories;
using Apartments.Models.ViewModel;
using System.Collections.Generic;
using Apartment.Business.Services.Interfaces;

namespace Apartment.Business.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }
        
        public ApartmentViewModel GetApartmentById(int id)
        {
            EFData.Entities.Apartment apartment = _apartmentRepository.GetApartmentById(id);
            
            KindViewItem kindViewItem = null;
            AddressViewItem addressViewItem = null;
            OwnerViewItem ownerViewItem = null;
            ProviderViewItem providerViewItem = null;
            
            List<AmenityViewItem> amenityViewItems = new();

            if (apartment == null)
            {
                return null;
            }
            
            if (apartment.Kind != null)
            {
                kindViewItem = new KindViewItem
                {
                    Id = apartment.Kind.Id,
                    Name = apartment.Kind.Name
                };
            }

            if (apartment.Address != null)
            {
                addressViewItem = new AddressViewItem
                {
                    Id = apartment.Address.Id,
                    StreetName = apartment.Address.StreetName,
                    HouseNumber = apartment.Address.HouseNumber,
                    FlatNumber = apartment.Address.FlatNumber
                };
            }

            if (apartment.Owner != null)
            {
                ownerViewItem = new OwnerViewItem
                {
                    Id = apartment.Owner.Id,
                    FirstName = apartment.Owner.FirstName,
                    LastName = apartment.Owner.LastName,
                    PhoneNumber = apartment.Owner.PhoneNumber
                };
            }

            if (apartment.Provider != null)
            {
                providerViewItem = new ProviderViewItem
                {
                    Id = apartment.Provider.Id,
                    Name = apartment.Provider.Name
                };
            }

            if (apartment.Amenities != null)
            {
                foreach (Amenity amenity in apartment.Amenities)
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
                Id = apartment.Id,
                Kind = kindViewItem,
                Address = addressViewItem,
                Owner = ownerViewItem,
                Provider = providerViewItem,
                Amenities = amenityViewItems,
                PetsAllowed = apartment.PetsAllowed,
                Price = apartment.Price
            };
        }
    }
}