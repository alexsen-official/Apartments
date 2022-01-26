using System.Linq;
using System.Collections.Generic;
using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
using EfData.Entities;
using EfData.Interfaces;

namespace Apartment.Business.Services
{
    public class AmenityService : IAmenityService
    {
        private readonly IAmenityRepository _amenityRepository;

        public AmenityService(IAmenityRepository amenityRepository)
        {
            _amenityRepository = amenityRepository;
        }
        
        public IEnumerable<AmenityViewItem> GetAmenities()
        {
            IEnumerable<Amenity> amenities = _amenityRepository.GetAmenities();

            return amenities.Select(amenity => 
                new AmenityViewItem 
                {
                    Id = amenity.Id,
                    Name = amenity.Name
                });
        }

        public AmenityViewItem GetAmenityById(int id)
        {
            Amenity amenity = _amenityRepository.GetAmenityById(id);
            
            return new AmenityViewItem 
            {
                Id = amenity.Id,
                Name = amenity.Name
            };
        }
        
        public IEnumerable<AmenityViewItem> CreateAmenity(AmenityViewItem amenityViewItem)
        {
            Amenity amenity = new()
            {
                Id = amenityViewItem.Id,
                Name = amenityViewItem.Name
            };
            
            IEnumerable<Amenity> amenities = _amenityRepository.CreateAmenity(amenity);
            
            return amenities.Select(a => 
                new AmenityViewItem() 
                {
                    Id = a.Id,
                    Name = a.Name
                });
        }
        
        public IEnumerable<AmenityViewItem> UpdateAmenity(AmenityViewItem amenityViewItem)
        {
            Amenity amenity = new()
            {
                Id = amenityViewItem.Id,
                Name = amenityViewItem.Name
            };
            
            IEnumerable<Amenity> amenities = _amenityRepository.UpdateAmenity(amenity);
            
            return amenities.Select(a => 
                new AmenityViewItem
                {
                    Id = a.Id,
                    Name = a.Name
                });
        }
        
        public IEnumerable<AmenityViewItem> DeleteAmenity(int id)
        {
            IEnumerable<Amenity> amenities = _amenityRepository.DeleteAmenity(id);
            
            return amenities.Select(a => 
                new AmenityViewItem() 
                {
                    Id = a.Id,
                    Name = a.Name
                });
        }
    }
}