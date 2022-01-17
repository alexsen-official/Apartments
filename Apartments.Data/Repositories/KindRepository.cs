using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class KindRepository
    {
        private readonly IConfiguration _config;

        public KindRepository(IConfiguration config)
        {
            _config = config;
        }

        public Kind GetKindById(int id)
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            string sql = @"SELECT TOP(1) *
                           FROM Kinds
                           WHERE id = @kindId";

            return connection.QueryFirstOrDefault(sql, new { kindId = id });
        }
    }
}