using Apartment.Business.Services;
using Apartment.Business.Services.Interfaces;
using Apartments.Data.Repositories;
using EFData;
using EFData.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Apartments.Extensions;

namespace Apartments
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerConfig();
            
            Apartment.Business.Startup.PassConnectionString(Configuration.GetConnectionString("EFDefaultConnection"));
            services.AddDbContext<EFApartmentsContext>();

            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IApartmentInfoRepository, ApartmentInfoRepository>();
            services.AddScoped<IApartmentRepository, EFData.Repositories.ApartmentRepository>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerConfig();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}