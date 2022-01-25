using Dapper;
using System.Data;
using System.Data.SqlClient;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class ApartmentRepository
    {
        public Apartment GetApartmentById(int id)
        {
            using IDbConnection connection = new SqlConnection(Startup.GetConnectionString());

            string sql = @"SELECT TOP(1) *
                           FROM Apartments
                           WHERE id = @apartmentId";

            return connection.QueryFirstOrDefault(sql, new {apartmentId = id});
        }
    }
}