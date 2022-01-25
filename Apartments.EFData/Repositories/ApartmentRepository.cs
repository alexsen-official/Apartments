using System.Linq;
using System.Collections.Generic;
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

        public IEnumerable<Apartment> GetApartments()
        {
            return _context.Apartments
                .Include(apartment => apartment.Kind)
                .Include(apartment => apartment.Address)
                .Include(apartment => apartment.Owner)
                .Include(apartment => apartment.Provider)
                .Include(apartment => apartment.Amenities);
        }

        public Apartment GetApartmentById(int id)
        {
            return GetApartments().FirstOrDefault(apartment => apartment.Id == id);
        }
    }
}