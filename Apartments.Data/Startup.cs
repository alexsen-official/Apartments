using Apartments.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Apartments.Data
{
    public static class Startup
    {
        private static string _connectionString;
        
        public static void PassConnectionString(IServiceCollection services, string connectionString)
        {
            _connectionString = connectionString;
            
            services.AddScoped<IApartmentInfoRepository, ApartmentInfoRepository>();
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}