using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class OwnerRepository
    {
        private readonly IConfiguration _config;

        public OwnerRepository(IConfiguration config)
        {
            _config = config;
        }

        public Owner GetOwnerById(int id)
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            string sql = @"SELECT TOP(1) *
                           FROM Owners
                           WHERE id = @ownerId";

            return connection.QueryFirstOrDefault(sql, new {ownerId = id});
        }
    }
}