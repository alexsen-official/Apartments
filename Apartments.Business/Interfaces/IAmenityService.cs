using System.Collections.Generic;
using System.Threading.Tasks;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IAmenityService
    {
        public Task<IEnumerable<AmenityViewItem>> GetAmenities();
        public Task<AmenityViewItem> GetAmenityById(int id);
        public Task<IEnumerable<AmenityViewItem>> CreateAmenity(AmenityViewItem amenityViewItem);
        public Task<IEnumerable<AmenityViewItem>> UpdateAmenity(AmenityViewItem amenityViewItem);
        public Task<IEnumerable<AmenityViewItem>> DeleteAmenity(int id);
    }
}