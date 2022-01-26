using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IAmenityRepository
    {
        public IEnumerable<Amenity> GetAmenities();
        public Amenity GetAmenityById(int id);
        public IEnumerable<Amenity> CreateAmenity(Amenity amenity);
        public IEnumerable<Amenity> UpdateAmenity(Amenity amenity);
        public IEnumerable<Amenity> DeleteAmenity(int id);
    }
}