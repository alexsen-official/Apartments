using Dapper;
using System.Data;
using System.Data.SqlClient;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class ProviderRepository
    {
        public Provider GetProviderById(int id)
        {
            using IDbConnection connection = new SqlConnection(Startup.GetConnectionString());

            string sql = @"SELECT TOP(1) *
                           FROM Providers
                           WHERE id = @providerId";

            return connection.QueryFirstOrDefault(sql, new { providerId = id });
    }
    }
}