using Dapper;
using System.Data;
using System.Data.SqlClient;
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

        public Address GetAddressById(int id)
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            string sql = @"SELECT TOP(1) *
                           FROM Addresses
                           WHERE id = @addressId";
            
            return connection.QueryFirstOrDefault(sql, new { addressId = id });
        }
    }
}