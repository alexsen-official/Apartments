using Microsoft.Extensions.DependencyInjection;
using Apartment.Business.Interfaces;
using Apartment.Business.Services;

namespace Apartment.Business
{
    public static class Startup
    {
        public static void PassConnectionString(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAmenityService, AmenityService>();
            services.AddScoped<IKindService, KindService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IProviderService, ProviderService>();
            
            EfData.Startup.PassConnectionString(services, connectionString);
        }
    }
}