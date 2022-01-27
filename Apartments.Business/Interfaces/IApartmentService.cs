using System.Collections.Generic;
using System.Threading.Tasks;
using Apartments.Models.ViewModel;

namespace Apartment.Business.Interfaces
{
    public interface IApartmentService
    {
        public Task<IEnumerable<ApartmentViewModel>> GetApartments();
        public Task<ApartmentViewModel> GetApartmentById(int id);
        public Task<IEnumerable<ApartmentViewModel>> CreateApartment(ApartmentViewModel apartmentViewModel);
        public Task<IEnumerable<ApartmentViewModel>> UpdateApartment(ApartmentViewModel apartmentViewModel);
        public Task<IEnumerable<ApartmentViewModel>> DeleteApartment(int id);
    }
}