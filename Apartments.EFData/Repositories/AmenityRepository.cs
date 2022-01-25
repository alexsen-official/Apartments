using System.Linq;
using System.Collections.Generic;
using EfData.Entities;
using EfData.Interfaces;

namespace EfData.Repositories
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly EfApartmentsContext _context;

        public AmenityRepository(EfApartmentsContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Amenity> GetAmenities()
        {
            return _context.Amenities;
        }

        public Amenity GetAmenityById(int id)
        {
            return GetAmenities().FirstOrDefault(amenity => amenity.Id == id);
        }
    }
}