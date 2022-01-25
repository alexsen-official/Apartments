using Microsoft.Extensions.DependencyInjection;
using EfData.Interfaces;
using EfData.Repositories;

namespace EfData
{
    public static class Startup
    {
        private static string _connectionString;
        
        public static void PassConnectionString(IServiceCollection services, string connectionString)
        {
            _connectionString = connectionString;

            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAmenityRepository, AmenityRepository>();
            services.AddScoped<IKindRepository, KindRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            
            services.AddDbContext<EfApartmentsContext>();
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}