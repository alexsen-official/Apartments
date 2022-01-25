using Dapper;
using System.Data;
using System.Data.SqlClient;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class OwnerRepository
    {
        public Owner GetOwnerById(int id)
        {
            using IDbConnection connection = new SqlConnection(Startup.GetConnectionString());

            string sql = @"SELECT TOP(1) *
                           FROM Owners
                           WHERE id = @ownerId";

            return connection.QueryFirstOrDefault(sql, new {ownerId = id});
        }
    }
}