using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Apartments.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace Apartments.Data.Repositories
{
    public class ApartmentInfoRepository
    {
        private readonly IConfiguration _config;

        public ApartmentInfoRepository(IConfiguration config)
        {
            _config = config;
        }

        public ApartmentInfo? GetInformationById(int id)
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );
            
            string sql = @"SELECT Apartments.*,
                                  Kinds.*,
                                  Addresses.*,
                                  Owners.*,
                                  Providers.*,
                                  Amenities.*
                           FROM Apartments
                           LEFT JOIN Kinds
                                ON Apartments.kindId = Kinds.id
                           LEFT JOIN Addresses
                                ON Apartments.addressId = Addresses.id
                           LEFT JOIN Owners
                                ON Apartments.ownerId = Owners.id
                           LEFT JOIN Providers
                                ON Apartments.providerId = Providers.id
                           LEFT JOIN ApartmentAmenities
                                ON Apartments.id = ApartmentAmenities.apartmentId
                           LEFT JOIN Amenities
                                ON ApartmentAmenities.amenityId = Amenities.id
                           WHERE Apartments.id = @apartmentId";

            ApartmentInfo result = new();

            return connection
                .Query<ApartmentInfo, Kind, Address, Owner, Provider, Amenity, ApartmentInfo>(
                    sql,
                    (apartmentInfo, kind, address, owner, provider, amenity) =>
                    {
                        result.Id = apartmentInfo.Id;
                        result.Kind = kind;
                        result.Address = address;
                        result.Owner = owner;
                        result.Provider = provider;
                        result.PetsAllowed = apartmentInfo.PetsAllowed;
                        result.Price = apartmentInfo.Price;

                        if (amenity is not null)
                        {
                            result.Amenities.Add(amenity);
                        }

                        return result;
                    },
                    new { apartmentId = id },
                    splitOn: "id"
                )
                .LastOrDefault();
        }
    }
}