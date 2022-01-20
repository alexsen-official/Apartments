using Apartment.Business.Services;
using Apartment.Business.Services.Interfaces;
using EFData;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<EFApartmentsContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("EFDefaultConnection")
));

builder.Services.AddScoped<IApartmentService, ApartmentService>();

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();