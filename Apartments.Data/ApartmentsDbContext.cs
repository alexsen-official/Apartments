using Apartments.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apartments.Data
{
    public class ApartmentsDbContext : DbContext
    {
        public ApartmentsDbContext(DbContextOptions<ApartmentsDbContext> options) : base(options)
        {
            
        }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<ApartmentAmenity> ApartmentAmenities { get; set; }
    }
}