using Dapper;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class InformationRepository
    {
        private readonly IConfiguration _config;

        public InformationRepository(IConfiguration config)
        {
            _config = config;
        }

        public Information? GetInformationById(int id)
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
                            INNER JOIN ApartmentAmenities
                                ON Apartments.id = ApartmentAmenities.apartmentId
                            INNER JOIN Amenities
                                ON ApartmentAmenities.amenityId = Amenities.id
                            WHERE ApartmentAmenities.apartmentId = {id}";

            IEnumerable<Information> query = connection
                .Query<Information, Kind, Address, Owner, Provider, Amenity, Information>(
                    sql,
                    (information, kind, address, owner, provider, amenity) =>
                    {
                        information.Kind = kind;
                        information.Address = address;
                        information.Owner = owner;
                        information.Provider = provider;
                        information.Amenities ??= new List<Amenity>();
                        information.Amenities.Add(amenity);
                        return information;
                    },
                    new { ApartmentId = id },
                    splitOn: "Id"
                );

            Information? result = query
                .GroupBy(information => information.Id)
                .Select(group => {
                    Information combinedInformation = group.First();
                    
                    combinedInformation.Amenities = group.Select(
                        information => information.Amenities.Single()
                    ).ToList();
                    
                    return combinedInformation;
                }).FirstOrDefault();

            return result;
        }
    }
}