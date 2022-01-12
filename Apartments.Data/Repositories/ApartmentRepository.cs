using Dapper;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
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

        public Apartment? GetApartmentById(int id)
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            string sql = $@"SELECT TOP(1) *
                            FROM Apartments
                            WHERE id = ${id}";
            
            IEnumerable<Apartment>? query = connection.Query<Apartment>(sql);
            
            return query.FirstOrDefault();
        }
    }
}