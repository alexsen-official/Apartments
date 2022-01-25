using Dapper;
using System.Data;
using System.Data.SqlClient;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class AddressRepository
    {
        public Address GetAddressById(int id)
        {
            using IDbConnection connection = new SqlConnection(Startup.GetConnectionString());

            string sql = @"SELECT TOP(1) *
                           FROM Addresses
                           WHERE id = @addressId";
            
            return connection.QueryFirstOrDefault(sql, new { addressId = id });
        }
    }
}