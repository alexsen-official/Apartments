using System.Collections.Generic;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IApartmentService
    {
        public IEnumerable<ApartmentViewModel> GetApartments();
        public ApartmentViewModel GetApartmentById(int id);
        public IEnumerable<ApartmentViewModel> CreateApartment(ApartmentViewModel apartmentViewModel);
        public IEnumerable<ApartmentViewModel> UpdateApartment(ApartmentViewModel apartmentViewModel);
        public IEnumerable<ApartmentViewModel> DeleteApartment(int id);
    }
}