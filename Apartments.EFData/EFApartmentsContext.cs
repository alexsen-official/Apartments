using EFData.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFData
{
    public class EFApartmentsContext : DbContext
    {
        private readonly string _connectionString;
        public EFApartmentsContext()
        {
            _connectionString = Startup.GetConnectionString();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
    }
}