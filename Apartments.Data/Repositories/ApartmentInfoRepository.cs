using Dapper;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Apartments.Data.Entities;

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

            string sql = $@"SELECT Apartments.*,
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
                                ON Apartments.ownerId = Owners.Id
                            LEFT JOIN Providers
                                ON Apartments.providerId = Providers.id
                            LEFT JOIN ApartmentAmenities
                                ON Apartments.id = ApartmentAmenities.apartmentId
                            LEFT JOIN Amenities
                                ON ApartmentAmenities.amenityId = Amenities.id
                            WHERE Apartments.id = {id}";

            List<ApartmentInfo> query = connection
                .Query<ApartmentInfo, Kind, Address, Owner, Provider, Amenity, ApartmentInfo>(
                    sql,
                    (apartmentInfo, kind, address, owner, provider, amenity) =>
                    {
                        apartmentInfo.Kind = kind;
                        apartmentInfo.Address = address;
                        apartmentInfo.Owner = owner;
                        apartmentInfo.Provider = provider;
                        apartmentInfo.Amenities ??= new List<Amenity>();
                        apartmentInfo.Amenities.Add(amenity);
                        return apartmentInfo;
                    },
                    new { Id = id },
                    splitOn: "Id"
                ).ToList();

            ApartmentInfo result = query.FirstOrDefault();

            if (result != null)
            {
                var amenities = query
                    .Select(i => i.Amenities)
                    .Select(i => i.FirstOrDefault())
                    .Where(i => i != null)
                    .ToList();

                if (amenities.Count > 0)
                {
                    result.Amenities = amenities;
                }
                else
                {
                    result.Amenities = null;
                }
            }

            return result;
        }
    }
}