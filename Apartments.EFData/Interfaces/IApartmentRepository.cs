using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IApartmentRepository
    {
        public IEnumerable<Apartment> GetApartments();
        public Apartment GetApartmentById(int id);
        public IEnumerable<Apartment> CreateApartment(Apartment apartment);
        public IEnumerable<Apartment> UpdateApartment(Apartment apartment);
        public IEnumerable<Apartment> DeleteApartment(int id);
    }
}