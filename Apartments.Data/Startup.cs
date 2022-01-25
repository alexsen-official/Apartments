using Microsoft.Extensions.DependencyInjection;

namespace Apartments.Data
{
    public static class Startup
    {
        private static string _connectionString;
        
        public static void PassConnectionString(IServiceCollection services, string connectionString)
        {
            _connectionString = connectionString;
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}