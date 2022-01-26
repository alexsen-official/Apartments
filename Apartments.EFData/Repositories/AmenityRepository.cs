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
            return _context.Amenities.Find(id);
        }

        public IEnumerable<Amenity> CreateAmenity(Amenity amenity)
        {
            _context.Amenities.Add(amenity);
            _context.SaveChanges();

            return _context.Amenities;
        }
        
        public IEnumerable<Amenity> UpdateAmenity(Amenity amenity)
        {
            Amenity dbAmenity = _context.Amenities.Find(amenity.Id);

            if (dbAmenity != null)
            {
                dbAmenity.Name = amenity.Name;
                dbAmenity.Apartments = amenity.Apartments;

                _context.SaveChanges();
            }

            return _context.Amenities;
        }
        
        public IEnumerable<Amenity> DeleteAmenity(int id)
        {
            Amenity dbAmenity = _context.Amenities.Find(id);

            if (dbAmenity != null)
            {
                _context.Amenities.Remove(dbAmenity);
                _context.SaveChanges();
            }

            return _context.Amenities;
        }
    }
}