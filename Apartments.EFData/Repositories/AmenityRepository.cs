using System.Linq;
using EFData.Entities;
using System.Collections.Generic;

namespace EFData.Repositories
{
    public class AmenityRepository
    {
        private readonly EFApartmentsContext _context;

        public AmenityRepository(EFApartmentsContext context)
        {
            _context = context;
        }
        
        public List<Amenity> GetAmenities()
        {
            return _context.Amenities.ToList();
        }

        public Amenity GetAmenityById(int id)
        {
            return _context.Amenities.FirstOrDefault(amenity => amenity.Id == id);
        }
    }
}