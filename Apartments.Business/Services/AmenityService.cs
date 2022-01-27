using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task<IEnumerable<AmenityViewItem>> GetAmenities()
        {
            var amenities = await _amenityRepository.GetAmenities();

            return amenities.Select(amenity => 
                new AmenityViewItem 
                {
                    Id = amenity.Id,
                    Name = amenity.Name
                });
        }

        public async Task<AmenityViewItem> GetAmenityById(int id)
        {
            var amenity = await _amenityRepository.GetAmenityById(id);
            
            return new AmenityViewItem 
            {
                Id = amenity.Id,
                Name = amenity.Name
            };
        }
        
        public async Task<IEnumerable<AmenityViewItem>> CreateAmenity(AmenityViewItem amenityViewItem)
        {
            Amenity amenity = new()
            {
                Id = amenityViewItem.Id,
                Name = amenityViewItem.Name
            };
            
            await _amenityRepository.CreateAmenity(amenity);
            return await GetAmenities();
        }
        
        public async Task<IEnumerable<AmenityViewItem>> UpdateAmenity(AmenityViewItem amenityViewItem)
        {
            Amenity amenity = new()
            {
                Id = amenityViewItem.Id,
                Name = amenityViewItem.Name
            };
            
            await _amenityRepository.UpdateAmenity(amenity);
            return await GetAmenities();
        }
        
        public async Task<IEnumerable<AmenityViewItem>> DeleteAmenity(int id)
        {
            await _amenityRepository.DeleteAmenity(id);
            return await GetAmenities();
        }
    }
}