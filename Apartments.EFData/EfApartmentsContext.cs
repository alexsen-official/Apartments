using EfData.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfData
{
    public class EfApartmentsContext : DbContext
    {
        private readonly string _connectionString;
        public EfApartmentsContext()
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