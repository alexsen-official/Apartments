using System.Collections.Generic;
using System.Linq;
using System.Net;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class InformationRepository
    {
        private readonly ApartmentsDbContext _dbContext;

        public InformationRepository(ApartmentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Information? GetInformationById(int id)
        {
            var queryable =
                (from apartment in _dbContext.Apartments
                    join kind in _dbContext.Kinds
                        on apartment.KindId equals kind.Id
                        into kindsGroup
                    from kindGroup in kindsGroup.DefaultIfEmpty()
                    join address in _dbContext.Addresses
                        on apartment.AddressId equals address.Id
                        into addressesGroup
                    from addressGroup in addressesGroup.DefaultIfEmpty()
                    join owner in _dbContext.Owners
                        on apartment.OwnerId equals owner.Id
                        into ownersGroup
                    from ownerGroup in ownersGroup.DefaultIfEmpty()
                    join provider in _dbContext.Providers
                        on apartment.ProviderId equals provider.Id
                        into providersGroup
                    from providerGroup in providersGroup.DefaultIfEmpty()
                    join apartmentAmenity in _dbContext.ApartmentAmenities
                        on apartment.Id equals apartmentAmenity.ApartmentId
                    join amenity in _dbContext.Amenities
                        on apartmentAmenity.AmenityId equals amenity.Id
                    where apartmentAmenity.ApartmentId == id
                    select new Information
                    {
                        Apartment = apartment,
                        Kind = kindGroup,
                        Address = addressGroup,
                        Owner = ownerGroup,
                        Provider = providerGroup,
                        Amenities = new List<Amenity> {amenity}
                    }).ToList();

            var result = queryable.FirstOrDefault();

            if (result != null)
            {
                result.Amenities = queryable
                    .Select(i => i.Amenities)
                    .Select(i => i.First())
                    .ToList();
            }

            return queryable.FirstOrDefault();
        }
    }
}