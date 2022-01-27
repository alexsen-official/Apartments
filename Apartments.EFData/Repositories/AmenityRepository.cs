using System.Collections.Generic;
using System.Linq;
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
            return _context.Amenities.SingleOrDefault(a => a.Id == id);
        }

        public void CreateAmenity(Amenity amenity)
        {
            _context.Amenities.Add(amenity);
            _context.SaveChanges();
        }
        
        public void UpdateAmenity(Amenity amenity)
        {
            Amenity dbAmenity = _context.Amenities.SingleOrDefault(a => a.Id == amenity.Id);

            if (dbAmenity == null)
            {
                return;
            }
            
            dbAmenity.Name = amenity.Name;
            dbAmenity.Apartments = amenity.Apartments;

            _context.SaveChanges();
        }
        
        public void DeleteAmenity(int id)
        {
            Amenity dbAmenity = _context.Amenities.SingleOrDefault(a => a.Id == id);

            if (dbAmenity == null)
            {
                return;
            }
            
            _context.Amenities.Remove(dbAmenity);
            _context.SaveChanges();
        }
    }
}