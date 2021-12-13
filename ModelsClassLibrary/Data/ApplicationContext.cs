using Microsoft.EntityFrameworkCore;
using ModelsClassLibrary.Entitys;

namespace ModelsClassLibrary.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<VehiclesCompany> VehiclesCompanies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
