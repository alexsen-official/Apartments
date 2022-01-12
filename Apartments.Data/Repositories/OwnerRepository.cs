using Dapper;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
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

        public Owner? GetOwnerById(int id)
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            string sql = $@"SELECT TOP(1) *
                            FROM Owners
                            WHERE id = ${id}";
            
            IEnumerable<Owner>? query = connection.Query<Owner>(sql);
            
            return query.FirstOrDefault();
        }
    }
}