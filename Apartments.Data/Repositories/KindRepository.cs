using Dapper;
using System.Data;
using System.Data.SqlClient;
using Apartments.Data.Entities;

namespace Apartments.Data.Repositories
{
    public class KindRepository
    {
        public Kind GetKindById(int id)
        {
            using IDbConnection connection = new SqlConnection(Startup.GetConnectionString());

            string sql = @"SELECT TOP(1) *
                           FROM Kinds
                           WHERE id = @kindId";

            return connection.QueryFirstOrDefault(sql, new { kindId = id });
        }
    }
}