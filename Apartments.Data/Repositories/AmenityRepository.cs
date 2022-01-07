using System.Linq;
using Apartments.Data.Entities;
using System.Collections.Generic;

namespace Apartments.Data.Repositories
{
    public class AmenityRepository
    {
        private readonly ApartmentsDbContext _dbContext;

        public AmenityRepository(ApartmentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Amenity> GetAmenitiesByApartmentId(int id)
        {
            return _dbContext.ApartmentAmenities
                .Where(i => i.ApartmentId == id)
                .Join(_dbContext.Amenities,
                    apartmentAmenity => apartmentAmenity.AmenityId,
                    amenity => amenity.Id,
                    (apartmentAmenity, amenity) => amenity)
                .ToList();
        }
    }
}