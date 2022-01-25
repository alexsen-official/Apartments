using Dapper;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class AmenityRepository
    {
        public List<Amenity> GetAmenitiesByApartmentId(int id)
        {
            using IDbConnection connection = new SqlConnection(Startup.GetConnectionString());

            string sql = @"SELECT Amenities.*
                           FROM Amenities
                           INNER JOIN ApartmentAmenities
                                 ON Amenities.id = ApartmentAmenities.amenityId
                           WHERE ApartmentAmenities.apartmentId = @apartmentId";
            
            return connection.Query<Amenity>(sql, new { apartmentId = id }).ToList();
        }
    }
}