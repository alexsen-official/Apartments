using System.Linq;
using System.Collections.Generic;
using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
using EfData.Entities;
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
            return GetApartments().FirstOrDefault(apartment => apartment.Id == id);
        }
        
        public IEnumerable<ApartmentViewModel> CreateApartment(ApartmentViewModel apartmentViewModel)
        {
            Kind kind = null;
            Address address = null;
            Owner owner = null;
            Provider provider = null;
            List<Amenity> amenities = new();
            
            if (apartmentViewModel.Kind != null)
            {
                kind = new Kind
                {
                    Id = apartmentViewModel.Kind.Id,
                    Name = apartmentViewModel.Kind.Name
                };
            }
            
            if (apartmentViewModel.Address != null)
            {
                address = new Address
                {
                    Id = apartmentViewModel.Address.Id,
                    StreetName = apartmentViewModel.Address.StreetName,
                    HouseNumber = apartmentViewModel.Address.HouseNumber,
                    FlatNumber = apartmentViewModel.Address.FlatNumber
                };
            }

            if (apartmentViewModel.Owner != null)
            {
                owner = new Owner
                {
                    Id = apartmentViewModel.Owner.Id,
                    FirstName = apartmentViewModel.Owner.FirstName,
                    LastName = apartmentViewModel.Owner.LastName,
                    PhoneNumber = apartmentViewModel.Owner.PhoneNumber
                };
            }

            if (apartmentViewModel.Provider != null)
            {
                provider = new Provider
                {
                    Id = apartmentViewModel.Provider.Id,
                    Name = apartmentViewModel.Provider.Name
                };
            }
            
            amenities.AddRange(
                apartmentViewModel.Amenities
                    .Select(amenity =>
                        new Amenity
                        {
                            Id = amenity.Id,
                            Name = amenity.Name
                        })
            );
            
            EfData.Entities.Apartment apartment = new()
            {
                Id = apartmentViewModel.Id,
                Kind = kind,
                Address = address,
                Owner = owner,
                Provider = provider,
                Amenities = amenities,
                PetsAllowed = apartmentViewModel.PetsAllowed,
                Price = apartmentViewModel.Price
            };
            
            _apartmentRepository.CreateApartment(apartment);
            return GetApartments();
        }
        
        public IEnumerable<ApartmentViewModel> UpdateApartment(ApartmentViewModel apartmentViewModel)
        {
            Kind kind = null;
            Address address = null;
            Owner owner = null;
            Provider provider = null;
            List<Amenity> amenities = new();
            
            if (apartmentViewModel.Kind != null)
            {
                kind = new Kind
                {
                    Id = apartmentViewModel.Kind.Id,
                    Name = apartmentViewModel.Kind.Name
                };
            }
            
            if (apartmentViewModel.Address != null)
            {
                address = new Address
                {
                    Id = apartmentViewModel.Address.Id,
                    StreetName = apartmentViewModel.Address.StreetName,
                    HouseNumber = apartmentViewModel.Address.HouseNumber,
                    FlatNumber = apartmentViewModel.Address.FlatNumber
                };
            }

            if (apartmentViewModel.Owner != null)
            {
                owner = new Owner
                {
                    Id = apartmentViewModel.Owner.Id,
                    FirstName = apartmentViewModel.Owner.FirstName,
                    LastName = apartmentViewModel.Owner.LastName,
                    PhoneNumber = apartmentViewModel.Owner.PhoneNumber
                };
            }

            if (apartmentViewModel.Provider != null)
            {
                provider = new Provider
                {
                    Id = apartmentViewModel.Provider.Id,
                    Name = apartmentViewModel.Provider.Name
                };
            }
            
            amenities.AddRange(
                apartmentViewModel.Amenities
                    .Select(amenity =>
                        new Amenity
                        {
                            Id = amenity.Id,
                            Name = amenity.Name
                        })
            );
            
            EfData.Entities.Apartment apartment = new()
            {
                Id = apartmentViewModel.Id,
                Kind = kind,
                Address = address,
                Owner = owner,
                Provider = provider,
                Amenities = amenities,
                PetsAllowed = apartmentViewModel.PetsAllowed,
                Price = apartmentViewModel.Price
            };
            
            _apartmentRepository.UpdateApartment(apartment);
            return GetApartments();
        }
        
        public IEnumerable<ApartmentViewModel> DeleteApartment(int id)
        {
            _apartmentRepository.DeleteApartment(id);
            return GetApartments();
        }
    }
}