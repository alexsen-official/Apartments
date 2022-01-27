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
            return _context.Apartments
                .Include(a => a.Kind)
                .Include(a => a.Address)
                .Include(a => a.Owner)
                .Include(a => a.Provider)
                .Include(a => a.Amenities)
                .SingleOrDefault(a => a.Id == id);
        }
        
        public void CreateApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            _context.SaveChanges();
        }
        
        public void UpdateApartment(Apartment apartment)
        {
            Apartment dbApartment = _context.Apartments
                .Include(a => a.Kind)
                .Include(a => a.Address)
                .Include(a => a.Owner)
                .Include(a => a.Provider)
                .Include(a => a.Amenities)
                .SingleOrDefault(a => a.Id == apartment.Id);

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

            _context.SaveChanges();
        }
        
        public void DeleteApartment(int id)
        {
            Apartment dbApartment = _context.Apartments
                .Include(a => a.Kind)
                .Include(a => a.Address)
                .Include(a => a.Owner)
                .Include(a => a.Provider)
                .Include(a => a.Amenities)
                .SingleOrDefault(a => a.Id == id);

            if (dbApartment == null)
            {
                return;
            }
            
            _context.Apartments.Remove(dbApartment);
            _context.SaveChanges();
        }
    }
}