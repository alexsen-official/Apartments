using Dapper;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class ProviderRepository
    {
        private readonly IConfiguration _config;

        public ProviderRepository(IConfiguration config)
        {
            _config = config;
        }

        public Provider? GetProviderById(int id)
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            string sql = $@"SELECT TOP(1) *
                            FROM Providers
                            WHERE id = ${id}";
            
            IEnumerable<Provider>? query = connection.Query<Provider>(sql);
            
            return query.FirstOrDefault();
        }
    }
}