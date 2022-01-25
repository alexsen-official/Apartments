using Apartments.Models.ViewModel;

namespace Apartment.Business.Services.Interfaces
{
    public interface IApartmentService
    {
        public ApartmentViewModel GetApartmentById(int id);
    }
}