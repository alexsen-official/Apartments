using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IAmenityRepository
    {
        public IEnumerable<Amenity> GetAmenities();
        public Amenity GetAmenityById(int id);
    }
}