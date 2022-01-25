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
            return GetAmenities().FirstOrDefault();
        }
    }
}