using Dapper;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class AddressRepository
    {
        private readonly IConfiguration _config;

        public AddressRepository(IConfiguration config)
        {
            _config = config;
        }

        public Address? GetAddressById(int id)
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            string sql = $@"SELECT TOP(1) *
                            FROM Addresses
                            WHERE id = ${id}";
            
            IEnumerable<Address>? query = connection.Query<Address>(sql);
            
            return query.FirstOrDefault();
        }
    }
}