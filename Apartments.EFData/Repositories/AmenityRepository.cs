using System.Collections.Generic;
using System.Threading.Tasks;
using EfData.Entities;
using EfData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfData.Repositories
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly EfApartmentsContext _context;

        public AmenityRepository(EfApartmentsContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        public async Task<Amenity> GetAmenityById(int id)
        {
            var amenity = await _context.Amenities.SingleOrDefaultAsync(a => a.Id == id);
            return amenity;
        }

        public async Task CreateAmenity(Amenity amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAmenity(Amenity amenity)
        {
            var dbAmenity = await _context.Amenities.SingleOrDefaultAsync(a => a.Id == amenity.Id);

            if (dbAmenity == null)
            {
                return;
            }
            
            dbAmenity.Name = amenity.Name;
            dbAmenity.Apartments = amenity.Apartments;

            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteAmenity(int id)
        {
            var dbAmenity = await _context.Amenities.SingleOrDefaultAsync(a => a.Id == id);

            if (dbAmenity == null)
            {
                return;
            }
            
            _context.Amenities.Remove(dbAmenity);
            await _context.SaveChangesAsync();
        }
    }
}