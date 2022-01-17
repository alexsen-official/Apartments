using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class ApartmentRepository
    {
        private readonly IConfiguration _config;

        public ApartmentRepository(IConfiguration config)
        {
            _config = config;
        }

        public Apartment GetApartmentById(int id)
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            string sql = @"SELECT TOP(1) *
                           FROM Apartments
                           WHERE id = @apartmentId";

            return connection.QueryFirstOrDefault(sql, new {apartmentId = id});
        }
    }
}