using System.Collections.Generic;
using System.Threading.Tasks;
using EfData.Entities;
using Microsoft.EntityFrameworkCore;
using EfData.Interfaces;

namespace EfData.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly EfApartmentsContext _context;

        public ApartmentRepository(EfApartmentsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Apartment>> GetApartments()
        {
            var apartments = await _context.Apartments
                .Include(apartment => apartment.Kind)
                .Include(apartment => apartment.Address)
                .Include(apartment => apartment.Owner)
                .Include(apartment => apartment.Provider)
                .Include(apartment => apartment.Amenities)
                .ToListAsync();

            return apartments;
        }

        public async Task<Apartment> GetApartmentById(int id)
        {
            var apartment = await _context.Apartments
                .Include(a => a.Kind)
                .Include(a => a.Address)
                .Include(a => a.Owner)
                .Include(a => a.Provider)
                .Include(a => a.Amenities)
                .SingleOrDefaultAsync(a => a.Id == id);

            return apartment;
        }
        
        public async Task CreateApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateApartment(Apartment apartment)
        {
            var dbApartment = await _context.Apartments
                .Include(a => a.Kind)
                .Include(a => a.Address)
                .Include(a => a.Owner)
                .Include(a => a.Provider)
                .Include(a => a.Amenities)
                .SingleOrDefaultAsync(a => a.Id == apartment.Id);

            if (dbApartment == null)
            {
                return;
            }

            dbApartment.Address = apartment.Address;
            dbApartment.AddressId = dbApartment.AddressId;
            dbApartment.Amenities = apartment.Amenities;
            dbApartment.Kind = apartment.Kind;
            dbApartment.Owner = apartment.Owner;
            dbApartment.Price = apartment.Price;
            dbApartment.Provider = apartment.Provider;
            dbApartment.PetsAllowed = apartment.PetsAllowed;

            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteApartment(int id)
        {
            var dbApartment = await _context.Apartments
                .Include(a => a.Kind)
                .Include(a => a.Address)
                .Include(a => a.Owner)
                .Include(a => a.Provider)
                .Include(a => a.Amenities)
                .SingleOrDefaultAsync(a => a.Id == id);

            if (dbApartment == null)
            {
                return;
            }
            
            _context.Apartments.Remove(dbApartment);
            await _context.SaveChangesAsync();
        }
    }
}