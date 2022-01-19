using System.Linq;
using EFData.Entities;
using System.Collections.Generic;

namespace EFData.Repositories
{
    public class ApartmentRepository
    {
        private readonly EFApartmentsContext _context;

        public ApartmentRepository(EFApartmentsContext context)
        {
            _context = context;
        }
        
        public List<Apartment> GetApartments()
        {
            return _context.Apartments.ToList();
        }

        public Apartment GetApartmentById(int id)
        {
            return _context.Apartments.FirstOrDefault(i => i.Id == id);
        }
    }
}