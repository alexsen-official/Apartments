using System.Collections.Generic;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IAmenityService
    {
        public IEnumerable<AmenityViewItem> GetAmenities();
        public AmenityViewItem GetAmenityById(int id);
        public IEnumerable<AmenityViewItem> CreateAmenity(AmenityViewItem amenityViewItem);
        public IEnumerable<AmenityViewItem> UpdateAmenity(AmenityViewItem amenityViewItem);
        public IEnumerable<AmenityViewItem> DeleteAmenity(int id);
    }
}