using System.Collections.Generic;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IApartmentRepository
    {
        public IEnumerable<Apartment> GetApartments();
        public Apartment GetApartmentById(int id);
    }
}