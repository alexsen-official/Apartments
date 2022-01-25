using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public interface IApartmentInfoRepository
    {
        public ApartmentInfo GetInformationById(int id);
    }
}