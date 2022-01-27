using System.Collections.Generic;
using System.Threading.Tasks;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IApartmentRepository
    {
        public Task<IEnumerable<Apartment>> GetApartments();
        public Task<Apartment> GetApartmentById(int id);
        public Task CreateApartment(Apartment apartment);
        public Task UpdateApartment(Apartment apartment);
        public Task DeleteApartment(int id);
    }
}