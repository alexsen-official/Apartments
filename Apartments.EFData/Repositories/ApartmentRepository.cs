using System.Linq;
using EFData.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFData.Repositories
{
    public class ApartmentRepository
    {
        private readonly EFApartmentsContext _context;

        public ApartmentRepository(EFApartmentsContext context)
        {
            _context = context;
        }

        public Apartment GetApartmentById(int id)
        {
            return _context.Apartments
                .Include(apartment => apartment.Kind)
                .Include(apartment => apartment.Address)
                .Include(apartment => apartment.Owner)
                .Include(apartment => apartment.Provider)
                .Include(apartment => apartment.Amenities)
                .FirstOrDefault(apartment => apartment.Id == id);
        }
    }
}