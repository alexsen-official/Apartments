using Dapper;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class AmenityRepository
    {
        private readonly IConfiguration _config;

        public AmenityRepository(IConfiguration config)
        {
            _config = config;
        }

        public List<Amenity> GetAmenitiesByApartmentId(int id)
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            string sql = @"SELECT Amenities.*
                           FROM Amenities
                           INNER JOIN ApartmentAmenities
                                 ON Amenities.id = ApartmentAmenities.amenityId
                           WHERE ApartmentAmenities.apartmentId = @apartmentId";
            
            return connection.Query<Amenity>(sql, new { apartmentId = id }).ToList();
        }
    }
}