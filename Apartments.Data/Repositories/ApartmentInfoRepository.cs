using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Apartments.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Apartments.Data.Repositories
{
    public class ApartmentInfoRepository
    {
        private readonly IConfiguration _config;

        public ApartmentInfoRepository(IConfiguration config)
        {
            _config = config;
        }

        public ApartmentInfo GetInformationById(int id)
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

            List<Amenity> amenities = new();

            List<ApartmentInfo> query = connection
                .Query<ApartmentInfo, Kind, Address, Owner, Provider, Amenity, ApartmentInfo>(
                    sql,
                    (apartmentInfo, kind, address, owner, provider, amenity) =>
                    {
                        apartmentInfo.Kind = kind;
                        apartmentInfo.Address = address;
                        apartmentInfo.Owner = owner;
                        apartmentInfo.Provider = provider;

                        if (amenity != null)
                        {
                            amenities.Add(amenity);
                        }

                        return apartmentInfo;
                    },
                    new { apartmentId = id },
                    splitOn: "id"
                )
                .ToList();

            ApartmentInfo result = query.FirstOrDefault();

            if (result != null)
            {
                result.Amenities = amenities;
            }

            return result;
        }
    }
}