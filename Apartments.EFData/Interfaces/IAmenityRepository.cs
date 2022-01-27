using System.Collections.Generic;
using System.Threading.Tasks;
using EfData.Entities;

namespace EfData.Interfaces
{
    public interface IAmenityRepository
    {
        public Task<IEnumerable<Amenity>> GetAmenities();
        public Task<Amenity> GetAmenityById(int id);
        public Task CreateAmenity(Amenity amenity);
        public Task UpdateAmenity(Amenity amenity);
        public Task DeleteAmenity(int id);
    }
}