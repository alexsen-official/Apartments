using System.Linq;
using System.Collections.Generic;
using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
using EfData.Interfaces;

namespace Apartment.Business.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public IEnumerable<ApartmentViewModel> GetApartments()
        {
            List<EfData.Entities.Apartment> apartments = _apartmentRepository.GetApartments().ToList();
            List<ApartmentViewModel> apartmentViewModels = new();
            
            foreach (var apartment in apartments)
            {
                KindViewItem kindViewItem = null;
                AddressViewItem addressViewItem = null;
                OwnerViewItem ownerViewItem = null;
                ProviderViewItem providerViewItem = null;
            
                List<AmenityViewItem> amenityViewItems = new();
                
                if (apartment == null)
                {
                    continue;
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

                amenityViewItems.AddRange(
                    apartment.Amenities
                        .Select(amenity =>
                            new AmenityViewItem
                            {
                                Id = amenity.Id,
                                Name = amenity.Name
                            })
                );

                apartmentViewModels.Add(new ApartmentViewModel
                {
                    Id = apartment.Id,
                    Kind = kindViewItem,
                    Address = addressViewItem,
                    Owner = ownerViewItem,
                    Provider = providerViewItem,
                    Amenities = amenityViewItems,
                    PetsAllowed = apartment.PetsAllowed,
                    Price = apartment.Price
                });
            }

            return apartmentViewModels;
        }
        
        public ApartmentViewModel GetApartmentById(int id)
        {
            return GetApartments().FirstOrDefault();
        }
    }
}