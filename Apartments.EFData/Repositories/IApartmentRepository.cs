using EFData.Entities;

namespace EFData.Repositories
{
    public interface IApartmentRepository
    {
        public Apartment GetApartmentById(int id);
    }
}